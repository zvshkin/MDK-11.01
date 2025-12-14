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
    public partial class BookView : Form
    {
        private const string ConnectStr = "host=localhost;uid=root;pwd=root;database=PR15_TEST";
        public BookView()
        {
            InitializeComponent();
            LoadBookData();
        }
        private void LoadBookData()
        {
            string sqlQuery = @"
                SELECT
                    book_id,
                    UPPER(title) AS Название_UPPER,
                    CONCAT(author, ' (', publication_year, 'г.)') AS Автор_и_Год_CONCAT,
                    pages AS Страниц,
                    LEFT(isbn, 10) AS ISBN_Префикс_LEFT
                FROM book;
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

                    if (dgvData.Columns.Contains("book_id")) dgvData.Columns["book_id"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных о книгах: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
