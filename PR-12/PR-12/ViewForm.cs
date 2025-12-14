using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_12
{
    public partial class ViewForm : Form
    {
        private const string ConnStr = "host=localhost;uid=root;pwd=root;database=PR12_TEST;";

        public ViewForm()
        {
            InitializeComponent();
            FillDataGrid();
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
