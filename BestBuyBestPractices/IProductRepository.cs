using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        public void CreateProduct(string newName, double newPrice, int newcatID);
    }
}
