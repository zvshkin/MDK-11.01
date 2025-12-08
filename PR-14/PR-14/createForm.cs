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

namespace PR_14
{
    public partial class createForm : Form
    {
        string connect = "host=localhost;uid=root;pwd=root123;database=PR14_TEST;";

        public createForm()
        {
            InitializeComponent();
        }

        private void createForm_Load(object sender, EventArgs e)
        {
            FillPatientCombo();
            FillDoctorCombo();
            cmbVisitType.SelectedIndex = 0;
        }

        void FillPatientCombo()
        {
            string sql = "SELECT patient_id, CONCAT(full_name, ' (Полис: ', insurance_policy, ')') as display_name FROM patient";

            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPatient.DisplayMember = "display_name";
                    cmbPatient.ValueMember = "patient_id";
                    cmbPatient.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки пациентов: " + ex.Message);
                }
            }
        }

        void FillDoctorCombo()
        {
            string sql = "SELECT doctor_id, CONCAT(full_name, ' - ', specialty) as display_doc FROM doctor";

            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDoctor.DisplayMember = "display_doc";
                    cmbDoctor.ValueMember = "doctor_id";
                    cmbDoctor.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки врачей: " + ex.Message);
                }
            }
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedValue == null || cmbDoctor.SelectedValue == null)
            {
                MessageBox.Show("Выберите пациента и врача!");
                return;
            }

            int pId = Convert.ToInt32(cmbPatient.SelectedValue);
            int dId = Convert.ToInt32(cmbDoctor.SelectedValue);
            string vTime = dtpVisitTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string vType = cmbVisitType.Text;

            string sqlInsert =
                $"INSERT INTO appointment_ticket (patient_id, doctor_id, visit_time, visit_type) " +
                $"VALUES ({pId}, {dId}, '{vTime}', '{vType}')";

            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlInsert, con);

                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Талон успешно создан!", "Успех");

						cmbPatient.SelectedIndex = -1;
						cmbDoctor.SelectedIndex = -1;
						cmbVisitType.SelectedIndex = -1;
						dtpVisitTime.Value = DateTime.Now;
					}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка добавления: " + ex.Message);
                }
            }
        }
    }
}
