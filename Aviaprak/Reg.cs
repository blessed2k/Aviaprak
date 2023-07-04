using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aviaprak
{
    public partial class Reg : Form
    {
        DataBase dataBase = new DataBase();
        public Reg()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Autoriza autoriza = new Autoriza();
            autoriza.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create.Enabled = textboxLogin.Text.Length != 0 && textboxPassword.Text.Length != 0;

            

            var login = textboxLogin.Text;
            var password = textboxPassword.Text;

            string querystring = $"insert into register(login_user, password_user) values('{login}', '{password}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());


            if (checkuser())

            {
                return;
            }

            dataBase.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт Успешно создан!", "Успех!");
                Autoriza autoriza = new Autoriza();
                this.Hide();
                autoriza.ShowDialog();
                     
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            dataBase.closeConnection();
        }


        private Boolean checkuser()
        {
            var loginUser = textboxLogin.Text;
            var passUser = textboxPassword.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Create.Enabled = textboxLogin.Text.Length != 0 && textboxPassword.Text.Length != 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Create.Enabled = textboxLogin.Text.Length != 0 && textboxPassword.Text.Length != 0;
        }

        private void Reg_Load(object sender, EventArgs e)
        {
            Create.Enabled = false;

            pictureBox5.Visible = false;

            textboxLogin.MaxLength = 50;
            textboxPassword.MaxLength = 50;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textboxPassword.UseSystemPasswordChar = false;
            pictureBox5.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textboxPassword.UseSystemPasswordChar = true;
            pictureBox5.Visible = true;
            pictureBox4.Visible = false;
        }
    }

}
