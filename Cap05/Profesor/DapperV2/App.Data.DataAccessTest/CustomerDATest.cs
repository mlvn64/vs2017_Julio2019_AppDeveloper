using System;
using App.Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class CustomerDATest
    {
        [TestMethod]
        public void GetCustomerxName()
        {
            var da = new CustomerDA();
            var lista = da.getCustomerxName("");

            Assert.IsTrue(lista.Count>0);
        }
    }
}
