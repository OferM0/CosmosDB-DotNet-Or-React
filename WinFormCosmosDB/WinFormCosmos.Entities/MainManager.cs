using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCosmos.Model;

namespace WinFormCosmos.Entities
{
    public class MainManager
    {
        public List<Product> productsList = new List<Product>();

        private MainManager() { }
        private static readonly MainManager _instance = new MainManager();
        public static MainManager Instance { get { return _instance; } }

        public ProductService products = new ProductService();

        public void InitProducts()
        {
            products.GetProductsFromDB();
        }
    }
}
