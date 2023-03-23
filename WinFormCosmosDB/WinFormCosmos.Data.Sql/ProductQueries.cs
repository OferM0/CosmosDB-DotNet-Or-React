using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormCosmos.Model;
using WinFormCosmos.Dal;

namespace WinFormCosmos.Data.Sql
{
    public class ProductQueries
    {
        public List<Product> BuildProductsList(SqlDataReader reader)
        {
            List<Product> productsList = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product();
                product.Id = Guid.NewGuid().ToString();
                product.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                product.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                product.CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID"));
                product.QuantityPerUnit = reader.GetString(reader.GetOrdinal("QuantityPerUnit"));
                product.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                product.UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"));
                product.UnitsOnOrder = reader.GetInt16(reader.GetOrdinal("UnitsOnOrder"));
                product.ReorderLevel = reader.GetInt16(reader.GetOrdinal("ReorderLevel"));
                product.Discontinued = reader.GetBoolean(reader.GetOrdinal("Discontinued"));
                productsList.Add(product);
            }
            return productsList;
        }
        public Product BuildProduct(SqlDataReader reader)
        {
            Product product = new Product();

            while (reader.Read())
            {
                product.Id = Guid.NewGuid().ToString();
                product.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
                product.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                product.SupplierID = reader.GetInt32(reader.GetOrdinal("SupplierID"));
                product.CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID"));
                product.QuantityPerUnit = reader.GetString(reader.GetOrdinal("QuantityPerUnit"));
                product.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                product.UnitsInStock = reader.GetInt16(reader.GetOrdinal("UnitsInStock"));
                product.UnitsOnOrder = reader.GetInt16(reader.GetOrdinal("UnitsOnOrder"));
                product.ReorderLevel = reader.GetInt16(reader.GetOrdinal("ReorderLevel"));
                product.Discontinued = reader.GetBoolean(reader.GetOrdinal("Discontinued"));
            }
            return product;
        }

        public object ResetList()
        {
            try
            {
                return Dal.SqlQuery.RunCommandResult("select * from Products", BuildProductsList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public object GetProductFromDB(string id)
        {
            try
            {
                return Dal.SqlQuery.RunCommandResult($"select * from Products where ProductID= '{id}'", BuildProduct);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}