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
        
        //--------------TAREA------------------

        public List<Customer> GetCustomers(string firstName, string lastName)
        {
            var result = new List<Customer>();

            var sql = "usp_GetCustomers";

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
                cmd.Parameters.Add(
                    new SqlParameter("@LastName", lastName)
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

                    result.Add(customer);
                }

                return result;
            }
        }

        public Customer GetCustomerById(int id)
        {
            var result = new Customer();

            var sql = "usp_GetCustomerById";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sql;

                //configrando parametros
                cmd.Parameters.Add(
                    new SqlParameter("@CustomerId", id)
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

        public int InsertarCustomer(Customer entity)
        {
            var result = 0;

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertCustomer";

                //Insertando parametros
                cmd.Parameters.Add(
                    new SqlParameter("@FirstName", entity.FirstName));

                cmd.Parameters.Add(
                    new SqlParameter("@LastName", entity.LastName));

                cmd.Parameters.Add(
                    new SqlParameter("@Company", entity.Company));

                cmd.Parameters.Add(
                    new SqlParameter("@Address", entity.Address));

                cmd.Parameters.Add(
                    new SqlParameter("@City", entity.City));

                cmd.Parameters.Add(
                    new SqlParameter("@State", entity.State));

                cmd.Parameters.Add(
                    new SqlParameter("@Country", entity.Country));

                cmd.Parameters.Add(
                    new SqlParameter("@PostalCode", entity.PostalCode));

                cmd.Parameters.Add(
                    new SqlParameter("@Phone", entity.Phone));

                cmd.Parameters.Add(
                    new SqlParameter("@Fax", entity.Fax));

                cmd.Parameters.Add(
                    new SqlParameter("@Email", entity.Email));

                cmd.Parameters.Add(
                    new SqlParameter("@SupportRepId", entity.SupportRepId));

                result = Convert.ToInt32(cmd.ExecuteScalar());

            }

            return result;
        }

        public bool UpdateCustomer(Customer entity)
        {
            var result = false;

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateCustomer";

                //parametros
                cmd.Parameters.Add(
                    new SqlParameter("@CustomerId", entity.CustomerId));

                cmd.Parameters.Add(
                    new SqlParameter("@FirstName", entity.FirstName));

                cmd.Parameters.Add(
                    new SqlParameter("@LastName", entity.LastName));

                cmd.Parameters.Add(
                    new SqlParameter("@Company", entity.Company));

                cmd.Parameters.Add(
                    new SqlParameter("@Address", entity.Address));

                cmd.Parameters.Add(
                    new SqlParameter("@City", entity.City));

                cmd.Parameters.Add(
                    new SqlParameter("@State", entity.State));

                cmd.Parameters.Add(
                    new SqlParameter("@Country", entity.Country));

                cmd.Parameters.Add(
                    new SqlParameter("@PostalCode", entity.PostalCode));

                cmd.Parameters.Add(
                    new SqlParameter("@Phone", entity.Phone));

                cmd.Parameters.Add(
                    new SqlParameter("@Fax", entity.Fax));

                cmd.Parameters.Add(
                    new SqlParameter("@Email", entity.Email));

                cmd.Parameters.Add(
                    new SqlParameter("@SupportRepId", entity.SupportRepId));

                result = cmd.ExecuteNonQuery() > 0;
                //result = cmd.ExecuteNonQuery() > 0?true:false;

            }

            return result;
        }
    }
}
