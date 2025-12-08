using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_14
{
    public partial class viewForm : Form
    {
        string connect = "host=localhost;uid=root;pwd=root123;database=PR14_TEST;";

        public viewForm()
        {
            InitializeComponent();
        }

        private void viewForm_Load(object sender, EventArgs e)
        {
            LoadTickets();
        }

        void LoadTickets()
        {
			string sql = @"
            SELECT 
                t.ticket_id AS '№ Талона',
                p.full_name AS 'Пациент (ФИО)',
                d.specialty AS 'Специальность Врача',
                d.full_name AS 'Врач (ФИО)',
                t.visit_time AS 'Время приема',
                t.visit_type AS 'Тип визита'
            FROM 
                appointment_ticket AS t
            INNER JOIN 
                patient AS p ON t.patient_id = p.patient_id -- Присоединяем Пациента
            INNER JOIN 
                doctor AS d ON t.doctor_id = d.doctor_id;  -- Присоединяем Врача";

			using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTickets.DataSource = dt;
                    dgvTickets.Columns[0].Visible = false;
                    dgvTickets.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvTickets.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dgvTickets.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения данных: " + ex.Message);
                }
            }
        }
		private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				try
				{
					int ticketId = (int)dgvTickets.Rows[e.RowIndex].Cells["№ Талона"].Value;

					MoreInfo info = new MoreInfo(ticketId);
					info.ShowDialog();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Не удалось получить ID талона: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
