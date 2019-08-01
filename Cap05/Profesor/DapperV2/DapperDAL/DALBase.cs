using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL
{
    public class DALBase
    {
        protected IDbConnection getConnection()
        {
            return new SqlConnection("SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql");
        }

    }
}
