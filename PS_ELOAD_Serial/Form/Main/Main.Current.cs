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

using Peak.Can.Basic;
using TPCANHandle = System.UInt16;
using TPCANBitrateFD = System.String;
using TPCANTimestampFD = System.UInt64;

namespace PS_ELOAD_Serial
{
    public partial class Main : Form
    {
       private TPCANHandle canHandle = PCANBasic.PCAN_USBBUS1;

        private Timer canReadTimer;
        private DateTime lastReceivedTime = DateTime.Now; // 마지막 데이터 수신 시간을 저장

        private void InitializeCAN()
        {
            TPCANStatus status = PCANBasic.Initialize(canHandle, TPCANBaudrate.PCAN_BAUD_500K);
            if (status != TPCANStatus.PCAN_ERROR_OK)
            {
                MessageBox.Show("CAN 초기화 실패: " + status.ToString());
            }

            // Timer 초기화
            canReadTimer = new Timer();
            canReadTimer.Interval = 500; // 500ms 간격
            canReadTimer.Tick += CanReadTimer_Tick;
        }

        private double DecodeCurrentValue(TPCANMsg message)
        {
            if (message.ID == 0x3C2) // CAB 500 센서 CAN ID
            {
                try
                {
                    // 큐를 비워 기존 메시지를 삭제
                    PCANBasic.Reset(canHandle);

                    // CAN 데이터 상위 4바이트 추출
                    byte[] currentBytes = message.DATA.Take(4).ToArray();

                    // Big-Endian에서 Little-Endian으로 변환
                    byte[] reversedData = currentBytes.Reverse().ToArray();

                    // 부호 있는 32비트 정수로 변환
                    int rawValue = BitConverter.ToInt32(reversedData, 0);

                    // 오프셋 적용 (예: 기본값이 0x80000000 = -2147483648인 경우)
                    int offset = unchecked((int)0x80000000); // 기본 오프셋
                    rawValue = unchecked(rawValue - offset);

                    // 스케일링: 0.1mA 단위 -> A로 변환
                    double currentValue = rawValue * 0.001; // 0.1mA -> A로 변환
                    Console.WriteLine("Raw Value: {0}, Offset Applied: {1}, Scaled Value: {2} A",
                                      rawValue + offset, rawValue, currentValue);

                    return currentValue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error decoding current value: " + ex.Message);
                    return 0.0;
                }
            }
            return 0.0;
        }

        private void UpdateCurrentValue(double currentValue)
        {
            // UI 스레드에서 작업 수행
            if (lblCurrent_CAB.InvokeRequired) // UI 스레드가 아닌 경우
            {
                lblCurrent_CAB.Invoke(new System.Action(() =>
                {
                    lblCurrent_CAB.Text = currentValue.ToString("F2") + " A";

                    waveformPlot_A5.PlotYAppend(currentValue, 0.1);
                }));
            }
            else // UI 스레드인 경우 바로 작업
            {
                lblCurrent_CAB.Text = currentValue.ToString("F2") + " A";

                waveformPlot_A5.PlotYAppend(currentValue, 0.5);
            }
        }

        private void UpdateCANData(TPCANMsg message, int period)
        {
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string dataString = BitConverter.ToString(message.DATA, 0, message.LEN);
            string displayText = currentTime + " ID: " + message.ID.ToString("X") + ", Len: " + message.LEN +
                                 ", Data: " + dataString + ", Period: " + period + " ms";

            // 로그를 텍스트 파일에 저장
            SaveLogToFile(displayText);

            if (CanList.InvokeRequired) // UI 스레드가 아닌 경우
            {
                CanList.Invoke(new System.Action(() =>
                {
                    CanList.Items.Add(displayText);
                    if (CanList.Items.Count > 100) // 항목 개수 제한
                    {
                        CanList.Items.RemoveAt(0);
                    }

                    // 스크롤을 마지막 항목으로 이동
                    CanList.TopIndex = CanList.Items.Count - 1;
                }));
            }
            else // UI 스레드인 경우 바로 작업
            {
                CanList.Items.Add(displayText);
                if (CanList.Items.Count > 100) // 항목 개수 제한
                {
                    CanList.Items.RemoveAt(0);
                }

                // 스크롤을 마지막 항목으로 이동
                CanList.TopIndex = CanList.Items.Count - 1;
            }
        }

        // 로그를 텍스트 파일에 저장하는 메서드
        private void SaveLogToFile(string log)
        {
            try
            {
                // 지정된 로그 파일 경로
                string folderPath = @"C:\Users\kangdohyun\Desktop\세미나\강도현\7주차\CAN Log";
                string logFilePath = Path.Combine(folderPath, "CANLog.txt");

                // 폴더가 존재하지 않으면 생성
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // 로그 내용을 파일에 추가
                File.AppendAllText(logFilePath, log + Environment.NewLine);

                Console.WriteLine("로그 저장 성공: " + logFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("로그 저장 중 오류 발생: " + ex.Message);
            }
        }

        private void CanReadTimer_Tick(object sender, EventArgs e)
        {
            TPCANMsg message;
            TPCANTimestamp timestamp;

            TPCANStatus status = PCANBasic.Read(canHandle, out message, out timestamp);
            if (status == TPCANStatus.PCAN_ERROR_OK)
            {
                DateTime currentTime = DateTime.Now;
                int period = (int)(currentTime - lastReceivedTime).TotalMilliseconds;
                lastReceivedTime = currentTime;

                double currentValue = DecodeCurrentValue(message);
                UpdateCurrentValue(currentValue);
                UpdateCANData(message, period);
            }
        }
    }
}
