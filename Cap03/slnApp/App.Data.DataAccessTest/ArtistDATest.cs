using System;
using App.Data.DataAccess;
using App.Entities.Base;
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

        [TestMethod]
        public void InsertArtist()
        {
            var artist = new Artist();
            artist.Name = "Artist prueba";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertarArtist(artist);

            Assert.IsTrue(codigoGenerado >= 0);
        }

        [TestMethod]
        public void InsertArtistParamOut()
        {
            var artist = new Artist();
            artist.Name = "Artist prueba";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertarArtistParamOut(artist);

            Assert.IsTrue(codigoGenerado >= 0);
        }

        [TestMethod]
        public void Update()
        {
            var artist = new Artist();
            artist.Name = "Artist prueba nuevo";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertarArtist(artist);

            //Actualizando el Artista
            artist.Name = "Artist prueba nuevo actualiado";
            artist.ArtistId = codigoGenerado;
            var updated = da.UpdateArtist(artist);
            Assert.IsTrue(updated);


            var artitaUpdate = da.GetArtistById(codigoGenerado);
            Assert.IsTrue(artitaUpdate.Name== "Artist prueba nuevo actualiado");
        }
    }
}
