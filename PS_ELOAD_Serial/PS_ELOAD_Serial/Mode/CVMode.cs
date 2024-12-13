using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_ELOAD_Serial
{
    public partial class CVMode : Form
    {
        // CV 모드의 설정 값을 저장할 속성들 (string 타입)
        public string VoltageValue { get; private set; }
        public string UVPValue { get; private set; }
        public string OCPLValue { get; private set; }
        public string OPPLValue { get; private set; }

        public CVMode()
        {
            InitializeComponent();

            // 버튼 클릭 이벤트 핸들러 등록
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
        }

        // OK 버튼 클릭 시 호출되는 메서드
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            // 모든 입력 값을 string으로 저장
            VoltageValue = textBoxIVoltage.Text;
            UVPValue = textBoxUVP.Text;
            OCPLValue = textBoxOCPL.Text;
            OPPLValue = textBoxOPPL.Text;

            DialogResult = DialogResult.OK; // 다이얼로그 결과를 OK로 설정하고 폼 닫기
            this.Close();
        }

        // Cancel 버튼 클릭 시 호출되는 메서드
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // 다이얼로그 결과를 Cancel로 설정하고 폼 닫기
            this.Close();
        }
    }
}
