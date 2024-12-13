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
    public partial class Sequence : Form
    {
        private string _dbFilePath = @"C:\Users\kangdohyun\Desktop\세미나\4주차\PS_ELOAD_Serial\MyDatabase#1.sdf; Password = a1234!;";
        private DataTable programTable;
        private string selectedProgramName = null; // 선택된 프로그램 이름 저장 변수
        private SerialPort serialPort; // SerialPort 객체

        public Sequence(SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;

            // Delegate를 사용하여 CreateButton 클릭 이벤트 핸들러 연결
            this.CreateButton.Click += new EventHandler(this.ButtonCreate_Click);
            this.DeleteButton.Click += new EventHandler(this.ButtonDelete_Click);
            this.OptionButton.Click += new EventHandler(this.OptionButton_Click);
            this.SelectButton.Click += new EventHandler(this.ButtonSelect_Click);
            LoadProgramList();
        }

        private void LoadProgramList()
        {
            try
            {
                using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath))
                {
                    connection.Open();
                    SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter("SELECT * FROM [Program List]", connection);
                    programTable = new DataTable();
                    dataAdapter.Fill(programTable);

                    dataGridView.DataSource = programTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading program list: " + ex.Message);
            }
        }

        /*private void ButtonCreate_Click(object sender, EventArgs e)
        {
            ProgramForm programForm = new ProgramForm();
            if (programForm.ShowDialog() == DialogResult.OK)
            {
                // 새 프로그램을 데이터베이스에 추가
                using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO [Program List] ([Program Name]) VALUES (@ProgramName)";
                    using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProgramName", programForm.ProgramName);
                        command.ExecuteNonQuery();
                    }
                }

                // 새 프로그램 목록을 로드
                LoadProgramList();
            }
        }*/

        // Create 버튼 클릭 이벤트 핸들러
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            // ProgramForm 폼을 생성하고 표시하여 프로그램 이름을 입력받음
            ProgramForm programForm = new ProgramForm(serialPort);
            if (programForm.ShowDialog() == DialogResult.OK)
            {
                // 사용자가 입력한 프로그램 이름을 데이터베이스에 추가
                AddProgramToDatabase(programForm.ProgramName);
                // 데이터베이스에서 프로그램 목록을 다시 로드
                LoadProgramList();
            }
        }

        // 프로그램 이름을 데이터베이스에 추가하는 메서드
        private void AddProgramToDatabase(string programName)
        {
            try
            {
                using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO [Program List] ([Program Name]) VALUES (@ProgramName)";
                    using (SqlCeCommand command = new SqlCeCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ProgramName", programName); // 프로그램 이름을 매개변수로 추가
                        command.ExecuteNonQuery(); // SQL 명령어 실행
                    }
                }
                MessageBox.Show("프로그램이 성공적으로 추가되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("프로그램 추가 중 오류 발생: " + ex.Message);
            }
        }

        // DataGridView의 셀 클릭 이벤트 핸들러
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 셀이 "Select" 버튼 열에 해당하면 실행
            if (e.ColumnIndex == dataGridView.Columns["SelectButton"].Index && e.RowIndex >= 0)
            {
                selectedProgramName = dataGridView.Rows[e.RowIndex].Cells["Program Name"].Value.ToString();
                DeleteButton.Enabled = true; // DeleteButton 활성화
                MessageBox.Show("프로그램 선택됨: " + selectedProgramName);
            }
        }

        // Delete 버튼 클릭 이벤트 핸들러
        /*private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)  // 데이터 그리드의 선택된 행이 있는지 확인
            {
                // 선택된 행의 첫 번째 셀(Program Name)의 값을 가져옴
                string selectedProgramName = dataGridView.SelectedRows[0].Cells["Program Name"].Value.ToString();

                // 데이터베이스에서 해당 프로그램을 삭제
                try
                {
                    using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath + ";Password= a1234!;"))
                    {
                        connection.Open();

                        // SQL DELETE 쿼리 작성
                        string deleteQuery = "DELETE FROM [Program List] WHERE [Program Name] = @ProgramName";
                        using (SqlCeCommand command = new SqlCeCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ProgramName", selectedProgramName);
                            int rowsAffected = command.ExecuteNonQuery();  // 쿼리 실행

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(selectedProgramName + "이 성공적으로 삭제되었습니다");
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
        }*/

        // Delete 버튼 클릭 이벤트 핸들러
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)  // 데이터 그리드의 선택된 행이 있는지 확인
            {
                // 선택된 행의 첫 번째 셀(Program Name)의 값을 가져옴
                string selectedProgramName = dataGridView.SelectedRows[0].Cells["Program Name"].Value.ToString();

                // 데이터베이스에서 해당 프로그램을 삭제
                try
                {
                    using (SqlCeConnection connection = new SqlCeConnection("Data Source=" + _dbFilePath + ";Password= a1234!;"))
                    {
                        connection.Open();

                        // SQL DELETE 쿼리 작성
                        string deleteQuery = "DELETE FROM [Program List] WHERE [Program Name] = @ProgramName";
                        using (SqlCeCommand command = new SqlCeCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ProgramName", selectedProgramName);
                            int rowsAffected = command.ExecuteNonQuery();  // 쿼리 실행

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(selectedProgramName + "이 성공적으로 삭제되었습니다");

                                // 시리얼 포트를 통해 Eload에서 프로그램 삭제 명령어 전송
                                try
                                {
                                    // 시리얼 포트가 열려 있는지 확인
                                    if (serialPort != null && serialPort.IsOpen)
                                    {
                                        //Eload 프로그램 삭제 전, 셀렉 초기화
                                        string selectCommand = string.Format("PROG \"\""); // 명령어 생성
                                        serialPort.WriteLine(selectCommand); // 명령어 전송
                                        // Eload에 프로그램 삭제 명령어 전송
                                        string deleteCommand = string.Format("PROG:DEL \"/{0}\"", selectedProgramName);  // Eload의 명령어 형식에 맞게 작성
                                        serialPort.WriteLine(deleteCommand);

                                        MessageBox.Show(string.Format("Eload에서 프로그램 '{0}'이(가) 성공적으로 삭제되었습니다.", selectedProgramName), "Eload 프로그램 삭제");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Eload 시리얼 포트가 열려 있지 않습니다.", "Eload 삭제 오류");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Eload 프로그램 삭제 중 오류 발생: " + ex.Message, "Eload 삭제 오류");
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


        private void OptionButton_Click(object sender, EventArgs e)
        {
            // 데이터 그리드에서 현재 선택된 ProgramName 확인
            if (dataGridView.SelectedRows.Count > 0)
            {
                // 선택된 Program Name 값을 가져오기
                string selectedProgramName = dataGridView.SelectedRows[0].Cells["Program Name"].Value.ToString();

                try
                {
                    // ProgramID를 Program List 테이블에서 가져오기
                    int programID = -1; // 초기값으로 -1 설정 (유효하지 않은 값)

                    using (SqlCeConnection connection = new SqlCeConnection("Data Source=C:\\Users\\kangdohyun\\Desktop\\세미나\\4주차\\PS_ELOAD_Serial\\MyDatabase#1.sdf; Password = a1234!;"))
                    {
                        connection.Open();
                        string query = "SELECT ProgramID FROM [Program List] WHERE [Program Name] = @ProgramName";

                        using (SqlCeCommand command = new SqlCeCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ProgramName", selectedProgramName);
                            object result = command.ExecuteScalar(); // ProgramID를 단일 값으로 가져옴

                            if (result != null)
                            {
                                programID = Convert.ToInt32(result); // ProgramID를 int로 변환하여 저장
                            }
                        }
                    }

                    // 유효한 ProgramID를 찾았을 경우 SettingsForm 창을 띄우기
                    if (programID != -1)
                    {
                        // 시리얼 포트를 통해 Eload에 선택한 프로그램을 선택하도록 명령어 전송
                        if (serialPort != null && serialPort.IsOpen)
                        {
                            string command = string.Format("PROG \"/{0}\"", selectedProgramName); // 명령어 생성
                            serialPort.WriteLine(command); // 명령어 전송
                            MessageBox.Show(string.Format("프로그램 '{0}'이(가) Eload에서 선택되었습니다.", selectedProgramName), "프로그램 선택");
                        }
                        else
                        {
                            MessageBox.Show("시리얼 포트가 열려 있지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        SettingsForm settingsForm = new SettingsForm(programID, serialPort); // ProgramID를 생성자에 전달
                        settingsForm.ShowDialog(); // 모달 창으로 띄움 (완료 후 반환)
                    }
                    else
                    {
                        MessageBox.Show("선택된 Program Name에 대한 ProgramID를 찾을 수 없습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Program 설정을 불러오는 중 오류가 발생했습니다: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("먼저 Program을 선택하십시오.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            // DataGridView에서 선택된 행이 있는지 확인
            if (dataGridView.SelectedRows.Count > 0)
            {
                // 선택된 행의 ProgramID 값을 가져옴
                int selectedProgramID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["ProgramID"].Value);

                // Option_list 폼을 ProgramID와 함께 생성 및 표시
                Option_list optionListForm = new Option_list(selectedProgramID, serialPort);
                optionListForm.ShowDialog(); // 모달로 폼 표시 (원하는 경우 Show() 사용 가능)
            }
            else
            {
                // 선택된 행이 없는 경우 사용자에게 알림
                MessageBox.Show("먼저 프로그램을 선택해주십시오.", "프로그램이 선택되지 않았습니다.");
            }
        }


    }
}