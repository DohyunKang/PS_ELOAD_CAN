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

namespace PS_ELOAD_Serial
{
    public partial class SettingsForm : Form
    {
        // 데이터베이스 파일 경로
        private string _dbFilePath = @"C:\Users\kangdohyun\Desktop\세미나\4주차\PS_ELOAD_Serial\MyDatabase#1.sdf; Password = a1234!;";

        private SerialPort serialPort; // 시리얼 포트를 받기 위한 필드

        // 프로그램 ID를 참조하는 변수
        public int ProgramID { get; set; } // 외부에서 프로그램 ID를 설정할 수 있도록 public으로 설정

        public SettingsForm(int programID, SerialPort serialPort)
        {
            InitializeComponent();
            ProgramID = programID; // 생성자에서 ProgramID를 설정
            this.serialPort = serialPort; // Form1에서 전달받은 시리얼 포트를 저장

            this.buttonOk.Click += new EventHandler(this.ButtonOk_Click);
            this.buttonCancel.Click += new EventHandler(this.ButtonCancel_Click);
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
                    int level = int.Parse(textBoxLevel.Text);
                    int sr = int.Parse(textBoxSR.Text);
                    int dwell = int.Parse(textBoxDwell.Text);
                    string load = textBoxLoad.Text; // 문자열로 Load 값을 저장 (예: "immediate" 또는 "ramp")
                    string OnOff = textBoxOnOff.Text;
                    int walt = int.Parse(textBoxWalt.Text);
                    int post = int.Parse(textBoxPost.Text);
                    string generate = textBoxGenerate.Text; // generate도 문자열로 처리
                    int step = int.Parse(textBoxStepNum.Text);

                    // ProgramSettings 테이블에 데이터 추가
                    string insertQuery = "INSERT INTO ProgramSettings (ProgramID, Level, SR_A_us, Dwell_s, Load_immediate_ramp, Walt_pre, _post_, Generate, StepNum, LoadOnOff) " +
                                         "VALUES (@ProgramID, @Level, @SR, @Dwell, @Load, @Walt, @Post, @Generate, @Step, @LoadOnOff)";

                    using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProgramID", ProgramID);
                        command.Parameters.AddWithValue("@Level", level);
                        command.Parameters.AddWithValue("@SR", sr);
                        command.Parameters.AddWithValue("@Dwell", dwell);
                        command.Parameters.AddWithValue("@Load", load); // nvarchar로 load 값을 저장
                        command.Parameters.AddWithValue("@Walt", walt);
                        command.Parameters.AddWithValue("@Post", post);
                        command.Parameters.AddWithValue("@Generate", generate);
                        command.Parameters.AddWithValue("@Step", step);
                        command.Parameters.AddWithValue("@LoadOnOff", OnOff);

                        command.ExecuteNonQuery();
                    }

                    // 시리얼 포트를 통해 Eload에 명령어 전송
                    if (serialPort != null && serialPort.IsOpen)
                    {
                        serialPort.WriteLine(string.Format("PROG:STEPS:COUN {0}", step));
                        serialPort.WriteLine(string.Format("PROG:STEP" + step.ToString() +  ":LEV {0}", level));
                        serialPort.WriteLine(string.Format("PROG:STEP" + step.ToString() + ":SLEW {0}", sr));
                        serialPort.WriteLine(string.Format("PROG:STEP" + step.ToString() + ":DWEL {0}", dwell));
                        serialPort.WriteLine(string.Format("PROG:STEP" + step.ToString() + ":INP {0}", OnOff));
                        serialPort.WriteLine(string.Format("PROG:STEP" + step.ToString() + ":TRAN {0}", load));
                        //serialPort.WriteLine(string.Format("PROG:STEP:WPRE {0}", walt));
                        //serialPort.WriteLine(string.Format("PROG:STEP:WPOST {0}", post));
                        //serialPort.WriteLine(string.Format("PROG:STEP" + step.ToString() + ":TRIG:GEN {0}", generate));

                        MessageBox.Show("설정이 성공적으로 저장되고 명령어가 전송되었습니다.", "성공");
                    }
                    else
                    {
                        MessageBox.Show("시리얼 포트가 열려 있지 않습니다.");
                    }

                    MessageBox.Show("프로그램 설정이 성공적으로 저장되었습니다.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
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
