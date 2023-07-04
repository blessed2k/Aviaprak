using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aviaprak
{
    public partial class StatusForm : Form
    {

        private string status;

        public string Status
        {
            get { return status; }
        }
        public StatusForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void status_FormClosed(object sender, FormClosedEventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            status = textboxLogin23.Text;
            this.Close(); 
        }
    }
}
