using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class CustomerDA: BaseDA
    {
        public int GetCountCustomer()
        {
            int result = 0;

            try
            {
                //1 - Consulta SQL
                var sql = "SELECT COUNT(CustomerId) FROM Customer";

                //var cnxString = "SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql";

                //2 - Crear el objeto connection
                //using (IDbConnection cnx = new SqlConnection(cnxString))
                using (IDbConnection cnx = new SqlConnection(ConnectionString))
                {
                    //Abriendo la conexion a la base de datos
                    cnx.Open();

                    //3 - Creando un objeto command
                    var cmd = cnx.CreateCommand();

                    //Asignando la consulta SQL al objeto command
                    cmd.CommandText = sql;
                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                result = -1;
            }

            return result;
        }

        public Customer GetCustomerByName(string firstName)
        {
            var result = new Customer();

            var sql = "usp_GetCustomerByNombre";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sql;

                //configrando parametros
                cmd.Parameters.Add(
                    new SqlParameter("@FirstName", firstName)
                    );
                //Fin del parametro                               

                var indice = 0;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Customer();

                    //Esto SI es recomendable, es mas optimo y no consume muchos recursos
                    indice = reader.GetOrdinal("CustomerId");
                    customer.CustomerId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("FirstName");
                    customer.FirstName = reader.GetString(indice);

                    indice = reader.GetOrdinal("LastName");
                    customer.LastName = reader.GetString(indice);

                    indice = reader.GetOrdinal("Company");
                    customer.Company = reader.GetString(indice);

                    indice = reader.GetOrdinal("Address");
                    customer.Address = reader.GetString(indice);

                    indice = reader.GetOrdinal("City");
                    customer.City = reader.GetString(indice);

                    indice = reader.GetOrdinal("State");
                    customer.State = reader.GetString(indice);

                    indice = reader.GetOrdinal("Country");
                    customer.Country = reader.GetString(indice);

                    indice = reader.GetOrdinal("PostalCode");
                    customer.PostalCode = reader.GetString(indice);

                    indice = reader.GetOrdinal("Phone");
                    customer.Phone = reader.GetString(indice);

                    indice = reader.GetOrdinal("Fax");
                    customer.Fax = reader.GetString(indice);

                    indice = reader.GetOrdinal("Email");
                    customer.Email = reader.GetString(indice);

                    indice = reader.GetOrdinal("SupportRepId");
                    customer.SupportRepId = reader.GetInt32(indice);

                    result = customer;
                }

                return result;
            }
        }
    }
}
