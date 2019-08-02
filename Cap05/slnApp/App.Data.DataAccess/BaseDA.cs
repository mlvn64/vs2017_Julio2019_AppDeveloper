using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class BaseDA
    {
        public string ConnectionString
        { 
            get
            {
                //var cnxString = "SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql";
                var cnxString = "SERVER=DESKTOP-MOJLP48\\SQLEXPRESS; DataBase=Chinook; USER ID=sa; PASSWORD=123";

                return cnxString;
            }
        }

        //public string GetStringValue(IDataReader reader, string campo)
        //{
        //    return reader.IsDBNull(reader.GetOrdinal(campo))
        //          ? null : reader.GetString(reader.GetOrdinal(campo));
        //}
    }
}
