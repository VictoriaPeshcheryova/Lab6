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
    public partial class ProductForm : Form
    {
        DataBase db = new DataBase();
        private string ID = "";
        public ProductForm()
        {
            InitializeComponent();
        }
        private void label9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tabPage1_Leave(object sender, EventArgs e)
        {
            Clear();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            ShowUpdatings();
        }
        private void tabPage2_Leave(object sender, EventArgs e)
        {
            textBoxNameSearch.Clear();
        }
       
        private void tabPage3_Leave(object sender, EventArgs e)
        {
            Clear1();
        }
        public void Clear()
        {
            textBoxNameAdd.Clear();
            textBoxPrice.Clear();
            textBoxCompany.Clear();
            radioButtonYes.Checked = false;

        }
        private void Clear1()
        {
            textBoxName1.Clear();
            textBoxPrice1.Clear();
            textBoxCompany1.Clear();
            radioButtonYes1.Checked = false;
            ID = "";
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            bool isAvailable;
            if (radioButtonYes.Checked == true)
            {
                isAvailable = true;
            }
            else
            {
                isAvailable = false;
            }
            ProductDao productDao = new ProductDao();
            productDao.setNameOfTheProduct(textBoxNameAdd.Text);
            productDao.setCompanyNameOfAProduct(textBoxCompany.Text);
            productDao.setPriceOfAProduct(Convert.ToInt32(textBoxPrice.Text));
            productDao.setAvailable(isAvailable);
            if (textBoxNameAdd.Text.Trim() == string.Empty || textBoxPrice.Text.Trim() == string.Empty || textBoxCompany.Text.Trim() == string.Empty)
                MessageBox.Show("Please fill all the fields!", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command2 = new MySqlCommand("SELECT * FROM `product` WHERE `name` = @name", db.GetConnection());
                command2.Parameters.Add("@name", MySqlDbType.VarChar).Value = productDao.getNameOfTheProduct();
                adapter.SelectCommand = command2;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("We already have this product in database", "Product information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                { 
                    productDao.Insert(productDao);
                    ShowUpdatings();
                }
            }

        }
        public void ShowUpdatings()
        {
            try
            {
                string Query = "select * from product;";
                MySqlCommand commandToShowUpdatings = new MySqlCommand(Query, db.GetConnection());
                db.openConnection();
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = commandToShowUpdatings;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridViewProduct.DataSource = dTable;
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void textBoxPBSearch_TextChanged(object sender, EventArgs e)
        {
            (dataGridViewProduct.DataSource as DataTable).DefaultView.RowFilter = string.Format("name LIKE '%{0}%'", textBoxNameSearch.Text);
        }



        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            bool isAvailable;
            if (radioButtonYes.Checked == true)
            {
                isAvailable = true;
            }
            else
            {
                isAvailable = false;
            }
            ProductDao productDao = new ProductDao();
            productDao.setNameOfTheProduct(textBoxName1.Text);
            productDao.setCompanyNameOfAProduct(textBoxCompany1.Text);
            productDao.setPriceOfAProduct(Convert.ToInt32(textBoxPrice1.Text));
            productDao.setAvailable(isAvailable);
            if (ID != "")
            {
                if (textBoxName1.Text.Trim() == string.Empty || textBoxPrice1.Text.Trim() == string.Empty || textBoxCompany1.Text.Trim() == string.Empty)
                    MessageBox.Show("Please fill every field!", "Required field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    try
                    {
                        
                        productDao.Update(productDao,textBoxOldName.Text);
                        ShowUpdatings();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Please first select product from table", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ID != "")
            {
                try
                {
                    ProductDao productDao = new ProductDao();
                    productDao.Delete(this.textBoxOldName.Text);
                    ShowUpdatings();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("Please first select product from table", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewProduct.Rows[e.RowIndex];
                ID = row.Cells[0].Value.ToString();
                textBoxName1.Text = row.Cells[1].Value.ToString();
                textBoxOldName.Text = row.Cells[1].Value.ToString();
                textBoxCompany1.Text = row.Cells[2].Value.ToString();
                textBoxPrice1.Text = row.Cells[3].Value.ToString();
            }
        }

       
    }
}
