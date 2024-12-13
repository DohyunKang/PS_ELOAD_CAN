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

namespace PS_ELOAD_Serial
{
    public partial class CRMode : Form
    {
        private bool isCVModeEnabled = false; // +CV 모드 활성화 여부
        private SerialPort serialPort;

        public string ImpedanceValue { get; private set; }
        public string UVPValue { get; private set; }
        public string OCPLValue { get; private set; }
        public string OPPLValue { get; private set; }
        public string VoltageValue { get; private set; } // +CV 모드에서 사용할 전압 값

        public CRMode(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;  // 전달된 serialPort 객체 저장

            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);

            // textBoxImpedence의 TextChanged 이벤트 핸들러 추가
            textBoxImpedence.TextChanged += TextBoxImpedence_TextChanged;

            // +CV 버튼 클릭 이벤트 연결
            this.plusCVButton.Click += new EventHandler(this.ToggleCVMode);

            // 처음에 Voltage UI는 보이지 않게 설정
            labelVoltage.Visible = false;
            textBoxVoltage.Visible = false;
        }

        /*public CRMode()
        {
            InitializeComponent();

            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);

            // textBoxImpedence의 TextChanged 이벤트 핸들러 추가
            textBoxImpedence.TextChanged += TextBoxImpedence_TextChanged;


            // +CV 버튼 클릭 이벤트 연결
            this.plusCVButton.Click += new EventHandler(this.ToggleCVMode);

            // 처음에 Voltage UI는 보이지 않게 설정
            labelVoltage.Visible = false;
            textBoxVoltage.Visible = false;
        }*/

        /*// serialPort를 인자로 받는 생성자
        public CRMode(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;
        }*/

        // ELoad에 명령어를 보내는 메서드
        private void SendCommandToELoad(string command)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                try
                {
                    serialPort.WriteLine(command); // 명령어 전송  
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

                // ELoad에 CVP ON 명령 전송
                SendCommandToELoad("FUNC:CVOP OFF");
            }
        }

        // textBoxImpedence 값 변경 시 호출되는 이벤트 핸들러
        /*private void TextBoxImpedence_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // textBoxImpedence에 입력된 값을 double로 변환
                double impedanceValue;
                if (double.TryParse(textBoxImpedence.Text, out impedanceValue) && impedanceValue != 0)
                {
                    // 임피던스의 역수를 계산하여 labelResistance에 표시
                    double resistanceValue = 1 / impedanceValue;
                    labelResistance.Text = resistanceValue.ToString("F4"); // 소수점 4자리까지 표시
                }
                else
                {
                    // 입력값이 유효하지 않거나 0일 때는 초기값으로 설정
                    labelResistance.Text = "Invalid";
                }
            }
            catch
            {
                labelResistance.Text = "Error";
            }
        }*/

        private void TextBoxImpedence_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // textBoxImpedence에 입력된 값을 double로 변환
                double impedanceValue;
                if (double.TryParse(textBoxImpedence.Text, out impedanceValue) && impedanceValue != 0)
                {
                    // 임피던스의 역수를 계산하여 textBoxResistance에 표시
                    double resistanceValue = 1 / impedanceValue;
                    textBoxResistance.Text = resistanceValue.ToString("F4"); // 소수점 4자리까지 표시
                }
                else
                {
                    // 입력값이 유효하지 않거나 0일 때는 초기값으로 설정
                    textBoxResistance.Text = "Invalid";
                }
            }
            catch
            {
                textBoxResistance.Text = "Error";
            }
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            // 입력값을 변수에 저장
            ImpedanceValue = textBoxImpedence.Text;
            UVPValue = textBoxUVP.Text;
            OCPLValue = textBoxOCPL.Text;
            OPPLValue = textBoxOPPL.Text;

            // +CV 모드가 활성화된 경우 전압 값 저장
            if (isCVModeEnabled)
            {
                VoltageValue = textBoxVoltage.Text;
            }
            else
            {
                VoltageValue = null; // 비활성화 상태면 전압 값 비우기
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxResistance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // textBoxResistance에 입력된 값을 double로 변환
                double resistanceValue;
                if (double.TryParse(textBoxResistance.Text, out resistanceValue) && resistanceValue != 0)
                {
                    // 임피던스의 역수를 계산하여 textBoxImpedence에 표시
                    double impedanceValue = 1 / resistanceValue;
                    textBoxImpedence.Text = impedanceValue.ToString("F4"); // 소수점 4자리까지 표시
                }
                else
                {
                    // 입력값이 유효하지 않거나 0일 때는 초기값으로 설정
                    textBoxImpedence.Text = "Invalid";
                }
            }
            catch
            {
                textBoxImpedence.Text = "Error";
            }
        }
    }
}
