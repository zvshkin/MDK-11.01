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

namespace PR_09
{

    public partial class Form1 : Form
    {

        string ConnStr = "Server=localhost;Database=test_db;Uid=root;Pwd=root123";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConnStr);

            try
            {
                con.Open();

                string sqlSelect = "SELECT * FROM employer;";

                MySqlCommand cmd = new MySqlCommand(sqlSelect, con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnAddEmployer_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtVacanciesCount.Text, out int vacancies) || vacancies < 0)
            {
                MessageBox.Show("Количество вакансий должно быть числом.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string insertSql = "INSERT INTO employer (company_name, industry, contact_person, phone_number, vacancies_count) VALUES (@name, @industry, @contact, @phone, @vacancies);";

            MySqlConnection con = new MySqlConnection(ConnStr);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(insertSql, con);

                cmd.Parameters.AddWithValue("@name", txtCompanyName.Text);
                cmd.Parameters.AddWithValue("@industry", txtIndustry.Text);
                cmd.Parameters.AddWithValue("@contact", txtContactPerson.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@vacancies", vacancies);

                cmd.ExecuteNonQuery();

                txtCompanyName.Clear();
                txtIndustry.Clear();
                txtContactPerson.Clear();
                txtPhoneNumber.Clear();
                txtVacanciesCount.Clear();

                MessageBox.Show("Запись успешно добавлена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string sqlSelect = "SELECT * FROM employer;";
                MySqlCommand refreshCmd = new MySqlCommand(sqlSelect, con);
                MySqlDataAdapter da = new MySqlDataAdapter(refreshCmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
