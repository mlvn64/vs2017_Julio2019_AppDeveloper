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
    public class CustomerDA : BaseDA
    {
        public List<Customer> getCustomerxName(string name)
        {
            var resultado = new List<Customer>();

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandText = "usp_GetCustomerxName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FullName", name));

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Customer();


                    customer.CustomerId = reader.GetInt32Value("CustomerId");
                    customer.FirstName = reader.GetStringValue("FirstName");
                    customer.LastName = reader.GetStringValue("LastName");

                    customer.Company = reader.GetStringValue("Company");

                    customer.Address = reader.GetStringValue("Address");
                    customer.City= reader.GetStringValue("City");
                    customer.State = reader.GetStringValue("State");
                    customer.Country = reader.GetStringValue("Country");
                    customer.PostalCode = reader.GetStringValue("PostalCode");
                    customer.Phone = reader.GetStringValue("Phone");
                    customer.Fax = reader.GetStringValue("Fax");
                    customer.Email = reader.GetStringValue("Email");
                    customer.SupportRepId = reader.GetInt32Null("SupportRepId");

                    resultado.Add(customer);
                }
            }

            return resultado;
        }
    }
}
