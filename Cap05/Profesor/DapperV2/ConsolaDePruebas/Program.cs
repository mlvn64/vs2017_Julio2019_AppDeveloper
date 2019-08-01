using App.Entities.Base;
using DapperDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDapperDAL productDapperDAL = new ProductDapperDAL();
            productDapperDAL.RegisterProduct(new Product()
            {
                Name = "Chocolate",
                Description = "Es un Chocolate"
            });
            productDapperDAL.RegisterProduct(new Product()
            {
                Name = "Pecana",
                Description = "Es una Pecana"
            });
            productDapperDAL.ListAllProducts().ForEach(product =>
            {
                Console.WriteLine($"{product.Id}) {product.Name}");
            });
            Console.ReadKey(); 
        }

        private static void ListCustomers()
        {
            CustomerDapperDAL customerDapperDAL = new CustomerDapperDAL();

            customerDapperDAL.ListAllCustomersWithNameLike("A").ForEach(customer =>
            {
                Console.WriteLine(customer.CustomerId);
                Console.WriteLine(customer.FirstName);
                Console.WriteLine(customer.Email);
            });
        }

        private static void GetAnInvoice()
        {
            InvoiceDapperDAL invoiceDapperDAL = new InvoiceDapperDAL();
            var invoice = invoiceDapperDAL.GetInvoiceById(2);
            Console.WriteLine(invoice.BillingAddress);
            invoice.InvoiceLine.ForEach(line =>
            {
                Console.WriteLine(line.TrackId);
            });
            Console.ReadKey();
        }
    }
}
