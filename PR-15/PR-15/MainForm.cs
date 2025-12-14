using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_15
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            BooksOnHandView form = new BooksOnHandView();
            form.ShowDialog();
        }

        private void btnReaders_Click(object sender, EventArgs e)
        {
            ReaderView form = new ReaderView();
            form.ShowDialog();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            BookView form = new BookView();
            form.ShowDialog();
        }
    }
}
