using App.Entities.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL
{
    public class CustomerDapperDAL:DALBase
    {

        //IDbConnection connection = new SqlConnection("SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql");

        //public List<Customer> ListAllCustomers()
        //{
        //    return connection.Query<Customer>(
        //        "usp_GetCustomerxNombre",
        //        new { FullName = "" },
        //        commandType: CommandType.StoredProcedure).ToList();
        //}

        public List<Customer> ListAllCustomersWithNameLike(string name)
        {
            using (IDbConnection connection = this.getConnection())
            {
                return connection.Query<Customer>(
                                        "usp_GetCustomerxName",
                                        new { FullName = $"%{name}%" },
                                        commandType: CommandType.StoredProcedure
                                    )
                                    .ToList();
            }
        }
    }
}
