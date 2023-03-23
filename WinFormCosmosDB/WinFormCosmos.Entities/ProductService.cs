using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCosmos.Data.Sql;
using WinFormCosmos.Model;

namespace WinFormCosmos.Entities
{
    public class ProductService
    {
        ProductQueries productsQueries = new ProductQueries();

        public void ClearList()
        {
            MainManager.Instance.productsList.Clear();
        }

        public void GetProductsFromDB()
        {
            ClearList();
            MainManager.Instance.productsList = ((List<Product>)productsQueries.ResetList());
            //return MainManager.Instance.productsList;
        }

        public Product GetProductById(string id)
        {
            Product product = ((Product)productsQueries.GetProductFromDB(id));
            return product;
        }
    }
}
