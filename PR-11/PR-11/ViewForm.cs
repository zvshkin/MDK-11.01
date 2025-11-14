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

namespace PR_11
{
    public partial class ViewForm : Form
    {

        private readonly string connectionString = 
                                "server=localhost;" +
                                "port=3306;" +
                                "user=root;" +
                                "password=root;" + 
                                "database=db44;";

        public ViewForm()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT full_name as 'Фамилия И.О.'," +
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

                recordsDataGridView.DataSource = table;
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

        private void ViewForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("Таблица обновлена!");
        }
    }
}
