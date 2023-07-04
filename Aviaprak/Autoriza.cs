using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aviaprak
{
    public partial class Autoriza : Form
    {


        DataBase database = new DataBase();
        public Autoriza()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login.Enabled = false;

            
            pictureBox5.Visible = false;

            textBoxLogin.MaxLength = 50;
            textBoxPassword.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0;

            UserInfo.LogIn = textBoxLogin.Text;

            var logiUser = textBoxLogin.Text;
            var passUser = textBoxPassword.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{logiUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно Вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                main main = new main();
                this.Hide();
                main.ShowDialog();
                this.Show();

            }
            else
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            login.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0;


        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            login.Enabled = textBoxLogin.Text.Length != 0 && textBoxPassword.Text.Length != 0;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            main main = new main();
            main.Show();
            this.Hide();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBox5.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBox5.Visible = true;
            pictureBox4.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
