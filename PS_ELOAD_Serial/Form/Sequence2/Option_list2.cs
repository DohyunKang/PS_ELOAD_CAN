using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe; // SQL Server Compact Edition 사용
using System.IO.Ports;

namespace PS_ELOAD_Serial
{
    public partial class Option_list2 : Form
    {
        private int _programID; // 프로그램 ID를 저장할 필드
        private string _dbFilePath = @"C:\Users\kangdohyun\Desktop\세미나\강도현\7주차\PS_ELOAD_CAN\MyDatabase#1.sdf; Password = a1234!;";
        private SerialPort serialPort; // SerialPort 객체
        private DataTable programTable;

        public Option_list2(int programID, SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            _programID = programID; // 프로그램 ID를 저장
        }

        private void Option_list_Load(object sender, EventArgs e)
        {
            LoadProgramSettings(); // 폼이 로드될 때 설정 데이터 로드
        }

        private void LoadProgramSettings()
        {
            try
            {
                // 데이터베이스 연결 및 ProgramID를 기준으로 설정 데이터 조회
                using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath))
                {
                    connection.Open();
                    string query = "SELECT * FROM ProgramSettings2 WHERE ProgramID2 = @ProgramID";
                    SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(query, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@ProgramID", _programID);
                    DataTable settingsTable = new DataTable();
                    dataAdapter.Fill(settingsTable);

                    // 조회된 데이터를 DataGridView에 바인딩
                    dataGridViewOptions2.DataSource = settingsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading program settings: " + ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewOptions2.SelectedRows.Count > 0)  // 데이터 그리드의 선택된 행이 있는지 확인
            {
                // 선택된 행의 StepNum 값을 가져옴
                string selectedStepIndex = dataGridViewOptions2.SelectedRows[0].Cells["StepNum2"].Value.ToString();

                // 데이터베이스에서 해당 Step을 삭제
                try
                {
                    using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath + ";Password= a1234!;"))
                    {
                        connection.Open();

                        // SQL DELETE 쿼리 작성
                        string deleteQuery = "DELETE FROM [ProgramSettings2] WHERE [StepNum2] = @StepIndex";
                        using (SqlCeCommand command = new SqlCeCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@StepIndex", selectedStepIndex);
                            int rowsAffected = command.ExecuteNonQuery();  // 쿼리 실행

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(selectedStepIndex + "이 성공적으로 삭제되었습니다");

                                // 시리얼 포트를 통해 Eload에서 프로그램 삭제 명령어 전송
                                try
                                {
                                    // 시리얼 포트가 열려 있는지 확인
                                    if (serialPort != null && serialPort.IsOpen)
                                    {
                                        // Eload에 프로그램 삭제 명령어 전송
                                        //string deleteCommand = string.Format("PROG:STEP{0}:DEL", selectedStepIndex);  // Eload의 명령어 형식에 맞게 작성
                                        //serialPort.WriteLine(deleteCommand);

                                        MessageBox.Show(string.Format("Eload에서 Step '{0}'이(가) 성공적으로 삭제되었습니다.", selectedStepIndex), "Eload Step 삭제");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Eload 시리얼 포트가 열려 있지 않습니다.", "Step 삭제 오류");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Eload 프로그램 삭제 중 오류 발생: " + ex.Message, "Step 삭제 오류");
                                }
                            }
                            else
                            {
                                MessageBox.Show("프로그램 삭제에 실패하였습니다.");
                            }
                        }
                    }

                    // 프로그램 목록 새로고침
                    LoadProgramList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("삭제 중 오류가 발생했습니다 : " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("삭제할 프로그램을 선택해주십시오.");
            }
        }

        private void LoadProgramList()
        {
            try
            {
                using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath))
                {
                    connection.Open();
                    SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter("SELECT * FROM [ProgramSettings2]", connection);
                    programTable = new DataTable();
                    dataAdapter.Fill(programTable);

                    dataGridViewOptions2.DataSource = programTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading program settings: " + ex.Message);
            }
        }
    }
}
