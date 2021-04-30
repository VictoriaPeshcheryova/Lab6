using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    class ProductDao :Product, Dao<Product>
    {
        DataBase db = new DataBase();
        DataTable table = new DataTable();

        public void Delete(string oldParameter)
        {
            try { 
            db.openConnection();
            string queryToDeleteProduct = "delete from product where name='" + oldParameter + "';";
            MySqlCommand commandToDeleteProduct = new MySqlCommand(queryToDeleteProduct, db.GetConnection());
            MySqlDataReader readerForDeletingProduct;
            readerForDeletingProduct = commandToDeleteProduct.ExecuteReader();
            while (readerForDeletingProduct.Read())
            {
            }
                db.closeConnection(); 
                MessageBox.Show("Product was deleted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                db.closeConnection();
            }


        }

        public void Insert(Product param)
        {
            String name = param.getNameOfTheProduct();
            String company = param.getCompanyNameOfAProduct();
            int price = param.getPriceOfAProduct();
            bool isAvailable = param.getisAvailable();
            MySqlCommand command1 = new MySqlCommand("INSERT INTO `product` (`name`,`company`,`price`,`available`) " +
                        "VALUES (@name,@company, @price,@available)", db.GetConnection());
            command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command1.Parameters.Add("@company", MySqlDbType.VarChar).Value = company;
            command1.Parameters.Add("@price", MySqlDbType.Int32).Value = price;
            command1.Parameters.Add("@available", MySqlDbType.VarChar).Value = isAvailable.ToString();

            db.openConnection();
            if (command1.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Success! Product was added");
            }
            else
            {
                MessageBox.Show("Error");
            }

            db.closeConnection();
        }


        public void Update(Product param, string oldParameter)
        {
            String name = param.getNameOfTheProduct();
            String company = param.getCompanyNameOfAProduct();
            int price = param.getPriceOfAProduct();
            String isAvailable = param.getisAvailable().ToString();
            try
            {
                db.openConnection();
                String queryToUpdateProduct = "update product set name='" + name +
                "',company='" + company + "',price='" + price +
                "',available='" + isAvailable +
               "' where name='" + oldParameter + "';";
                MySqlCommand commandToUpdateProduct = new MySqlCommand(queryToUpdateProduct, db.GetConnection());
                MySqlDataReader readerForUpdatingProduct;
                readerForUpdatingProduct = commandToUpdateProduct.ExecuteReader();
                MessageBox.Show("Product was updated successfully!");
                while (readerForUpdatingProduct.Read())
                {
                }
                db.closeConnection();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
