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
     public partial class Loop : Form
    {
        private SerialPort serialPort; // SerialPort 객체

        public string LoopValue { get; private set; } // 사용자가 입력한 루프 값

        public Loop(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            LoopValue = textBoxLoop.Text;  // 사용자가 입력한 루프 값

            if (string.IsNullOrEmpty(LoopValue))
            {
                MessageBox.Show("루프 값을 입력하세요.");
                return;
            }

            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    // ELoad로 루프 설정 명령어 전송
                    string command = string.Format("PROG:LOOP {0}", LoopValue);
                    serialPort.WriteLine(command);

                    MessageBox.Show(string.Format("루프가 '{0}'로 설정되었습니다.", LoopValue));
                    DialogResult = DialogResult.OK;  // 다이얼로그 결과를 OK로 설정
                    Close();
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
            Close();
        }
    }
}
