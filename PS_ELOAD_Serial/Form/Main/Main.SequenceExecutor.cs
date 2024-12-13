using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace PS_ELOAD_Serial
{
    public partial class Main : Form
    {
        private List<SequenceStep> sequenceSteps; // 시퀀스 단계 리스트
        private int currentStepIndex;             // 현재 단계 인덱스
        private int loopCount = 1;  // 기본 루프 횟수는 1로 설정

        public async Task StartSequenceAsync()
        {
            if (sequenceSteps.Count == 0) return;
            currentStepIndex = 0;
            isSequenceRunning = true;

            for (int loop = 0; loop < loopCount; loop++)
            {
                currentStepIndex = 0;  // 루프 시작 시 인덱스를 초기화

                while (isSequenceRunning && currentStepIndex < sequenceSteps.Count)
                {
                    SequenceStep step = sequenceSteps[currentStepIndex];

                    // 부하 설정 및 전환 방식에 따른 실행 로직
                    SetLoadState(step.InputOnOff);

                    if (step.Transition == "RAMP")
                    {
                        await ApplyRampTransition(step.Level, step.Dwell);
                    }
                    else if (step.Transition == "IMM")
                    {
                        await ApplyImmediateTransition(step.Level, step.Dwell);
                    }

                    currentStepIndex++;
                }

                if (!isSequenceRunning) break;  // 시퀀스 중단 시 루프도 종료
            }

            StopSequence(); // 시퀀스 종료 후 상태 초기화
        }

        // 시퀀스 중지
        public void StopSequence()
        {
            isSequenceRunning = false;
            //UpdateSequenceStatus(false);
        }

        // 즉시 전환 모드
        private async Task ApplyImmediateTransition(double level, int dwell)
        {
            // CV 모드일 경우 전압을 설정, CC 모드일 경우 전류를 설정
            if (currentMode == "CV")
            {
                SendCommandToELoad("VOLT " + level.ToString("F2"));
            }
            else if (currentMode == "CC")
            {
                SendCommandToELoad("CURR " + level.ToString("F2"));
            }
            // Dwell 시간 동안 전압 유지
            await Task.Delay(dwell * 1000);
        }

        // 점진적 증가(Ramp 모드) 구현
        private async Task ApplyRampTransition(double targetLevel, int dwell)
        {
            double initialLevel = GetCurrentVoltage(); // 현재 전압 값을 가져옴
            double stepSize = (targetLevel - initialLevel) / (2 * dwell);
            double currentLevel = initialLevel;

            for (int i = 0; i < (2 * dwell); i++)
            {
                if (!isSequenceRunning) break; // 시퀀스 중지 시 종료

                currentLevel += stepSize;

                // CV 모드일 경우 전압을 설정, CC 모드일 경우 전류를 설정
                if (currentMode == "CV")
                {
                    SendCommandToELoad("VOLT " + currentLevel.ToString("F2"));
                }
                else if (currentMode == "CC")
                {
                    SendCommandToELoad("CURR " + currentLevel.ToString("F2"));
                }

                await Task.Delay(500); // 0.5초 간격으로 ramp 실행
            }
        }

        // 부하 켜짐/꺼짐 설정
        private void SetLoadState(string onOff)
        {
            if (onOff == "ON")
            {
                SendCommandToELoad("INP ON");
            }
            else
            {
                SendCommandToELoad("INP OFF");
            }
        }

        // 현재 전압을 읽어오는 메서드 (실제 ELoad와의 통신으로 구현 필요)
        private double GetCurrentVoltage()
        {
            return 0.0; // 기본값 설정
        }

        private List<SequenceStep> GetSequenceStepsFromDatabase(int programID)
        {
            List<SequenceStep> steps = new List<SequenceStep>();
            string connectionString = @"Data Source=C:\Users\kangdohyun\Desktop\세미나\강도현\7주차\PS_ELOAD_CAN\MyDatabase#1.sdf; Password=a1234!;";

            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProgramID2, Level2, SR_A_us2, Dwell_s2, Load_immediate_ramp2, Wait_pre2, Generate2, StepNum2, LoadOnOff2 " +
                               "FROM ProgramSettings2 WHERE ProgramID2 = @ProgramID";

                using (SqlCeCommand command = new SqlCeCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProgramID", programID);

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SequenceStep step = new SequenceStep
                            {
                                ProgramID = reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
                                Level = reader.IsDBNull(1) ? 0 : reader.GetInt32(1), // int형으로 읽어옴
                                SR_A_us = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                                Dwell = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                Transition = reader.IsDBNull(4) ? "IMM" : reader.GetString(4),
                                WaitPre = reader.IsDBNull(5) ? "OFF" : reader.GetString(5),
                                Generate = reader.IsDBNull(6) ? "None" : reader.GetString(6),
                                StepNum = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                InputOnOff = reader.IsDBNull(8) ? "OFF" : reader.GetString(8)
                            };
                            steps.Add(step);
                        }
                    }
                }
            }

            return steps;
        }



        // 시퀀스 단계 정보 클래스
        public class SequenceStep
        {
            public int ProgramID { get; set; }       // Program ID
            public double Level { get; set; }        // 전압 레벨
            public int SR_A_us { get; set; }         // SR_A_us 값
            public int Dwell { get; set; }           // Dwell 시간
            public string Transition { get; set; }   // Load_immediate_ramp 전환 모드
            public string Generate { get; set; }     // Generate 값
            public int StepNum { get; set; }         // 단계 번호
            public string InputOnOff { get; set; }   // 부하 상태
            public string WaitPre { get; set; }      // Wait_pre 값
        }
    }
}
