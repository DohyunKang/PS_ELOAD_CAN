using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using NationalInstruments.UI; // 그래프 컨트롤을 사용하기 위한 참조

namespace PS_ELOAD_Serial
{
    public partial class Main : Form
    {
        /*private SerialPort dmmPort; // DMM 시리얼 포트 객체
        private double dmmVoltage;  // DMM에서 읽은 전압
        private double dmmCurrent;  // 계산된 전류
        private string voltageStr;
        private double elapsedTime3; // DMM 그래프의 시간 흐름을 나타내는 변수

        private Timer dmmReadTimer; // DMM 값을 주기적으로 읽기 위한 타이머

        // DMM COM 포트 콤보박스 초기화
        private void InitializeDMMComboBox()
        {
            comboBox_DMM.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            comboBox_DMM.Items.AddRange(ports);
        }

        // DMM 스위치 상태 변경 이벤트
        private void switchDMM_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (switchDMM.Value) // 스위치가 켜진 경우
            {
                ConnectDMMPort();
                //dmmReadTimer.Start(); // 타이머 시작
            }
            else // 스위치가 꺼진 경우
            {
                //dmmReadTimer.Stop(); // 타이머 중지
                DisconnectDMMPort();
            }
        }

        // DMM 포트 연결
        private void ConnectDMMPort()
        {
            if (comboBox_DMM.SelectedItem != null)
            {
                try
                {
                    dmmPort = new SerialPort(comboBox_DMM.SelectedItem.ToString(), 19200, Parity.None, 8, StopBits.One);
                    dmmPort.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DMM 연결 실패: " + ex.Message, "연결 오류");
                }
            }
            else
            {
                MessageBox.Show("DMM 포트를 선택하세요.", "연결 오류");
            }
        }

        // DMM 포트 연결 해제
        private void DisconnectDMMPort()
        {
            if (dmmPort != null && dmmPort.IsOpen)
            {
                dmmPort.Close();
            }
        }

        // DMM에서 전압 읽기 메서드
        private void ReadDMMVoltage()
        {
            elapsedTime3 = 0.5;

            if (dmmPort != null && dmmPort.IsOpen)
            {
                try
                {
                    //dmmPort.WriteLine("MEAS:VOLT:DC?"); // DMM에 전압 측정 명령어 전송
                    //LogCommand("DMM TX", "MEAS:VOLT:DC?"); // TX 로그 추가

                    dmmPort.WriteLine("VAL1?"); // DMM에 전압 측정 명령어 전송
                    LogCommand("DMM TX", "VAL1?"); // TX 로그 추가

                    voltageStr = dmmPort.ReadLine();
                    LogCommand("DMM RX", voltageStr); // RX 로그 추가

                    if (double.TryParse(voltageStr, out dmmVoltage))
                    {
                        // 전류 계산
                        dmmCurrent = ((5 / supplyVoltage) * dmmVoltage - offsetVoltage) * (-1 / sensitivity);
                        // DMM 전류 그래프 및 라벨 업데이트
                        lblCurrent_DMM.Text = dmmCurrent.ToString("F2") + " A";
                        waveformPlot_A4.PlotYAppend(dmmCurrent, elapsedTime3); // 그래프에 데이터 추가
                    }

                    // DMM 전류 그래프 및 라벨 업데이트
                    //lblCurrent_DMM.Text = dmmCurrent.ToString("F2") + " A";
                   // waveformPlot_A4.PlotYAppend(dmmCurrent, elapsedTime3); // 그래프에 데이터 추가
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DMM 데이터 수신 실패: " + ex.Message, "오류");
                }
            }
        }

        // DMM 데이터 읽기 타이머 이벤트 핸들러
        private void DmmReadTimer_Tick(object sender, EventArgs e)
        {
            ReadDMMVoltage();
        }
        */
    }
}
