using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Aviaprak
{
    public partial class perelet : Form
    {
        json3 json = new json3 ();
        public perelet()
        {
            InitializeComponent();
            loaddata ();
        }

        private void loaddata()
        {
            var data = json.Get_all_display_data();
            dataGridView1.DataSource = data;
        }
        private void perelet_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
