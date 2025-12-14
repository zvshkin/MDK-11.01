using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PR_15
{
    public partial class BooksOnHandView : Form
    {
        private const string ConnectStr = "host=localhost;uid=root;pwd=root;database=PR15_TEST";
        public BooksOnHandView()
        {
            InitializeComponent();
            LoadLoanData();
            LoadAggregateData();
        }

        private void LoadLoanData()
        {
            string sqlQuery = @"
                SELECT
                    b.title AS Название_Книги,
                    r.full_name AS Читатель,
                    bb.borrow_date AS Дата_Выдачи,
                    bb.due_date AS Срок_Возврата,
                    bb.actual_return_date AS Факт_Возврата,
                    bb.fine_amount AS Штраф_руб,
                    DATEDIFF(COALESCE(bb.actual_return_date, NOW()), bb.borrow_date) AS Длительность_дней
                FROM books_on_hand bb
                JOIN reader r ON bb.reader_id = r.reader_id
                JOIN book b ON bb.book_id = b.book_id
                ORDER BY bb.borrow_date DESC;
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
                    dgvData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных о выдачах: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadAggregateData()
        {
            string sqlAggregate = @"
                SELECT
                    COUNT(loan_id) AS total_loans,
                    SUM(fine_amount) AS sum_fine,
                    AVG(fine_amount) AS avg_fine,
                    MIN(fine_amount) AS min_fine,
                    MAX(fine_amount) AS max_fine
                FROM books_on_hand;
            ";

            using (MySqlConnection con = new MySqlConnection(ConnectStr))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlAggregate, con);
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            lblCount.Text = $"COUNT(): Общее число записей о выдачах: {rdr["total_loans"]}";
                            lblSumFine.Text = $"SUM(): Общая сумма штрафов: {Convert.ToDecimal(rdr["sum_fine"]):N2} руб.";
                            lblAvgFine.Text = $"AVG(): Средний штраф по всем записям: {Convert.ToDecimal(rdr["avg_fine"]):N2} руб.";
                            lblMinFine.Text = $"MIN(): Минимальный штраф (если нет штрафов, будет 0): {Convert.ToDecimal(rdr["min_fine"]):N2} руб.";
                            lblMaxFine.Text = $"MAX(): Максимальный зафиксированный штраф: {Convert.ToDecimal(rdr["max_fine"]):N2} руб.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки агрегатных данных: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
