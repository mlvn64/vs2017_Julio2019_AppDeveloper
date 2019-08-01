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

            Assert.IsTrue(cantidad>=0);

        }

        [TestMethod]
        public void GetArtists()
        {
            var da = new ArtistDA();
            var listado = da.GetArtists();

            Assert.IsTrue(listado.Count >= 0);

        }

        [TestMethod]
        public void GetArtistsWitSP()
        {
            var da = new ArtistDA();
            var listado = da.GetArtists("Aero%");

            Assert.IsTrue(listado.Count >= 0);

        }


        [TestMethod]
        public void InsertArtist()
        {
            var artist = new Artist();
            artist.Name = "Artista prueba";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtist(artist);

            Assert.IsTrue(codigoGenerado > 0);

        }

        [TestMethod]
        public void InsertArtistParamOut()
        {
            var artist = new Artist();
            artist.Name = "Artista prueba";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtistParamOut(artist);

            Assert.IsTrue(codigoGenerado > 0);

        }


        [TestMethod]
        public void Update()
        {
            var artist = new Artist();
            artist.Name = "Artista prueba nuevo";

            var da = new ArtistDA();
            var codigoGenerado = da.InsertArtist(artist);

            //Actualizando el artista
            artist.Name = "Artista prueba nuevo actualizado";
            artist.ArtistId = codigoGenerado;
            var updated = da.UpdateArtist(artist);
            Assert.IsTrue(updated);

            var artistaUpdated = da.GetArtistById(codigoGenerado);
            Assert.IsTrue(artistaUpdated.Name== "Artista prueba nuevo actualizado");




        }



    }
}
