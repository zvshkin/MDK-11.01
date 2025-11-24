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

namespace PR_13
{
    public partial class viewForm : Form
    {
        string connect = "host=localhost;uid=root;pwd=root123;database=PR13_TEST;";

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
                
                (SELECT full_name FROM patient WHERE patient_id = t.patient_id) AS 'Пациент',
                
                (SELECT CONCAT(specialty, ': ', full_name) FROM doctor WHERE doctor_id = t.doctor_id) AS 'Врач',
                
                t.visit_time AS 'Время приема',
                t.visit_type AS 'Тип визита'
            FROM 
                appointment_ticket AS t"
            ;

            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTickets.DataSource = dt;
                    dgvTickets.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
    }
}
