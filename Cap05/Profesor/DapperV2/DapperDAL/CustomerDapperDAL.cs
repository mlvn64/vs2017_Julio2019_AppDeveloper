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
    public class CustomerDapperDAL: DALBase
    {

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
