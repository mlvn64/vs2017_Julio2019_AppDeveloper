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
            ArtistAlbumDapperDAL artistAlbumDapperDAL = new ArtistAlbumDapperDAL();
            var artist = artistAlbumDapperDAL.GetArtistById(2);
            Console.WriteLine(artist.Name);
            artist.Album.ForEach(line =>
            {
                Console.WriteLine(line.Title);
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
    }
}
