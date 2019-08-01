using System;
using App.Data.DataAccess;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class CustomerDATest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetCustomerByFirstName()
        {
            //var customer = new Customer();
            //customer.FirstName = "Leonie";
            //Tim Goyer
            //Frank Ralston
            var p = "Tim";
            var da = new CustomerDA();
            var customerValor = da.GetCustomerByName(p);

            Assert.IsTrue(customerValor.LastName == "Goyer");

            ////Actualizando el Artista
            //artist.Name = "Artist prueba nuevo actualiado";
            //artist.ArtistId = codigoGenerado;
            //var updated = da.UpdateArtist(artist);
            //Assert.IsTrue(updated);


            //var artitaUpdate = da.GetArtistById(codigoGenerado);
            //Assert.IsTrue(artitaUpdate. == "Artist prueba nuevo actualiado");
        }

        [TestMethod]
        public void GetCustomerxName()
        {
            //var customer = new Customer();
            //customer.FirstName = "Leonie";
            //Tim Goyer
            //Frank Ralston
            //var p = "Tim";
            var da = new CustomerDA();
            var lista = da.GetCustomerxName("");

            Assert.IsTrue(lista.Count >0);

        }

    }
}
