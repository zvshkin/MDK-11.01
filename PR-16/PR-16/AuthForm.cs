using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PR_16
{
    public partial class AuthForm : Form
    {
        string connect = "host=localhost;uid=root;pwd=root;database=PR16_TEST;";
        int loginAttempts = 0;
        string currentCaptcha = "";

        public static string GetSha256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        public AuthForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            lblCaptcha.Visible = false;
            txtCaptcha.Visible = false;
            LoadUsers();
        }

        void LoadUsers()
        {
            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    string sql = "SELECT login, full_name FROM users";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxUsers.DataSource = dt;
                    comboBoxUsers.DisplayMember = "full_name";
                    comboBoxUsers.ValueMember = "login";
                }
                catch (Exception ex) { MessageBox.Show("Ошибка БД: " + ex.Message); }
            }
        }

        private void GenerateCaptcha()
        {
            Random rand = new Random();
            currentCaptcha = rand.Next(1000, 9999).ToString();
            lblCaptcha.Text = "Введите код: " + currentCaptcha;
            lblCaptcha.Visible = true;
            txtCaptcha.Visible = true;
            txtCaptcha.Clear();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtCaptcha.Visible)
            {
                if (txtCaptcha.Text != currentCaptcha)
                {
                    MessageBox.Show("Неверная CAPTCHA!");
                    GenerateCaptcha();
                    return;
                }
            }

            string selectedLogin = comboBoxUsers.SelectedValue.ToString();
            string enteredPasswordHash = GetSha256Hash(txtPassword.Text);

            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT category_id, full_name FROM users WHERE login = @log AND password_hash = @pass";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@log", selectedLogin);
                    cmd.Parameters.AddWithValue("@pass", enteredPasswordHash);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            loginAttempts = 0;
                            lblCaptcha.Visible = false;
                            txtCaptcha.Visible = false;

                            int roleId = Convert.ToInt32(rdr["category_id"]);
                            string fullName = rdr["full_name"].ToString();

                            this.Hide();

                            if (roleId == 1)
                            {
                                AdminForm adminWindow = new AdminForm();
                                adminWindow.ShowDialog();
                            }
                            else
                            {
                                UserForm userWindow = new UserForm(fullName);
                                userWindow.ShowDialog();
                            }

                            this.Show();
                            txtPassword.Clear();
                        }
                        else
                        {
                            loginAttempts++;
                            MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста, проверьте ещё раз введенные данные.");

                            if (loginAttempts >= 3)
                            {
                                await LockSystem();
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
            }
        }

        private async System.Threading.Tasks.Task LockSystem()
        {
            btnLogin.Enabled = false;
            txtPassword.Enabled = false;
            comboBoxUsers.Enabled = false;

            MessageBox.Show("Система заблокирована на 5 секунд за превышение попыток.");
            await System.Threading.Tasks.Task.Delay(5000);

            btnLogin.Enabled = true;
            txtPassword.Enabled = true;
            comboBoxUsers.Enabled = true;
            loginAttempts = 0;

            GenerateCaptcha();
        }

        private void txtCaptcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}