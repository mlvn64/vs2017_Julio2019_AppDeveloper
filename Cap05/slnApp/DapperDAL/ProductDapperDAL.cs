using App.Entities.Base;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL
{
    public class ProductDapperDAL:DALBase
    {
        public List<Product> ListAllProducts()
        {
            using (var connection = getConnection())
            {
                return connection.GetAll<Product>().ToList();
            }
        }

        public void RegisterProduct(Product product)
        {
            using (var connection = getConnection())
            {
                connection.Insert(product);
            }
        }
    }
}
