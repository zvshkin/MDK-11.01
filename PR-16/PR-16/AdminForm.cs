using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PR_16
{
    public partial class AdminForm : Form
    {
        string connect = "host=localhost;uid=root;pwd=root;database=PR16_TEST;";

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

        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
            LoadRoles();
        }

        private void LoadUserData()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connect))
                {
                    con.Open();
                    string sql = @"SELECT u.user_id, u.login, u.full_name, u.phone_number, 
                                   c.category_name, u.created_at, u.updated_at 
                                   FROM users u 
                                   JOIN user_category c ON u.category_id = c.category_id";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsers.DataSource = dt;

                    dgvUsers.Columns["user_id"].Visible = false;
                    dgvUsers.Columns["login"].HeaderText = "Логин";
                    dgvUsers.Columns["full_name"].HeaderText = "ФИО";
                    dgvUsers.Columns["phone_number"].HeaderText = "Телефон";
                    dgvUsers.Columns["category_name"].HeaderText = "Роль";
                    dgvUsers.Columns["created_at"].HeaderText = "Создан";
                    dgvUsers.Columns["updated_at"].HeaderText = "Изменен";

                    dgvUsers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvUsers.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvUsers.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvUsers.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvUsers.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoles()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connect))
                {
                    con.Open();
                    string sql = "SELECT * FROM user_category";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbRole.DataSource = dt;
                    cmbRole.DisplayMember = "category_name";
                    cmbRole.ValueMember = "category_id";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string GenerateRandomPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            Random res = new Random();
            int length = 8;
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
                password[i] = chars[res.Next(chars.Length)];
            return new string(password);
        }

        private void btnGeneratePass_Click(object sender, EventArgs e)
        {
            txtUserPassword.Text = GenerateRandomPassword();
        }

        private bool IsLoginExists(string login)
        {
            using (MySqlConnection con = new MySqlConnection(connect))
            {
                con.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE login = @log";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@log", login);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtUserPassword.Text))
            {
                MessageBox.Show("Заполните логин и пароль!");
                return;
            }

            if (IsLoginExists(txtLogin.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string finalFullName = string.IsNullOrWhiteSpace(txtFullName.Text)
                           ? txtLogin.Text
                           : txtFullName.Text;

            string finalPhone = txtPhone.MaskCompleted
                    ? txtPhone.Text
                    : "";

            try
            {
                using (MySqlConnection con = new MySqlConnection(connect))
                {
                    con.Open();
                    string hashedPassword = AuthForm.GetSha256Hash(txtUserPassword.Text);

                    string sql = @"INSERT INTO users (login, password_hash, full_name, phone_number, category_id, created_at, updated_at) 
                           VALUES (@login, @pass, @name, @phone, @role, NOW(), NOW())";

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@login", txtLogin.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", hashedPassword);
                    cmd.Parameters.AddWithValue("@name", finalFullName.Trim());
                    cmd.Parameters.AddWithValue("@phone", finalPhone.Trim());
                    cmd.Parameters.AddWithValue("@role", cmbRole.SelectedValue);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Учетная запись успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserData();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtLogin.Clear();
            txtUserPassword.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            cmbRole.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char inputChar = e.KeyChar;

            if (char.IsControl(inputChar))
            {
                e.Handled = false;
                return;
            }

            if (inputChar == ' ')
            {
                e.Handled = false;
                return;
            }

            if (inputChar >= 'А' && inputChar <= 'Я' ||
                inputChar >= 'а' && inputChar <= 'я')
            {
                e.Handled = false;
                return;
            }

            e.Handled = true;
        }
    }
}