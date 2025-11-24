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
using MySql.Data.MySqlClient;

namespace PR_13
{
    public partial class backupForm : Form
    {
        string connect = "host=localhost;uid=root;pwd=root123;database=PR13_TEST;";

        public backupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dropSql = "DROP TABLE IF EXISTS appointment_ticket_backup;";

            string backupSql = "CREATE TABLE appointment_ticket_backup AS (SELECT * FROM appointment_ticket);";

            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();

                    using (MySqlCommand cmdDrop = new MySqlCommand(dropSql, con))
                    {
                        cmdDrop.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmdBackup = new MySqlCommand(backupSql, con))
                    {
                        int rows = cmdBackup.ExecuteNonQuery();
                    }

                    MessageBox.Show("Резервная копия таблицы 'appointment_ticket' создана.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при создании копии: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
