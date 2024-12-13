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
    public partial class ProgramForm2 : Form
    {
        private SerialPort serialPort; // SerialPort 객체
        public string ProgramName { get; private set; }

        // 기본 생성자 추가 (인수 없이 호출할 수 있도록)
        public ProgramForm2()
        {
            InitializeComponent();
        }

        public ProgramForm2(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;  // SerialPort 저장
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            ProgramName = textBoxProgramName2.Text;  // 사용자가 입력한 프로그램 이름

            if (string.IsNullOrEmpty(ProgramName))
            {
                MessageBox.Show("프로그램 이름을 입력하세요.");
                return;
            }

            // 입력된 프로그램 이름을 이용해 명령어를 전송
            try
            {
                //string command = string.Format("PROG:CRE \"/{0}\"", ProgramName);

                if (serialPort != null && serialPort.IsOpen)
                {
                    // 시퀀스 생성 명령어를 보내기
                    //serialPort.WriteLine(command);

                    // 프로그램 생성 완료 메시지
                    MessageBox.Show("프로그램 '{programName}'이(가) 성공적으로 생성되었습니다.");
                    DialogResult = DialogResult.OK;  // 다이얼로그 결과를 OK로 설정
                    this.Close();
                }
                else
                {
                    MessageBox.Show("시리얼 포트가 열려 있지 않습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("프로그램 생성 중 오류 발생: " + ex.Message);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
