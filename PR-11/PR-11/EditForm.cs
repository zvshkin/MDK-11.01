using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace PR_11
{
    public partial class EditForm : Form
    {

        private string selectedDoctorId = null;

        private readonly string connectionString =
                                "server=localhost;" +
                                "port=3306;" +
                                "user=root;" +
                                "password=root;" +
                                "database=db44;";

        public EditForm()
        {
            InitializeComponent();
            LoadData();

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75F, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("Verdana", 8.25F, FontStyle.Regular);

        }

        private void CheckCyrillic(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            bool isCyrillicLetter = (ch >= 'А' && ch <= 'Я') || (ch >= 'а' && ch <= 'я');

            bool isAllowedSymbol = Char.IsWhiteSpace(ch) || ch == '.' || ch == (char)Keys.Back;

            if (isCyrillicLetter || isAllowedSymbol)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CheckInt(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void LoadData()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT doctor_id, " +
                "full_name as 'Фамилия И.О.'," +
                "specialization as 'Специализация'," +
                "cabinet_number as 'Номер Кабинета'," +
                "shift_type as 'Тип Смены'," +
                "experience_years as 'Стаж Работы'" +
                " FROM doctor", connection);

            try
            {
                connection.Open();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                dataGridView1.DataSource = table;

                dataGridView1.Columns["doctor_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при чтении данных:\n" + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;

                selectedDoctorId = dataGridView1.Rows[rowIndex].Cells["doctor_id"].Value.ToString();

                string strCmd = $"SELECT * FROM doctor WHERE doctor_id='{selectedDoctorId}';";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();

                        MySqlCommand cmd = new MySqlCommand(strCmd, con);
                        MySqlDataReader rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            textBox1.Text = rdr["full_name"].ToString();
                            comboBox1.Text = rdr["specialization"].ToString();
                            textBox2.Text = rdr["cabinet_number"].ToString();
                            comboBox2.Text = rdr["shift_type"].ToString();
                            textBox3.Text = rdr["experience_years"].ToString();

                            button1.Enabled = true;
                        }
                        rdr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка при чтении данных доктора:\n" + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedDoctorId))
            {
                MessageBox.Show("Сначала выберите доктора для редактирования.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullName = textBox1.Text;
            string specialization = comboBox1.Text;
            string cabinetNumber = textBox2.Text;
            string shiftType = comboBox2.Text;
            string experienceYears = textBox3.Text;

            string strCmd = $@"UPDATE doctor SET 
                                full_name='{fullName}', 
                                specialization='{specialization}', 
                                cabinet_number='{cabinetNumber}', 
                                shift_type='{shiftType}', 
                                experience_years='{experienceYears}' 
                                WHERE doctor_id='{selectedDoctorId}';";

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(strCmd, con);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show($"Отредактирована 1 строка", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    button1.Enabled = false;
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    comboBox2.Text = "";
                    textBox3.Text = "";
                    selectedDoctorId = null;

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при обновлении данных:\n" + ex.Message);
                }
            }
        }
    }
}
