using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Product
    {
        int id;
        String nameOfTheProduct;
        String companyNameOfAProduct;
        int priceOfAProduct;
        bool isAvailable;

        public Product(string nameOfTheProduct, string companyNameOfAProduct, int priceOfAProduct, bool isAvailable)
        {
            this.nameOfTheProduct = nameOfTheProduct;
            this.companyNameOfAProduct = companyNameOfAProduct;
            this.priceOfAProduct = priceOfAProduct;
            this.isAvailable = isAvailable;
        }
        public Product(){}

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getNameOfTheProduct()
        {
            return nameOfTheProduct;
        }

        public void setNameOfTheProduct(String nameOfTheProduct)
        {
            this.nameOfTheProduct = nameOfTheProduct;
        }

        public String getCompanyNameOfAProduct()
        {
            return companyNameOfAProduct;
        }

        public void setCompanyNameOfAProduct(String companyNameOfAProduct)
        {
            this.companyNameOfAProduct = companyNameOfAProduct;
        }

        public int getPriceOfAProduct()
        {
            return priceOfAProduct;
        }

        public void setPriceOfAProduct(int priceOfAProduct)
        {
            this.priceOfAProduct = priceOfAProduct;
        }

        public bool getisAvailable()
        {
            return isAvailable;
        }

        public void setAvailable(bool available)
        {
            isAvailable = available;
        }



    }
}
