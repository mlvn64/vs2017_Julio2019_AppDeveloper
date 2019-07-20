using System;
using App.Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class ArtistDATest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();

            var cantidad = da.GetCount();
            Assert.IsTrue(cantidad >= 0);
        }

        [TestMethod]
        public void GetArtist()
        {
            var da = new ArtistDA();
            var listado = da.GetArtists();
            
            Assert.IsTrue(listado.Count >= 0);
        }

        [TestMethod]
        public void GetArtistWitSP()
        {
            var da = new ArtistDA();
            var listado = da.GetArtists("Aero%");

            Assert.IsTrue(listado.Count >= 0);
        }
    }
}
