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
     public partial class Loop2 : Form
    {
        private SerialPort serialPort; // SerialPort 객체

        public string LoopValue2 { get; private set; } // 사용자가 입력한 루프 값

        public Loop2(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            LoopValue2 = textBoxLoop2.Text;  // 사용자가 입력한 루프 값

            if (string.IsNullOrEmpty(LoopValue2))
            {
                MessageBox.Show("루프 값을 입력하세요.");
                return;
            }

            if (serialPort != null && serialPort.IsOpen)
            {
                MessageBox.Show(string.Format("루프가 '{0}'로 설정되었습니다.", LoopValue2));
                DialogResult = DialogResult.OK;  // 다이얼로그 결과를 OK로 설정
                Close();
            }
            else
            {
                MessageBox.Show("시리얼 포트가 열려 있지 않습니다.");
            }
        }

        /*private void ButtonOk_Click(object sender, EventArgs e)
        {
            LoopValue2 = textBoxLoop2.Text;  // 사용자가 입력한 루프 값

            if (string.IsNullOrEmpty(LoopValue2))
            {
                MessageBox.Show("루프 값을 입력하세요.");
                return;
            }

            try
            {
                if (serialPort != null && serialPort.IsOpen)
                {
                    // 루프 값이 설정되면 이벤트 호출
                    LoopSet.Invoke(LoopValue2);
                    MessageBox.Show(string.Format("루프가 '{0}'로 설정되었습니다.", LoopValue2));
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
        }*/

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
