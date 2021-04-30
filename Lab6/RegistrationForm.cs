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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            String login = textBoxLogin.Text;
            String password = textBoxPassword.Text;
            DataBase db = new DataBase();
            if (textBoxLogin.Text.Trim() == string.Empty || textBoxPassword.Text.Trim() == string.Empty)
                MessageBox.Show("Please fill all the fields!", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            { 
                    MySqlCommand command1 = new MySqlCommand("INSERT INTO `user` (`login`,`password`) " +
                        "VALUES (@login,@pass)", db.GetConnection());
                    command1.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                    command1.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
                    db.openConnection();

                    if (command1.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Success! You've been registered!");
                        this.Hide();
                        LoginForm login1 = new LoginForm();
                        login1.Show();

                    }
                    else
                    {
                        MessageBox.Show("Try again");
                    }

                    db.closeConnection();
               
            }

        }
    }
}
