using App.Entities.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDAL
{
    public class InvoiceDapperDAL: DALBase
    {
        public Invoice GetInvoiceById(int id)
        {
            using (IDbConnection connection = this.getConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                using (var multi = connection.QueryMultiple("GetInvoice", new { InvoiceId = id }, transaction: transaction, commandType: CommandType.StoredProcedure))
                {
                    var invoice = multi.Read<Invoice>().Single();
                    invoice.InvoiceLine = multi.Read<InvoiceLine>().ToList();
                    transaction.Commit();
                    return invoice;
                }
            }
        }
    }
}
