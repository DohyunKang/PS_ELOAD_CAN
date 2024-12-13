using System;
using System.Windows.Forms;
using NationalInstruments.DAQmx;  // DAQmx API 사용을 위한 참조
using NationalInstruments.UI;    // 그래프 컨트롤을 사용하기 위한 참조
using System.Diagnostics;

namespace PS_ELOAD_Serial
{
    public partial class Ps_Eload_Current : Form
    {
        private NationalInstruments.DAQmx.Task voltageTask;  // DAQmx Task 객체
        private AnalogSingleChannelReader reader;  // DAQ에서 데이터를 읽어오기 위한 Reader 객체
        private Timer updateTimer;  // 데이터를 읽어오는 타이머
        private double elapsedTime = 0;  // X축 시간값을 저장할 변수
        private const double supplyVoltage = 5.0; // 공급 전압 (U_c)
        private const double offsetVoltage = 2.5; // 오프셋 전압 (V_0) - 센서의 기본값
        private const double sensitivity = 0.0267; // DHAB S/113 채널 1의 감도 (26.7 mV/A = 0.0267 V/A)

        public Ps_Eload_Current()
        {
            InitializeComponent();

            // DAQ로부터 전압을 읽는 Task 설정
            InitializeDAQ();

            // 타이머 초기화
            updateTimer = new Timer();
            updateTimer.Interval = 100; // 0.1초마다 데이터 업데이트
            updateTimer.Tick += (s, ev) => UpdateDAQData();

            // 버튼 클릭 이벤트 핸들러 연결
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);

            // 그래프 초기화 (축 설정)
            InitializeGraph();
        }

        private void InitializeDAQ()
        {
            try
            {
                // DAQ Task 생성 (ai0 포트에서 전압을 측정)
                voltageTask = new NationalInstruments.DAQmx.Task();
                voltageTask.AIChannels.CreateVoltageChannel("Dev2/ai0", "VoltageChannel", AITerminalConfiguration.Rse, 0.0, 10.0, AIVoltageUnits.Volts);

                // 데이터를 읽기 위한 AnalogSingleChannelReader 초기화
                reader = new AnalogSingleChannelReader(voltageTask.Stream);
            }
            catch (DaqException ex)
            {
                MessageBox.Show("DAQ 초기화 중 오류 발생: " + ex.Message);
            }
        }
        Stopwatch sw = new Stopwatch();
        private void UpdateDAQData()
        {
            sw.Restart();
            Debug.WriteLine(string.Format("시작 {0}", sw.ElapsedMilliseconds));
            try
            {
                // 전압값을 DAQ로부터 읽음
                double outputVoltage = reader.ReadSingleSample();

                // lblVoltage_DAQ에 전압값 표시
                lblVoltage_DAQ.Text = outputVoltage.ToString("F2") + " V";

                // 전류값 계산 (공식에 따라 전류 계산)
                double current = ((5 / supplyVoltage) * outputVoltage - offsetVoltage) * (-1 / sensitivity); // 전류 측정 센서 반대로 연결함.

                // lblCurrent_DAQ에 전류값 표시
                lblCurrent_DAQ.Text = current.ToString("F2") + " A";

                // 실시간으로 그래프에 데이터 추가 (시간 경과에 따른 전류)
                PlotGraph(elapsedTime, current);

                // 시간 경과값 증가 (0.1초마다 타이머 동작)
                elapsedTime += updateTimer.Interval / 1000.0;
            }
            catch (DaqException ex)
            {
                MessageBox.Show("DAQ 데이터 업데이트 중 오류 발생: " + ex.Message);
            }
            Debug.WriteLine(string.Format("끝 {0}", sw.ElapsedMilliseconds));
        }

        // 그래프 초기화 메서드
        private void InitializeGraph()
        {
            // Y축은 전류 (A), X축은 시간 (초)
            waveformGraph1.YAxes[0].Caption = "Current (A)";
            waveformGraph1.XAxes[0].Caption = "Time (0.1s)";
        }

        // 그래프에 실시간 데이터 추가 메서드
        private void PlotGraph(double time, double current)
        {
            // X축(시간)과 Y축(전류)을 전달하여 그래프에 점을 추가
            waveformGraph1.PlotYAppend(current);
        }

        // ReadButton 클릭 시 타이머 시작
        private void ReadButton_Click(object sender, EventArgs e)
        {
            if (!updateTimer.Enabled)  // 타이머가 이미 동작 중인지 확인
            {
                elapsedTime = 0;  // 시간 초기화
                waveformGraph1.ClearData();  // 이전 그래프 데이터 초기화
                updateTimer.Start();
                MessageBox.Show("데이터 수집 시작");
            }
            else
            {
                MessageBox.Show("이미 데이터 수집이 진행 중입니다.");
            }
        }

        // StopButton 클릭 시 타이머 중지
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (updateTimer.Enabled)  // 타이머가 동작 중인지 확인
            {
                updateTimer.Stop();
                MessageBox.Show("데이터 수집 중지");
            }
            else
            {
                MessageBox.Show("현재 데이터 수집이 중지된 상태입니다.");
            }
        }
    }
}
