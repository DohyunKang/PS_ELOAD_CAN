using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO.Ports;
using System.Diagnostics;

namespace PS_ELOAD_Serial
{
    public partial class SettingsForm2 : Form
    {
        // 데이터베이스 파일 경로
        private string _dbFilePath = @"C:\Users\kangdohyun\Desktop\세미나\강도현\7주차\PS_ELOAD_CAN\MyDatabase#1.sdf; Password = a1234!;";

        private SerialPort serialPort; // 시리얼 포트를 받기 위한 필드

        // 프로그램 ID를 참조하는 변수
        public int ProgramID2 { get; set; } // 외부에서 프로그램 ID를 설정할 수 있도록 public으로 설정

        public SettingsForm2(int programID, SerialPort serialPort)
        {
            InitializeComponent();
            ProgramID2 = programID; // 생성자에서 ProgramID를 설정
            this.serialPort = serialPort; // Form1에서 전달받은 시리얼 포트를 저장
            
            this.buttonOk2.Click += new EventHandler(this.ButtonOk_Click);
            this.buttonCancel2.Click += new EventHandler(this.ButtonCancel_Click);
        }

        // OK 버튼 클릭 이벤트 핸들러
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath))
                {
                    connection.Open();

                    // 입력한 설정 값을 가져와서 변수에 저장
                    int level = int.Parse(textBoxLevel2.Text);
                    int sr = int.Parse(textBoxSR2.Text);
                    int dwell = int.Parse(textBoxDwell2.Text);
                    string load = textBoxLoad2.Text; // 문자열로 Load 값을 저장 (예: "immediate" 또는 "ramp")
                    string OnOff = textBoxOnOff2.Text;
                    int wait = int.Parse(textBoxWait2.Text);
                    string generate = textBoxGenerate2.Text; // generate도 문자열로 처리
                    int step = int.Parse(textBoxStepNum2.Text);

                    // ProgramSettings 테이블에 데이터 추가
                    string insertQuery = "INSERT INTO ProgramSettings2 (ProgramID2, Level2, SR_A_us2, Dwell_s2, Load_immediate_ramp2, Wait_pre2, Generate2, StepNum2, LoadOnOff2) " +
                                         "VALUES (@ProgramID2, @Level, @SR, @Dwell, @Load, @Wait, @Generate, @Step, @LoadOnOff)";

                    using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProgramID2", ProgramID2);
                        command.Parameters.AddWithValue("@Level", level);
                        command.Parameters.AddWithValue("@SR", sr);
                        command.Parameters.AddWithValue("@Dwell", dwell);
                        command.Parameters.AddWithValue("@Load", load); // nvarchar로 load 값을 저장
                        command.Parameters.AddWithValue("@Wait", wait);
                        command.Parameters.AddWithValue("@Generate", generate);
                        command.Parameters.AddWithValue("@Step", step);
                        command.Parameters.AddWithValue("@LoadOnOff", OnOff);
                        

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("프로그램 설정이 성공적으로 저장되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("SettingsForm2에서 받은 ProgramID: " + ProgramID);
                MessageBox.Show("프로그램 설정 에러: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close(); // 창 닫기
            }
        }

        // Cancel 버튼 클릭 이벤트 핸들러
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 창을 닫음
        }
    }
}
