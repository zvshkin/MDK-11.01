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

namespace PR_15
{
    public partial class ReaderView : Form
    {
        private const string ConnectStr = "host=localhost;uid=root;pwd=root;database=PR15_TEST";
     
        public ReaderView()
        {
            InitializeComponent();
            LoadReaderData();
        }
        private void LoadReaderData()
        {
            string sqlQuery = @"
                SELECT
                    reader_id,
                    full_name AS ФИО,
                    phone_number AS Телефон,
                    address AS Адрес,
                    YEAR(registration_date) AS Год_Регистрации_YEAR,
                    DATE_FORMAT(registration_date, '%d.%m.%Y') AS Дата_Регистрации_FORMAT,
                    DATEDIFF(NOW(), registration_date) AS Дни_в_Библиотеке_DATEDIFF
                FROM reader;
            ";

            using (MySqlConnection con = new MySqlConnection(ConnectStr))
            {
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvData.DataSource = dt;

                    if (dgvData.Columns.Contains("reader_id")) dgvData.Columns["reader_id"].Visible = false;
                    dgvData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных читателей: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
