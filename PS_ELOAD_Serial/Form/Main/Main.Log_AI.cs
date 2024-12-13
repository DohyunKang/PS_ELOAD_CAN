using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.DAQmx;  // DAQmx API 사용을 위한 참조
using NationalInstruments.UI;    // 그래프 컨트롤을 사용하기 위한 참조
using System.Diagnostics;

namespace PS_ELOAD_Serial
{
    public partial class Main : Form
    {
        private NationalInstruments.DAQmx.Task aiTask;
        private AnalogSingleChannelReader aiReader;
        private double AiCurrentAvg;

        private const double supplyVoltage = 5.0; // 공급 전압 (U_c)
        private const double offsetVoltage = 2.5; // 오프셋 전압 (V_0) - 센서의 기본값
        private const double sensitivity = 0.0267; // DHAB S/113 채널 1의 감도 (26.7 mV/A = 0.0267 V/A)

        private void Main_Load(object sender, EventArgs e)
        {
            GetSerialPortList(); // 시작 시 COM 포트 목록을 가져오기 위한 메서드 호출
            switch1.StateChanged += Switch1_StateChanged; // ELoad 스위치 이벤트 핸들러 추가
            switch2.StateChanged += Switch2_StateChanged; // PowerSupply 스위치 이벤트 핸들러 추가

            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            this.ApplyButton2.Click += new System.EventHandler(this.ApplyButton2_Click);
            this.OutPutButton.Click += new System.EventHandler(this.OutPutButton_Click);

            // ELoad 모드 전환 이벤트 핸들러 추가
            CCButton.CheckedChanged += ELoadRadioButton_CheckedChanged;
            CVButton.CheckedChanged += ELoadRadioButton_CheckedChanged;
            CRButton.CheckedChanged += ELoadRadioButton_CheckedChanged;

            // 타이머 초기화
            eLoadDataTimer = new System.Windows.Forms.Timer();
            eLoadDataTimer.Interval = 500;
            eLoadDataTimer.Tick += new EventHandler(EloadDataTimer_Tick);

            psDataTimer = new System.Windows.Forms.Timer();
            psDataTimer.Interval = 500;
            psDataTimer.Tick += new EventHandler(PsDataTimer_Tick);

            // Delegate를 해당 메서드에 연결
            OpenSequenceDelegate = OpenSequenceWindow;
            OpenSequenceDelegate2 = OpenSequenceWindow2;

            ModeButton.Click += ModeButton_Click; // ModeButton의 Click 이벤트 핸들러 설정
        }

        protected void LogCommand(string direction, string command)
        {
            // 현재 시간을 "yyyy-MM-dd HH:mm:ss" 형식으로 가져오기
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    
            // 로그 메시지 생성
            string logMessage = string.Format("{0} [{1}] {2}", timestamp, direction, command);
  
            // 로그 메시지를 Log_List에 추가 
            Log_List.Items.Add(logMessage);
    
            // 가장 최근 로그가 보이도록 스크롤 이동   
            Log_List.TopIndex = Log_List.Items.Count - 1;
        }

        private void InitializeDAQ()
        {
            aiTask = new NationalInstruments.DAQmx.Task();
            //aiTask.AIChannels.CreateVoltageChannel("Dev2/ai0", "", AITerminalConfiguration.Rse, 0.0, 10.0, AIVoltageUnits.Volts);
            aiReader = new AnalogSingleChannelReader(aiTask.Stream);
            //aiTask.Timing.ConfigureSampleClock("", 2000, SampleClockActiveEdge.Rising, SampleQuantityMode.FiniteSamples, 200);
        }

        /*private void ReadMultiSampleData()
        {
            try
            {
                double[] voltages = aiReader.ReadMultiSample(200);
                double voltageAvg = voltages.Average();
                AiCurrentAvg = ((5.0 / supplyVoltage) * voltageAvg - offsetVoltage) * (-1.0 / sensitivity);
            }
            catch (DaqException ex)
            {
                MessageBox.Show("Error reading DAQ data: " + ex.Message);
            }
        }*/
    }
}
