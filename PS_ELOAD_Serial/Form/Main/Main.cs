﻿﻿using System;
using System.IO.Ports;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using NationalInstruments.UI;
using NationalInstruments.UI.WindowsForms;
using Action = System.Action; // System.Action으로 명시
using System.Data.SqlServerCe;
using System.Collections.Generic;

using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;
using Timer = System.Windows.Forms.Timer;

namespace PS_ELOAD_Serial
{
    public partial class Main : Form
    {
        private SerialPort serialPort; // ELoad 시리얼 포트 객체
        private TcpClient psClient; // PowerSupply TCP 클라이언트 객체
        private NetworkStream psStream; // PowerSupply 네트워크 스트림 객체
        private StreamReader reader;
        private StreamWriter writer;
        private bool isConnected = false; // ELoad 연결 상태를 확인하기 위한 변수
        private bool psConnected = false; // PowerSupply 연결 상태를 확인하기 위한 변수
        private bool isGraphUpdating = false; // 그래프 업데이트 여부 확인 변수 (추가)
        private bool isGraphUpdating2 = false; // 그래프 업데이트 여부 확인 변수 (추가)
        private readonly object _commandLock = new object(); // 명령어 전송을 위한 Lock 객체

        private double voltageValue;
        private double currentValue;
        private bool isVoltageRequest = true;  // 현재 요청이 전압인지 전류인지 확인하기 위한 플래그

        private double result;
        private bool isParameterButtonToggled = false;  // 버튼 상태를 저장할 변수
        private bool isSequenceRunning = false; // 시퀀스 실행 상태를 저장하는 변수

        private System.Windows.Forms.Timer psDataTimer; // Windows Forms Timer
        private System.Windows.Forms.Timer eLoadDataTimer; // ELoad 데이터 타이머
        private double elapsedTime; // ps그래프의 시간 흐름을 나타내는 변수
        private double elapsedTime2; // el그래프의 시간 흐름을 나타내는 변수

        private DateTime lastPsUpdateTime = DateTime.Now;
        private DateTime lastEloadUpdateTime = DateTime.Now;

        private string currentMode; // 현재 모드 상태 저장 (CC, CV, CR 중 하나)

        // Sequence 창을 열기 위한 Delegate 정의
        public Action OpenSequenceDelegate;

        // Sequence2 창을 열기 위한 Delegate 정의
        public Action OpenSequenceDelegate2;

        public int SelectedProgramID { get; private set; } // 선택된 ProgramID를 저장할 프로퍼티

        public Main()
        {
            InitializeComponent();
            InitializeDAQ();
        }

        private void EloadDataTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime2 = 0.5;

            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    // 전압 값 읽기
                    serialPort.WriteLine("MEAS:VOLT?");
                    LogCommand("ELoad TX", "MEAS:VOLT?"); // TX 로그 추가
                    string response = serialPort.ReadLine();
                    LogCommand("ELoad RX", response);
                    voltageValue = LimitValueRange(ParseScientificNotation(response), -10000, 10000);

