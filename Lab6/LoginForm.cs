using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == null || textBoxPassword.Text == null)
            {
                MessageBox.Show("Enter login and pass!");
            }
            else
            {
                String login = textBoxLogin.Text;
                String password = textBoxPassword.Text;

                DataBase db = new DataBase();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` = @login AND `password` = @pass", db.GetConnection());

                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    ProductForm product = new ProductForm();
                    product.Show();

                }
                else
                {
                    MessageBox.Show("Register please!");
                }
            }

        }

        private void register_label_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
