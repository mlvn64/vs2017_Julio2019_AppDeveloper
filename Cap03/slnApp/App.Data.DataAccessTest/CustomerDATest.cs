using System;
using System.Collections.Generic;
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

        }

        [TestMethod]
        public void GetCustomers()
        {            
            var da = new CustomerDA();
            string nombre = "Jorge";
            string apellido = "Valdez";
            var listado = da.GetCustomers(nombre, apellido);

            Assert.IsTrue(listado.Count > 0);
            //Assert.IsTrue(listado.FirstName == "Jorge" && listado.LastName == "Valdez");
        }

        [TestMethod]
        public void Update()
        {
            var customer = new Customer();
            customer.FirstName = "Customer prueba nuevo";

            var da = new CustomerDA();
            var codigoGenerado = da.InsertarCustomer(customer);

            //Actualizando el Artista
            customer.FirstName = "Customer prueba nuevo actualiado";
            customer.CustomerId = codigoGenerado;
            var updated = da.UpdateCustomer(customer);
            Assert.IsTrue(updated);


            var artitaUpdate = da.GetCustomerById(codigoGenerado);
            Assert.IsTrue(artitaUpdate.FirstName == "Customer prueba nuevo actualiado");
        }
    }
}