                    BeginInvoke(new Action(() =>
                    {
                        lblVoltage.Text = voltageValue.ToString() + " V";

                        // 그래프 업데이트
                        waveformPlot_V.PlotYAppend(voltageValue, elapsedTime2);
                    }));
                }
                catch (TimeoutException ex)
                {
                    MessageBox.Show("시리얼 포트 데이터 수신 시간이 초과되었습니다: " + ex.Message, "오류");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터 수신 실패: " + ex.Message, "오류");
                }
            }
            else
            {
                eLoadDataTimer.Stop();
                //MessageBox.Show("ELoad 시리얼 포트가 연결되지 않았습니다.", "오류");
            }

            if (psConnected)
            {
                try
                {
                    // 전압 값 읽기
                    string psVoltage = ReadResponseFromPS("MEAS:VOLT?");
                    LogCommand("PowerSupply TX", "MEAS:VOLT?"); // TX 로그 추가
                    double voltageValue;
                    if (double.TryParse(psVoltage, out voltageValue))
                    {
                        lblPV.Text = string.Format("{0} V", voltageValue);
                        waveformPlot_V2.PlotYAppend(voltageValue, elapsedTime2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Power Supply 데이터 읽기 실패: " + ex.Message, "오류");
                }
            }
        }

        private void PsDataTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime = 0.5;

            //System.Diagnostics.Debug.WriteLine(string.Format("시작{0}"), DateTime.Now);
            if (psConnected)
            {
                try
                {
                    // 전류 값 읽기
                    string psCurrent = ReadResponseFromPS("MEAS:CURR?");
                    LogCommand("PoswerSupply TX", "MEAS:CURR?"); // TX 로그 추가
                    double currentValue;
                    if (double.TryParse(psCurrent, out currentValue))
                    {
                        lblPC.Text = string.Format("{0} A", currentValue);
                        waveformPlot_A2.PlotYAppend(currentValue, elapsedTime);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Power Supply 데이터 읽기 실패: " + ex.Message, "오류");
                }
            }

            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    // 전류 값 읽기
                    serialPort.WriteLine("MEAS:CURR?");
                    LogCommand("ELoad TX", "MEAS:CURR?"); // TX 로그 추가
                    string response = serialPort.ReadLine();
                    LogCommand("ELoad RX", response);
                    currentValue = LimitValueRange(ParseScientificNotation(response), -10000, 10000);

                    BeginInvoke(new Action(() =>
                    {
                        lblCurrent.Text = currentValue.ToString() + " A";

                        waveformPlot_A.PlotYAppend(currentValue, elapsedTime);
                    }));
                }
                catch (TimeoutException ex)
                {
                    MessageBox.Show("시리얼 포트 데이터 수신 시간이 초과되었습니다: " + ex.Message, "오류");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터 수신 실패: " + ex.Message, "오류");
                }
            }
            else
            {
                eLoadDataTimer.Stop();
                //MessageBox.Show("ELoad 시리얼 포트가 연결되지 않았습니다.", "오류");
            }

            //System.Diagnostics.Debug.WriteLine(string.Format("끝{0}"), DateTime.Now);
        }

        // 과학적 표기법으로 표현된 값을 처리하는 메서드 (음수 값도 포함하여 처리)
        private double ParseScientificNotation(string value)
        {
            double result = 0.0;
            if (double.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out result))
            {
                return result;
            }
            else
            {
                //throw new FormatException("유효하지 않은 값: " + value);

                return 0.0;
            }
        }

        // 값의 범위를 제한하는 메서드 (오버플로 방지, 음수 값 허용)
        private double LimitValueRange(double value, double min, double max)
        {
            // 값이 최소값보다 작으면 최소값 반환, 최대값보다 크면 최대값 반환
            return Math.Max(min, Math.Min(value, max));
        }

        private void InitializeReaderWriter()
        {
            if (psStream != null && psStream.CanWrite && psStream.CanRead)
            {
                reader = new StreamReader(psStream, Encoding.ASCII);
                writer = new StreamWriter(psStream, Encoding.ASCII) { AutoFlush = true };
            }
        }

        // COM 포트 목록을 가져와 comboBox1에 나열하는 메서드
        private void GetSerialPortList()
        {
            comboBox1.Items.Clear(); // 기존 아이템 초기화
            string[] ports = SerialPort.GetPortNames(); // 사용 가능한 모든 COM 포트 가져오기
            comboBox1.Items.AddRange(ports); // COM 포트 목록 추가
        }

        // ModeButton 클릭 시 실행되는 이벤트 핸들러
        private void ModeButton_Click(object sender, EventArgs e)
        {
            // Delegate가 null이 아니면 호출하여 창을 엶
            OpenSequenceDelegate.Invoke();
        }

        // Sequence 창을 여는 메서드 (Delegate에 연결)
        private void OpenSequenceWindow()
        {
            // Sequence 창을 SerialPort와 함께 열기
            Sequence sequenceWindow = new Sequence(serialPort);
            sequenceWindow.ShowDialog(); // ShowDialog()를 사용하여 모달 창으로 엶
            //MessageBox.Show("Sequence 창이 열렸습니다.");
        }

        // ELoad 스위치 상태가 변경될 때의 이벤트 처리 메서드
        private void Switch1_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (switch1.Value)
            {
                // 스위치가 켜질 때 연결 시도
                ConnectToSelectedPort();
            }
            else
            {
                // 스위치가 꺼질 때 연결 해제
                eLoadDataTimer.Stop();
                DisconnectPort();
            }
        }

        private void Switch2_StateChanged(object sender, NationalInstruments.UI.ActionEventArgs e)
        {
            if (switch2.Value)
            {
                ConnectToPowerSupply();  // PowerSupply 연결 시도
                //GetAndShowPSMeasurements();  // PowerSupply 측정 값 가져오기
            }
            else
            {
                //DisconnectPowerSupply();  // 연결 해제
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            lock (_commandLock) // 명령어 전송 시 동기화
            {
                if (psConnected && switch2.Value)
                {
                    double voltage = (double)PSVoltage.Value;
                    double current = (double)PSCurrent.Value;

                    // 전압 및 전류 설정 명령어 동기 전송
                    SendCommandToPS("VOLT " + voltage.ToString("F2"));
                    SendCommandToPS("CURR " + current.ToString("F2"));

                    // 하드웨어에서 설정 값 확인 후 업데이트
                    UpdatePSStatus();
                }
                else
                {
                    //MessageBox.Show("Power Supply가 연결되지 않았거나 스위치가 꺼져 있습니다.", "설정 오류");
                }
            }
        }

        // ApplyButton2 클릭 이벤트 핸들러 (이 메서드는 Form1.cs에 추가하세요)
        private void ApplyButton2_Click(object sender, EventArgs e)
        {
            lock (_commandLock) // 명령어 전송 시 동기화
            {
                if (psConnected && switch2.Value)
                {
                    // OVP와 OCP 값을 NumericUpDown 컨트롤에서 가져오기
                    double ovpValue = (double)PSOVP.Value;
                    double ocpValue = (double)PSOCP.Value;

                    if (ovpValue >= 10.65 && ovpValue <= 33.6 && ocpValue >= 15 && ocpValue <= 168)
                    {
                        // Power Supply에 OVP와 OCP 설정 명령어 전송
                        SendCommandToPS("VOLT:PROT " + ovpValue.ToString("F2"));
                        SendCommandToPS("CURR:PROT " + ocpValue.ToString("F2"));

                        // 설정이 적용되었는지 확인하기 위해 하드웨어의 실제 값을 읽어옴
                        string currentOVPValue = SendCommandAndReadResponse("VOLT:PROT?");
                        string currentOCPValue = SendCommandAndReadResponse("CURR:PROT?");

                        // 하드웨어에서 읽어온 OVP와 OCP 값을 라벨에 표시
                        lblOVP.Invoke(new System.Action(() => lblOVP.Text = currentOVPValue + " V"));
                        lblOCP.Invoke(new System.Action(() => lblOCP.Text = currentOCPValue + " A"));
                    }
                    else
                    {
                        //MessageBox.Show("OVP와 OCP 설정 범위를 넘어섰습니다.", "설정 오류");
                    }
                }
                else
                {
                    //MessageBox.Show("Power Supply가 연결되지 않았거나 스위치가 꺼져 있습니다.", "설정 오류");
                }
            }
        }

        private void ApplyButton3_Click(object sender, EventArgs e)
        {/*
            // Switch1이 ON 상태인지 확인
            if (switch1.Value)
            {
                try
                {
                    // NumericUpDown 컨트롤에서 설정한 주기 값을 가져와서 타이머에 적용
                    int period = (int)periodNumeric.Value; // periodNumeric은 주기를 설정하는 NumericUpDown 컨트롤
                    eLoadDataTimer.Interval = period;

                    // 타이머 시작 (이미 시작된 경우에도 재시작)
                    if (!eLoadDataTimer.Enabled)
                    {
                        eLoadDataTimer.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("설정 적용 실패: " + ex.Message, "오류");
                }
            }
            else
            {
                // Switch1이 ON 상태가 아니면 경고 메시지 표시
                MessageBox.Show("ELoad가 연결되지 않았거나 Switch1이 OFF 상태입니다.", "설정 오류");
            }*/
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            // Switch1(Switch가 켜져 있는지 확인)
            if (switch1.Value) // switch1.Value가 True면 스위치가 켜져 있는 상태
            {
                try
                {
                    // 현재 Load 상태 확인 및 반전
                    if (E_LED.Value) // 현재 Load가 켜져 있는 상태라면
                    {
                        // Load 끄기 명령어 전송 (ELoad의 연결이 되어 있어야 함)
                        if (serialPort != null && serialPort.IsOpen)
                        {
                            serialPort.WriteLine("OUTP OFF");
                            LogCommand("ELoad TX", "OUTP OFF");
                        }

                        // LED 및 메시지 표시
                        E_LED.Value = false;
                    }
                    else // 현재 Load가 꺼져 있는 상태라면
                    {
                        // Load 켜기 명령어 전송 (ELoad의 연결이 되어 있어야 함)
                        if (serialPort != null && serialPort.IsOpen)
                        {
                            //serialPort.WriteLine("INP ON");
                            serialPort.WriteLine("OUTP ON");
                            LogCommand("ELoad TX", "OUTP ON");
                        }

                        // LED 및 메시지 표시
                        E_LED.Value = true;
                    }
                }
                catch (Exception ex)
                {
                    // 예외 처리 (시리얼 통신 에러 등)
                    MessageBox.Show("ELoad Load 상태 전환 실패: " + ex.Message, "오류");
                }
            }
            else
            {
                // Switch1이 OFF 상태일 때 경고 메시지 표시
                //MessageBox.Show("ELoad가 연결되지 않았습니다. Switch1을 켜세요.", "Load 제어 오류");
            }
        }

        // Output 버튼 클릭 이벤트 핸들러
        private void OutPutButton_Click(object sender, EventArgs e)
        {
            lock (_commandLock)
            {
                if (psConnected && switch2.Value)
                {
                    // 현재 Power Supply의 출력 상태 확인
                    string response = SendCommandAndReadResponse("OUTP?");

                    // 출력을 켜고 끌지 결정하기 위한 플래그 변수
                    bool isOutputOn = (response.Trim() == "1");

                    if (isOutputOn) // 현재 출력이 켜져 있다면
                    {
                        // 출력 끄기 명령 전송
                        SendCommandToPS("OUTP 0\r");
                        PS_LED.Value = false;
                        //psDataTimer.Stop(); // 타이머 중지
                        //isGraphUpdating2 = false;
                    }
                    else // 현재 출력이 꺼져 있다면
                    {
                        // 출력 켜기 명령 전송
                        SendCommandToPS("OUTP 1\r");
                        PS_LED.Value = true;
                        //psDataTimer.Start(); // 타이머 시작
                        //isGraphUpdating2 = true;
                    }
                }
                else
                {
                    //MessageBox.Show("Power Supply가 연결되지 않았거나 스위치가 꺼져 있습니다.", "설정 오류");
                }
            }
        }

        // ELoad COM 포트에 연결하는 메서드 추가
        private void ConnectToSelectedPort()
        {
            if (comboBox1.SelectedItem != null && !isConnected)
            {
                try
                {
                    // ELoad 시리얼 포트 설정
                    serialPort = new SerialPort(comboBox1.SelectedItem.ToString(), 19200, Parity.None, 8, StopBits.One);
                    serialPort.Open();
                    isConnected = true; // 연결 상태 업데이트
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ELoad 연결 실패: " + ex.Message, "연결 상태");
                }
            }
            else if (isConnected)
            {
                //MessageBox.Show("이미 ELoad에 연결된 상태입니다.", "연결 상태");
            }
            else
            {
                // MessageBox.Show("COM 포트를 선택하세요.", "연결 상태");
            }
        }

        // ELoad 시리얼 포트 연결 해제 메서드 추가
        private void DisconnectPort()
        {
            if (serialPort != null && isConnected)
            {
                try
                {
                    serialPort.Close(); // 포트 닫기
                    isConnected = false; // 연결 상태 업데이트
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ELoad 연결 해제 실패: " + ex.Message, "연결 상태");
                }
            }
            else
            {
                //MessageBox.Show("ELoad가 연결되지 않았습니다.", "연결 상태");
            }
        }

        private void ELoadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort != null && isConnected)
            {
                RadioButton selectedButton = sender as RadioButton;
                if (selectedButton != null && selectedButton.Checked)
                {
                    string command = "";
                    string command2 = "";

                    // CC 모드 선택 시 CCMode 폼을 열기
                    if (selectedButton == CCButton)
                    {
                        command = "FUNC CC"; // CC 모드 설정 명령어
                        command2 = "FUNC:CVOP OFF"; // +CV 모드 OFF
                        currentMode = "CC"; // CC 모드 설정
                        try
                        {
                            serialPort.WriteLine(command); // 명령어를 ELoad로 전송
                            LogCommand("ELoad TX", command);
                            serialPort.WriteLine(command2); // 명령어를 ELoad로 전송
                            LogCommand("ELoad TX", command2);

                            // CC 모드가 선택되었을 때 CCMode 폼을 열기
                            CCMode ccModeForm = new CCMode(serialPort);
                            DialogResult ccResult = ccModeForm.ShowDialog();

                            // 사용자가 OK 버튼을 클릭했을 때만 설정값을 적용
                            if (ccResult == DialogResult.OK)
                            {
                                // CCMode에서 설정한 값들을 가져와서 명령어로 변환
                                string currentValue = ccModeForm.CurrentValue;
                                string opplValue = ccModeForm.OPPLValue;
                                string uvpValue = ccModeForm.UVPValue;
                                string SLEWrateValue = ccModeForm.SLEWrateValue; // 유도성 값

                                // 시리얼 포트를 통해 설정 값 전송 (널 값이 아닐 경우에만 전송)
                                if (!string.IsNullOrEmpty(currentValue))
                                {
                                    SendCommandToELoad("CURR " + currentValue); // 전류 값 전송
                                }

                                if (!string.IsNullOrEmpty(SLEWrateValue))
                                {
                                    SendCommandToELoad("CURRent:SLEWrate " + SLEWrateValue); // SLEW 율 전송
                                }

                                if (!string.IsNullOrEmpty(uvpValue))
                                {
                                    SendCommandToELoad("VOLT:PROT:LOW " + uvpValue); // UVP 값 전송
                                }

                                if (!string.IsNullOrEmpty(opplValue))
                                {
                                    SendCommandToELoad("POW:PROT " + opplValue); // OPPL 값 전송
                                }

                                // +CV 모드가 활성화된 경우 전압 값도 전송
                                if (!string.IsNullOrEmpty(ccModeForm.VoltageValue))
                                {
                                    SendCommandToELoad("VOLT " + ccModeForm.VoltageValue);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("명령 전송 실패: " + ex.Message, "모드 설정 오류");
                        }
                    }
                    else if (selectedButton == CVButton)
                    {
                        command = "FUNC CV"; // CV 모드 설정 명령어
                        currentMode = "CV"; // CV 모드 설정
                        try
                        {
                            serialPort.WriteLine(command); // 명령어를 ELoad로 전송
                            LogCommand("ELoad TX", command);

                            // CV 모드가 선택되었을 때 CVMode 폼을 열기
                            CVMode cvModeForm = new CVMode();
                            DialogResult cvResult = cvModeForm.ShowDialog();

                            // 사용자가 OK 버튼을 클릭했을 때만 설정값을 적용
                            if (cvResult == DialogResult.OK)
                            {
                                // CVMode에서 설정한 값들을 가져와서 명령어로 변환
                                string voltageValue = cvModeForm.VoltageValue;
                                string uvpValue = cvModeForm.UVPValue;
                                string ocplValue = cvModeForm.OCPLValue;
                                string opplValue = cvModeForm.OPPLValue;

                                // 시리얼 포트를 통해 설정 값 전송 (널 값이 아닐 경우에만 전송)
                                if (!string.IsNullOrEmpty(voltageValue))
                                {
                                    SendCommandToELoad("VOLT " + voltageValue); // 전압 값 전송
                                }

                                if (!string.IsNullOrEmpty(uvpValue))
                                {
                                    SendCommandToELoad("VOLT:PROT:LOW " + uvpValue); // UVP 값 전송
                                }

                                if (!string.IsNullOrEmpty(ocplValue))
                                {
                                    SendCommandToELoad("CURR:PROT " + ocplValue); // OCPL 값 전송
                                }

                                if (!string.IsNullOrEmpty(opplValue))
                                {
                                    SendCommandToELoad("POW:PROT " + opplValue); // OPPL 값 전송
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("명령 전송 실패: " + ex.Message, "모드 설정 오류");
                        }
                    }
                    else if (selectedButton == CRButton)
                    {
                        command = "FUNC CR"; // CR 모드 설정 명령어
                        command2 = "FUNC:CVOP OFF"; // +CV 모드 OFF
                        currentMode = "CR"; // CR 모드 설정
                        try
                        {
                            serialPort.WriteLine(command); // 명령어를 ELoad로 전송
                            LogCommand("ELoad TX", command);
                            serialPort.WriteLine(command2); // 명령어를 ELoad로 전송
                            LogCommand("ELoad TX", command2);

                            // CR 모드가 선택되었을 때 CRMode 폼을 열기
                            CRMode crModeForm = new CRMode(serialPort);
                            DialogResult crResult = crModeForm.ShowDialog();

                            // 사용자가 OK 버튼을 클릭했을 때만 설정값을 적용
                            if (crResult == DialogResult.OK)
                            {
                                // CRMode에서 설정한 값들을 가져와서 명령어로 변환
                                string impedanceValue = crModeForm.ImpedanceValue;
                                string uvpValue = crModeForm.UVPValue;
                                string ocplValue = crModeForm.OCPLValue;
                                string opplValue = crModeForm.OPPLValue;

                                // 시리얼 포트를 통해 설정 값 전송 (널 값이 아닐 경우에만 전송)
                                if (!string.IsNullOrEmpty(impedanceValue))
                                {
                                    SendCommandToELoad("COND " + impedanceValue); // 임피던스 값 전송
                                }

                                if (!string.IsNullOrEmpty(uvpValue))
                                {
                                    SendCommandToELoad("VOLT:PROT:LOW " + uvpValue); // UVP 값 전송
                                }

                                if (!string.IsNullOrEmpty(ocplValue))
                                {
                                    SendCommandToELoad("CURR:PROT " + ocplValue); // OCPL 값 전송
                                }

                                if (!string.IsNullOrEmpty(opplValue))
                                {
                                    SendCommandToELoad("POW:PROT " + opplValue); // OPPL 값 전송
                                }

                                // +CV 모드가 활성화된 경우 전압 값도 전송
                                if (!string.IsNullOrEmpty(crModeForm.VoltageValue))
                                {
                                    SendCommandToELoad("VOLT " + crModeForm.VoltageValue);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("명령 전송 실패: " + ex.Message, "모드 설정 오류");
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("ELoad가 연결되지 않았습니다.", "모드 설정 오류");
            }
        }

        // ELoad에 명령어를 보내는 메서드
        private void SendCommandToELoad(string command)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine(command); // 시리얼 포트를 통해 명령어 전송
                LogCommand("ELoad TX", command);
            }
            else
            {
                //MessageBox.Show("ELoad가 연결되지 않았습니다.", "오류");
            }
        }

        private void DisconnectPowerSupply()
        {
            if (psClient != null && psConnected)
            {
                try
                {
                    psStream.Close();
                    psClient.Close();
                    psConnected = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PowerSupply 연결 해제 실패: " + ex.Message, "연결 상태");
                }
            }
            else
            {
                //MessageBox.Show("PowerSupply가 연결되지 않았습니다.", "연결 상태");
            }
        }

        // ConnectToPowerSupply 메서드에서 StreamReader 및 StreamWriter 초기화
        private void ConnectToPowerSupply()
        {
            if (!psConnected)
            {
                try
                {
                    // TCP 클라이언트 객체 초기화 및 PowerSupply IP와 포트 번호 설정
                    psClient = new TcpClient("192.168.1.71", 5025);
                    psStream = psClient.GetStream(); // 네트워크 스트림 생성
                    psConnected = true; // 연결 상태 업데이트

                    // StreamReader 및 StreamWriter 초기화
                    InitializeReaderWriter();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PowerSupply 연결 실패: " + ex.Message, "연결 상태");
                }
            }
            else
            {
                //MessageBox.Show("이미 PowerSupply에 연결된 상태입니다.", "연결 상태");
            }
        }


        private void SendCommandToPS(string command)
        {
            try
            {
                if (writer != null)
                {
                    writer.WriteLine(command);
                    LogCommand("PoswerSupply TX", command); // TX 로그 추가
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PowerSupply 명령어 전송 실패: " + ex.Message, "명령어 오류");
            }
        }

        private string SendCommandAndReadResponse(string command)
        {
            try
            {
                if (writer != null && reader != null)
                {
                    // 명령어 전송
                    writer.WriteLine(command);
                    LogCommand("PowerSupply TX", command); // TX 로그 추가

                    // 응답 읽기
                    string response = reader.ReadLine();
                    LogCommand("PowerSupply RX", response); // RX 로그 추가
                    return response.Trim() ?? string.Empty; // Trim() 호출 전 null 체크
                }
                else
                {
                    return string.Empty; // PS가 연결되지 않은 경우
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("명령어 전송 실패: " + ex.Message, "오류");
                return string.Empty;
            }
        }

        private void UpdatePSStatus()
        {
            // 현재 전압 읽기
            string voltage = ReadResponseFromPS("MEAS:VOLT?");
            lblPV.Invoke(new System.Action(() => lblPV.Text = voltage + " V"));

            // 현재 전류 읽기
            string current = ReadResponseFromPS("MEAS:CURR?");
            lblPC.Invoke(new System.Action(() => lblPC.Text = current + " A"));
        }

        private void GetAndShowPSMeasurements()
        {
            if (psStream != null && psConnected)
            {
                try
                {
                    // P/S 전압 측정
                    string psVoltage = ReadResponseFromPS("MEAS:VOLT?");
                    lblPV.Text = string.IsNullOrEmpty(psVoltage) ? "0" : psVoltage + " V";

                    // P/S 전류 측정
                    string psCurrent = ReadResponseFromPS("MEAS:CURR?");
                    lblPC.Text = string.IsNullOrEmpty(psCurrent) ? "0" : psCurrent + " A";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PowerSupply 측정 실패: " + ex.Message, "측정 오류");
                }
            }
            else
            {
                //MessageBox.Show("PowerSupply가 연결되지 않았습니다.", "측정 오류");
            }
        }

        private string ReadResponseFromPS(string command)
        {
            try
            {
                if (writer != null && reader != null)
                {
                    writer.WriteLine(command);
                    LogCommand("PowerSupply TX", command);
                    string response = reader.ReadLine();
                    LogCommand("PowerSupply RX", response);
                    return response.Trim() ?? "0"; // Trim() 호출 전 null 체크
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PS 상태 읽기 실패: " + ex.Message, "오류");
            }
            return "0"; // 읽기에 실패한 경우 0 반환
        }

        private void CRButton_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                // serialPort 객체를 생성자 인자로 전달하여 CRMode 창을 염
                CRMode crModeForm = new CRMode(serialPort);
            }
            else
            {
                //MessageBox.Show("ELoad가 연결되지 않았습니다.", "오류");
            }
        }

        private void CCButton_CheckedChanged(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                // serialPort 객체를 생성자 인자로 전달하여 CCMode 창을 염
                CCMode ccModeForm = new CCMode(serialPort);
            }
            else
            {
                //MessageBox.Show("ELoad가 연결되지 않았습니다.", "오류");
            }
        }

        //voltage button임
        private void ParameterButton_Click(object sender, EventArgs e)
        {
            // 버튼 상태를 토글
            isParameterButtonToggled = !isParameterButtonToggled;

            if (isParameterButtonToggled)
            {
                if (isConnected)  // 시리얼 연결이 성공한 경우에만 타이머 시작
                {
                    eLoadDataTimer.Start(); // 주기적으로 데이터 읽기 시작
                    isGraphUpdating = true;
                    VoltageButton.Text = "Off";
                }
                else
                {
                    //MessageBox.Show("시리얼 포트가 연결되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 타이머 중지
                eLoadDataTimer.Stop();
                VoltageButton.Text = "Voltage Current";
                isGraphUpdating = false;
            }
        }

        private void SequenceRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    if (!isSequenceRunning) // 시퀀스가 실행 중이지 않은 경우 실행
                    {
                        // 시퀀스 실행 명령어를 전송
                        serialPort.WriteLine("INIT:TRAN:PROG");  // Eload 명령어 형식에 맞춰 수정
                        LogCommand("ELoad TX", "INIT:TRAN:PROG");
                        // 상태 업데이트
                        isSequenceRunning = true;
                        SequenceRun.Text = "Stop Sequence";  // 버튼 텍스트 변경
                    }
                    else // 시퀀스가 이미 실행 중인 경우 중지
                    {
                        // 시퀀스 중지 명령어를 전송
                        serialPort.WriteLine("ABOR");  // Eload 명령어 형식에 맞춰 수정
                        LogCommand("ELoad TX", "ABOR");
                        // 상태 업데이트
                        isSequenceRunning = false;
                        SequenceRun.Text = "Start Sequence";  // 버튼 텍스트 변경
                        //MessageBox.Show("Sequence 모드가 중지되었습니다.", "Sequence 중지");
                    }
                }
                else
                {
                    //MessageBox.Show("시리얼 포트가 열려 있지 않습니다.", "포트 오류");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sequence 모드 실행/중지 중 오류 발생: " + ex.Message, "오류");
            }
        }


        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // PowerSupply 출력 끄기
            SendCommandToPS("OUTP 0\r");
            LogCommand("PowerSupply TX", "OUTP 0\r");

            // Load 끄기 명령어 전송 (ELoad의 연결이 되어 있어야 함)
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.WriteLine("OUTP OFF");
                LogCommand("ELoad TX", "OUTP OFF");
            }
            else
            {
                //MessageBox.Show("모든 장비의 전원을 끄기 위해 시리얼을 연결해주세요.");
            }
        }

        private void CurrentButton_Click(object sender, EventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    // 출력을 켜고 끌지 결정하기 위한 플래그 변수
                    bool isCurrentOn = (CurrentButton.Text.Trim() == "Off");

                    if (isCurrentOn) // 현재 버튼이 눌린 상태
                    {
                        psDataTimer.Stop(); // 타이머 중지
                        canReadTimer.Stop();

                        PCANBasic.Uninitialize(canHandle); // CAN 종료

                        CurrentButton.Text = "Current Load";
                    }
                    else // 현재 버튼이 꺼진 상태
                    {
                        lastPsUpdateTime = DateTime.Now; // 타이머 재시작 시점을 현재 시간으로 설정
                        psDataTimer.Start(); // 타이머 시작

                        InitializeCAN();
                        canReadTimer.Start(); 

                        CurrentButton.Text = "Off";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터 수신 실패: " + ex.Message, "오류");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sequence2.Plots[0].ClearData(); // waveformGraph1의 첫 번째 플롯 초기화
                Sequence2.Plots[1].ClearData(); // waveformGraph1의 두 번째 플롯 초기화 
            }
            catch (Exception ex)
            {
                MessageBox.Show("waveformGraph1 초기화 중 오류가 발생했습니다: " + ex.Message, "오류");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                waveformGraph2.Plots[0].ClearData(); // waveformGraph2의 첫 번째 플롯 초기화
                waveformGraph2.Plots[1].ClearData(); // waveformGraph2의 두 번째 플롯 초기화
                waveformGraph2.Plots[2].ClearData(); // waveformGraph2의 세 번째 플롯 초기화 
            }
            catch (Exception ex)
            {
                MessageBox.Show("waveformGraph2 초기화 중 오류가 발생했습니다: " + ex.Message, "오류");
            }
        }

        private void ModeButton2_Click(object sender, EventArgs e)
        {
            // Delegate가 null이 아니면 호출하여 Sequence2 창을 엶
            OpenSequenceDelegate2.Invoke();
        }

        // Sequence2 창을 여는 메서드 (Delegate에 연결)
        private void OpenSequenceWindow2()
        {
            // Sequence2 창을 SerialPort와 함께 열기
            Sequence2 sequenceWindow = new Sequence2(this, serialPort);
            // Sequence2 폼을 열 때 Main 인스턴스를 전달
            sequenceWindow.ShowDialog(); // ShowDialog()를 사용하여 모달 창으로 엶
        }

        private async void SequenceRun2_Click(object sender, EventArgs e)
        {
            if (SelectedProgramID != -1)
            {
                sequenceSteps = GetSequenceStepsFromDatabase(SelectedProgramID); // 해당 ProgramID에 맞는 시퀀스 단계만 가져옴
                if (sequenceSteps.Count > 0)
                {
                    MessageBox.Show(string.Format("루프가 '{0}'로 설정되었습니다.", loopCount));
                    await StartSequenceAsync(); // 시퀀스 실행
                }
                else
                {
                    MessageBox.Show("선택한 프로그램에 대한 시퀀스 단계가 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("선택된 프로그램이 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sequence2에서 ProgramID를 받을 이벤트 핸들러
        public void SetSelectedProgramID(int programID)
        {
            SelectedProgramID = programID;
        }

        private void textBoxLoop2_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxLoop2.Text, out loopCount))
            {
                MessageBox.Show("유효하지 않은 루프 값입니다.");
                loopCount = 1; // 기본값 설정 (필요에 따라 조정)
            }
        }

        /*private void Main_Load(object sender, EventArgs e)
        {

        }*/
    }
}