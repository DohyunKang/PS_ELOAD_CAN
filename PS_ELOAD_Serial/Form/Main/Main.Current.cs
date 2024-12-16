using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;

namespace PS_ELOAD_Serial
{
    public partial class Main : Form
    {
        private TPCANHandle canHandle = PCANBasic.PCAN_USBBUS1;

        private System.Threading.Timer canReadTimer; // CAN 데이터 수신 타이머
        private System.Windows.Forms.Timer saveDataTimer; // 10ms 간격으로 로그 저장
        private System.Windows.Forms.Timer displayUpdateTimer; // 500ms 간격으로 디스플레이 업데이트

        private Queue<string> dataQueue = new Queue<string>(); // 데이터를 저장할 큐
        private ulong lastReceivedTimestamp = 0; // 마지막 수신 타임스탬프 저장

        private string latestLogEntry = null;

        private void InitializeCAN()
        {
            TPCANStatus status = PCANBasic.Initialize(canHandle, TPCANBaudrate.PCAN_BAUD_500K);
            if (status != TPCANStatus.PCAN_ERROR_OK)
            {
                MessageBox.Show("CAN 초기화 실패: " + status.ToString());
            }

            // CAN 데이터 수신 타이머 설정 (5ms)
            canReadTimer = new System.Threading.Timer(CanReadTimer_Tick, null, 0, 5);

            // 로그 저장 타이머 설정 (10ms)
            saveDataTimer = new System.Windows.Forms.Timer();
            saveDataTimer.Interval = 10;
            saveDataTimer.Tick += SaveLogTimer_Tick;
            saveDataTimer.Start();

            // 디스플레이 업데이트 타이머 설정 (500ms)
            displayUpdateTimer = new System.Windows.Forms.Timer();
            displayUpdateTimer.Interval = 500;
            displayUpdateTimer.Tick += DisplayUpdateTimer_Tick;
            displayUpdateTimer.Start();
        }

        private void CanReadTimer_Tick(object state)
        {
            TPCANMsg message;
            TPCANTimestamp timestamp;

            TPCANStatus status = PCANBasic.Read(canHandle, out message, out timestamp);
            if (status == TPCANStatus.PCAN_ERROR_OK)
            {
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                // TPCANTimestamp를 마이크로초 단위로 계산
                ulong currentTimestampMicros = (ulong)(timestamp.millis * 1000 + timestamp.micros);

                int period = (int)(currentTimestampMicros - lastReceivedTimestamp) / 1000;

                // 데이터 문자열 생성
                string dataString = BitConverter.ToString(message.DATA, 0, message.LEN);
                string logEntry = string.Format(currentTime + " | ID: {0:X}, Len: {1}, Data: {2}, Period: {3} ms",
                                                message.ID, message.LEN, dataString, period);

                // 큐에 데이터 추가
                lock (dataQueue)
                {
                    dataQueue.Enqueue(logEntry);
                }

                // 타임스탬프 갱신
                lastReceivedTimestamp = currentTimestampMicros;
            }
        }

        private void SaveLogTimer_Tick(object sender, EventArgs e)
        {
            // 지정된 로그 파일 경로
            string folderPath = @"C:\Users\kangdohyun\Desktop\세미나\강도현\7주차\CAN Log";
            string cab500DataFilePath = Path.Combine(folderPath, "CAB500_DATA.txt");

            // 폴더가 존재하지 않으면 생성
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            lock (dataQueue)
            {
                if (dataQueue.Count > 0)
                {
                    using (StreamWriter writer = new StreamWriter(cab500DataFilePath, true))
                    {
                        while (dataQueue.Count > 0)
                        {
                            string logEntry = dataQueue.Dequeue();
                            writer.WriteLine(logEntry);

                            // 마지막으로 기록된 로그를 latestLogEntry에 저장
                            latestLogEntry = logEntry;
                        }
                    }
                }
            }
        }

        private void DisplayUpdateTimer_Tick(object sender, EventArgs e)
        {
            // 지정된 로그 파일 경로
            string folderPath = @"C:\Users\kangdohyun\Desktop\세미나\강도현\7주차\CAN Log";
            string canLogFilePath = Path.Combine(folderPath, "CANLog.txt");

            // 폴더가 존재하지 않으면 생성
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // 버퍼 지우기
            PCANBasic.Reset(canHandle);

            // CANLog.txt에 최신 로그 저장
            if (!string.IsNullOrEmpty(latestLogEntry))
            {
                using (StreamWriter writer = new StreamWriter(canLogFilePath, true))
                {
                    writer.WriteLine(latestLogEntry);
                }

                // 최신 로그 데이터를 디스플레이 및 그래프에 반영
                UpdateDisplay(latestLogEntry);
            }
        }

        private void UpdateDisplay(string logEntry)
        {
            // 디스플레이에 마지막 데이터 업데이트
            if (CanList.InvokeRequired) // UI 스레드가 아닌 경우
            {
                CanList.Invoke(new Action(() =>
                {
                    CanList.Items.Add(logEntry);
                    if (CanList.Items.Count > 100) // 항목 개수 제한
                    {
                        CanList.Items.RemoveAt(0);
                    }

                    // 스크롤을 마지막 항목으로 이동
                    CanList.TopIndex = CanList.Items.Count - 1;
                }));
            }
            else // UI 스레드인 경우
            {
                CanList.Items.Add(logEntry);
                if (CanList.Items.Count > 100)
                {
                    CanList.Items.RemoveAt(0);
                }

                CanList.TopIndex = CanList.Items.Count - 1;
            }

            // 그래프에 데이터 업데이트 (전류 값 추출 후 반영)
            double currentValue = ExtractCurrentValueFromLog(logEntry);
            UpdateCurrentValue(currentValue);
        }

        private double ExtractCurrentValueFromLog(string logEntry)
        {
            // 로그 문자열에서 전류 값을 추출 (예: "Data: XX-XX-XX-XX")
            try
            {
                string[] parts = logEntry.Split(',');
                foreach (string part in parts)
                {
                    if (part.Trim().StartsWith("Data:"))
                    {
                        string dataHex = part.Split(':')[1].Trim();
                        string[] bytes = dataHex.Split('-');

                        // 전류 데이터는 첫 4바이트 기준으로 계산
                        byte[] currentBytes = bytes.Take(4).Select(b => Convert.ToByte(b, 16)).ToArray();

                        // Big-Endian에서 Little-Endian으로 변환
                        byte[] reversedData = currentBytes.Reverse().ToArray();

                        // 부호 있는 32비트 정수로 변환
                        int rawValue = BitConverter.ToInt32(reversedData, 0);

                        // 오프셋 적용 (예: 기본값이 0x80000000 = -2147483648인 경우)
                        int offset = unchecked((int)0x80000000); // 기본 오프셋
                        rawValue = unchecked(rawValue - offset);

                        // 스케일링: 0.1mA 단위 -> A로 변환
                        return rawValue * 0.001; // 0.1mA -> A로 변환
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error extracting current value: " + ex.Message);
            }

            return 0.0; // 오류 시 기본값 반환
        }

        private void UpdateCurrentValue(double currentValue)
        {
            if (lblCurrent_CAB.InvokeRequired)
            {
                lblCurrent_CAB.Invoke(new Action(() =>
                {
                    lblCurrent_CAB.Text = currentValue.ToString("F2") + " A";
                    waveformPlot_A5.PlotYAppend(currentValue, 0.5);
                }));
            }
            else
            {
                lblCurrent_CAB.Text = currentValue.ToString("F2") + " A";
                waveformPlot_A5.PlotYAppend(currentValue, 0.5);
            }
        }
    }
}
