using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_16
{
    public partial class UserForm : Form
    {
        public UserForm(string userFullName)
        {
            InitializeComponent();
            lblWelcome.Text = $"Добро пожаловать, {userFullName}!";
            lblDate.Text = $"Сегодня: {DateTime.Now:dd.MM.yyyy}";
        }
    }
}
