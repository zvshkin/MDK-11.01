using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createForm createForm = new createForm();
            createForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            viewForm viewForm = new viewForm();
            viewForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backupForm backupForm = new backupForm();
            backupForm.ShowDialog();
        }
    }
}
