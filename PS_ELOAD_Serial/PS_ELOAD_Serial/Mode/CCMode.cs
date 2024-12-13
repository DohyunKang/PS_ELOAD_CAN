using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace PS_ELOAD_Serial
{
    public partial class CCMode : Form
    {
        private bool isCVModeEnabled = false; // +CV 모드 활성화 여부
        private SerialPort serialPort;

        // 속성 정의
        public string CurrentValue { get; private set; }        // 전류 값
        public string OPPLValue { get; private set; }           // OPPL 값
        public string UVPValue { get; private set; }            // UVP 값
        public string SLEWrateValue { get; private set; }     // 유도성 값 (Inductance)
        public string VoltageValue { get; private set; }        // +CV 모드에서 사용할 전압 값

        public CCMode(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;  // 전달된 serialPort 객체 저장

            // OK 버튼과 Cancel 버튼의 이벤트 핸들러 설정
            this.buttonOk.Click += new EventHandler(ButtonOk_Click);
            this.buttonCancel.Click += new EventHandler(ButtonCancel_Click);

            // +CV 버튼 클릭 이벤트 연결
            this.plusCVButton.Click += new EventHandler(this.ToggleCVMode);

            // 처음에 Voltage UI는 보이지 않게 설정
            labelVoltage.Visible = false;
            textBoxVoltage.Visible = false;
        }

        // ELoad에 명령어를 보내는 메서드
        private void SendCommandToELoad(string command)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.WriteLine(command); // 명령어 전송
                    MessageBox.Show("명령 전송 성공: " + command, "CV 모드 전환");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("명령 전송 실패: " + ex.Message, "CV 모드 전환 오류");
                }
            }
            else
            {
                MessageBox.Show("ELoad가 연결되지 않았습니다.", "CV 모드 전환 오류");
            }
        }

        // +CV 모드 On/Off 토글
        private void ToggleCVMode(object sender, EventArgs e)
        {
            isCVModeEnabled = !isCVModeEnabled;  // 상태 전환

            if (isCVModeEnabled)
            {
                plusCVButton.Text = "CV Mode On"; // 버튼 텍스트 변경
                textBoxVoltage.Visible = true;    // 전압 입력 필드 표시
                labelVoltage.Visible = true;      // 전압 라벨 표시

                // ELoad에 CVP ON 명령 전송
                SendCommandToELoad("FUNC:CVOP ON");
            }
            else
            {
                plusCVButton.Text = "CV Mode Off"; // 버튼 텍스트 변경
                textBoxVoltage.Visible = false;    // 전압 입력 필드 숨김
                labelVoltage.Visible = false;      // 전압 라벨 숨김

                // ELoad에 CVP OFF 명령 전송
                SendCommandToELoad("FUNC:CVOP OFF");
            }
        }

        // OK 버튼 클릭 시 호출되는 메서드
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            // 각 텍스트박스의 값을 속성에 저장
            CurrentValue = textBoxCurrent.Text;
            OPPLValue = textBoxOPPL.Text;
            UVPValue = textBoxUVP.Text;
            SLEWrateValue = textBoxCurrent_A_us.Text;

            // +CV 모드가 활성화된 경우 전압 값 저장
            if (isCVModeEnabled)
            {
                VoltageValue = textBoxVoltage.Text;
            }
            else
            {
                VoltageValue = null; // 비활성화 상태면 전압 값 비우기
            }

            // 다이얼로그 결과를 OK로 설정하고 창 닫기
            DialogResult = DialogResult.OK;
            this.Close();
        }

        // Cancel 버튼 클릭 시 호출되는 메서드
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // 다이얼로그 결과를 Cancel로 설정하고 창 닫기
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
