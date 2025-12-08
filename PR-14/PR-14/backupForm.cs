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

namespace PR_14
{
    public partial class backupForm : Form
    {
        string connect = "host=localhost;uid=root;pwd=root123;database=PR14_TEST;";

        public backupForm()
        {
            InitializeComponent();
        }

        private void CreateBackupTable(string sourceTableName)
        {
            string backupTableName = $"{sourceTableName}_backup"; 

            using (MySqlConnection con = new MySqlConnection(connect))
            {
                try
                {
                    con.Open();
                    
                    string dropSql = $"DROP TABLE IF EXISTS {backupTableName};";
                    using (MySqlCommand cmdDrop = new MySqlCommand(dropSql, con))
                    {
                        cmdDrop.ExecuteNonQuery();
                    }

                    string backupSql = $"CREATE TABLE {backupTableName} AS SELECT * FROM {sourceTableName};";
                    
                    using (MySqlCommand cmdBackup = new MySqlCommand(backupSql, con))
                    {
                        int rowsCopied = cmdBackup.ExecuteNonQuery();

                        MessageBox.Show($"Резервная копия таблицы '{sourceTableName}' успешно создана: '{backupTableName}'.", 
                                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании копии таблицы {sourceTableName}:\n{ex.Message}", "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            CreateBackupTable("patient");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateBackupTable("doctor");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateBackupTable("appointment_ticket");
        }
    }
}
