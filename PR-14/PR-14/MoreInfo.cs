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

namespace PR_14
{
    public partial class MoreInfo : Form
    {
        private const string ConnStr = "host=localhost;uid=root;pwd=root123;database=PR14_TEST";
        private int ticketId;
        public MoreInfo(int id)
        {
            InitializeComponent();
            this.ticketId = id;
            GetTicketDetails();
        }

        void GetTicketDetails()
        {
            string sql = $@"
            SELECT 
                p.full_name AS patient_name, p.insurance_policy, p.birth_date, p.address, p.phone_number,
                d.full_name AS doctor_name, d.specialty, d.cabinet_num, d.shift_start, d.shift_end,
                t.visit_time, t.visit_type
            FROM 
                appointment_ticket AS t
            INNER JOIN 
                patient AS p ON t.patient_id = p.patient_id
            INNER JOIN 
                doctor AS d ON t.doctor_id = d.doctor_id
            WHERE 
                t.ticket_id = @id;";

            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                try
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", this.ticketId);

                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                gbPatient.Text = $"Пациент ({rdr["patient_name"]})";
                                lblPName.Text = $"ФИО: {rdr["patient_name"]}";
                                lblPPolicy.Text = $"Полис ОМС: {rdr["insurance_policy"]}";
                                lblPBirth.Text = $"Дата рождения: {Convert.ToDateTime(rdr["birth_date"]).ToShortDateString()}";
                                lblPAddress.Text = $"Адрес: {rdr["address"]}";

                                gbDoctor.Text = $"Врач ({rdr["doctor_name"]})";
                                lblDName.Text = $"ФИО: {rdr["doctor_name"]}";
                                lblDSpec.Text = $"Специальность: {rdr["specialty"]}";
                                lblDCab.Text = $"Кабинет: {rdr["cabinet_num"]}";

                                lblTTime.Text = $"Время приема: {Convert.ToDateTime(rdr["visit_time"]):dd.MM.yyyy HH:mm}";
                                lblTType.Text = $"Тип визита: {rdr["visit_type"]}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при чтении детальной информации: {ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
