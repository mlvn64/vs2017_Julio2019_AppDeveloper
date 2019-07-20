using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class ArtistDA : BaseDA
    {
        /// <summary>
        /// Obtiene la cantidad de registros
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int result = 0;

            try
            {
                //1 - Consulta SQL
                var sql = "SELECT COUNT(ArtistId) FROM Artist";

                //var cnxString = "SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql";

                //2 - Crear el objeto connection
                //using (IDbConnection cnx = new SqlConnection(cnxString))
                using (IDbConnection cnx = new SqlConnection(ConnectionString))
                {
                    //Abriendo la conexion a la base de datos
                    cnx.Open();

                    //3 - Creando un objeto command
                    var cmd = cnx.CreateCommand();

                    //Asignando la consulta SQL al objeto command
                    cmd.CommandText = sql;
                    result = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {

                result = -1;
            }



            return result;
        }


        public List<Artist> GetArtists()
        {
            var result = new List<Artist>();

            var sql = "SELECT * FROM Artist";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                var indice = 0;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var artist = new Artist();

                    //Esto SI es recomendable, es mas optimo y no consume muchos recursos
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    //Esto no es recomendable - LO RECUPERA COMO UN OBJECT Y LUEGO LO CONVIERTE, Y esto consume mucho recursos
                    //artist.ArtistId = Convert.ToInt32(reader["ArtisitId"]);

                    //artist.ArtistId = reader.GetInt32(0);
                    //artist.Name = reader.GetString(1);

                    result.Add(artist);
                }
            }


            return result;
        }

        public List<Artist> GetArtists(string filtroPorNombre)
        {
            var result = new List<Artist>();

            var sql = "usp_GetArtist";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(

                    new SqlParameter("@Nombre", filtroPorNombre)
                    );

                var indice = 0;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var artist = new Artist();

                    //Esto SI es recomendable, es mas optimo y no consume muchos recursos
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    //Esto no es recomendable - LO RECUPERA COMO UN OBJECT Y LUEGO LO CONVIERTE, Y esto consume mucho recursos
                    //artist.ArtistId = Convert.ToInt32(reader["ArtisitId"]);

                    //artist.ArtistId = reader.GetInt32(0);
                    //artist.Name = reader.GetString(1);

                    result.Add(artist);
                }

                return result;
            }
        }
    }
}
