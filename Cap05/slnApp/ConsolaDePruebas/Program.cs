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
                Name = "Caramelo",
                Description = "Es un caramelo"
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

        private static void ListInvoice()
        {
            InvoiceDapperDAL invoiceDapperDAL = new InvoiceDapperDAL();
            var invoice = invoiceDapperDAL.GetInvoiceById(2);
            Console.WriteLine(invoice.BillingAddress);
            invoice.InvoiceLine.ForEach(line =>
            {
                Console.WriteLine(line.TrackId);
            });
            //Console.ReadKey();
        }

        private static void ListArtistAlbum()
        {
            ArtistAlbumDapperDAL artistAlbumDapperDAL = new ArtistAlbumDapperDAL();
            var artist = artistAlbumDapperDAL.GetArtistById(2);
            Console.WriteLine(artist.Name);
            artist.Album.ForEach(line =>
            {
                Console.WriteLine(line.Title);
            });
            Console.ReadKey();
        }
    }
}
