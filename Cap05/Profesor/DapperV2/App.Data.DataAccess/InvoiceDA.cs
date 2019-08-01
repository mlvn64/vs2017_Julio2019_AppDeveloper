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
    public class InvoiceDA:BaseDA
    {
        public int InsertInvoice(Invoice invoice)
        {
            int result = 0;
            using (IDbConnection cnx 
                    = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                //Iniciando la transacción
                var transaction = cnx.BeginTransaction();
                try
                {
                    var commandCab = cnx.CreateCommand();
                    commandCab.CommandText = "usp_InsertInvoice";
                    commandCab.CommandType 
                            = CommandType.StoredProcedure;

                    commandCab.Transaction = transaction;

                    commandCab.Parameters.Add(
                        new SqlParameter("@CustomerId", invoice.CustomerId)
                        );

                    commandCab.Parameters.Add(
                        new SqlParameter("@InvoiceDate", invoice.InvoiceDate)
                        );

                    commandCab.Parameters.Add(
                       new SqlParameter("@BillingAddress", invoice.BillingAddress)
                       );

                    commandCab.Parameters.Add(
                       new SqlParameter("@BillingCity", invoice.BillingCity)
                       );

                    commandCab.Parameters.Add(
                       new SqlParameter("@BillingState", invoice.BillingState)
                       );


                    commandCab.Parameters.Add(
                       new SqlParameter("@BillingCountry", invoice.BillingCountry)
                       );


                    commandCab.Parameters.Add(
                       new SqlParameter("@BillingPostalCode", invoice.BillingPostalCode)
                       );

                    commandCab.Parameters.Add(
                       new SqlParameter("@Total", invoice.Total)
                       );

                    //Ejecutando y obtiendo el código autogenerado
                    var id = Convert.ToInt32(commandCab.ExecuteScalar());

                    foreach(var line in invoice.InvoiceLine)
                    {
                        var commandDet = cnx.CreateCommand();
                        commandDet.CommandText = "usp_InsertInvoiceLine";
                        commandDet.CommandType
                                = CommandType.StoredProcedure;

                        commandDet.Transaction = transaction;

                        commandDet.Parameters.Add(
                            new SqlParameter("@InvoiceId",id)                            
                            );

                        commandDet.Parameters.Add(
                            new SqlParameter("@TrackId", line.TrackId)
                            );

                        commandDet.Parameters.Add(
                            new SqlParameter("@UnitPrice", line.UnitPrice)
                            );

                        commandDet.Parameters.Add(
                            new SqlParameter("@Quantity", line.Quantity)
                            );

                        commandDet.ExecuteNonQuery();
                    }

                    //Confirmando con la transacción con el commit
                    transaction.Commit();

                    result = id;
                }
                catch(Exception ex)
                {
                    //Deshaciendo la transacción
                    transaction.Rollback();
                }


            }

            return result;
        }
    }
}
