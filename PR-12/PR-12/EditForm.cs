using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PR_12
{
    public partial class EditForm : Form
    {
        private const string ConnStr = "host=localhost;uid=root;pwd=root;database=PR12_TEST;";

        public EditForm()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string employeeIdToDelete = dataGridView1.Rows[e.RowIndex].Cells["employee_id"].Value.ToString();

            DialogResult confirm = MessageBox.Show(
                $"Вы уверены, что хотите удалить работника с ID {employeeIdToDelete}? Это действие нельзя отменить!",
                "Подтверждение удаления записи",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                PerformDelete(employeeIdToDelete);
            }
        }
        private void PerformDelete(string employeeIdToDelete)
        {
            string deleteSql = "DELETE FROM employee WHERE employee_id = @id;";

            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(deleteSql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", employeeIdToDelete);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Успешно удалена {rowsAffected} запись.", "Успех операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FillDataGrid();
                        }
                        else
                        {
                            MessageBox.Show("Удаление не выполнено. Запись не найдена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (MySqlException sqlEx)
                {
                    MessageBox.Show($"Ошибка БД ({sqlEx.Number}): Не удалось удалить запись. {sqlEx.Message}", "Ошибка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Общая ошибка приложения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void FillDataGrid()
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                try
                {
                    con.Open();
                    string select = @"
                SELECT 
                    employee_id, 
                    full_name AS 'ФИО Работника',
                    position AS 'Должность',
                    hire_date AS 'Дата Найма',
                    salary AS 'Зарплата',
                    is_shift_manager AS 'Старший Смены'
                FROM employee";

                    using (MySqlCommand cmd = new MySqlCommand(select, con))
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridView1.Columns[0].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
