using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aviaprak
{

    public partial class main : Form
    {

        private Random random;
        posti posti = new posti();
        public main()

        {
            InitializeComponent();
            customizeDesing();
            for (int i = 0; i < posti.short_description_cities.Count(); i++)
            {
                var Item = new ListViewItem(posti.short_description_cities[i].ToString());
                ListView.Items.Add(Item);
            }
            for (int i = 0; i < posti.description_discounts.Count(); i++)
            {
                var Item = new ListViewItem(posti.description_discounts[i].ToString());
                listView1.Items.Add(Item);
            }

            random = new Random();
        }




        private void customizeDesing()
        {
            panelSettings.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelSettings.Visible == true)
                panelSettings.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {
            label1.Text = UserInfo.LogIn;

            GenerateRandomNumber();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSettings);
        }

        private Form activeForm = null;
        private void openMainForm(Form mainForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = mainForm;
            mainForm.TopLevel = false;
            mainForm.FormBorderStyle = FormBorderStyle.None;
            mainForm.Dock = DockStyle.Fill;
            mainForm.BringToFront();
            mainForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //openMainForm(new theme());
            string hexColor = "#3e3c4e";
            string hexColor1 = "#ffffff";

            if (this.BackColor == System.Drawing.ColorTranslator.FromHtml(hexColor1))
                this.BackColor = System.Drawing.ColorTranslator.FromHtml(hexColor);
            else
                this.BackColor = System.Drawing.ColorTranslator.FromHtml(hexColor1);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                string imagePath = openFileDialog1.FileName;

                // Загружаем изображение в PictureBox
                pictureBox2.Image = Image.FromFile(imagePath);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StatusForm statusForm = new StatusForm();
            statusForm.ShowDialog();
            if (!string.IsNullOrEmpty(statusForm.Status))
            {
                label2.Text = statusForm.Status;
            }
        }
        private void StatusForm_StatusAccepted(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            perelet perelet = new perelet();
            perelet.Show();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerateRandomNumber()
        {
            int randomNumber = random.Next(124, 9123);
            label4.Text= randomNumber.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}