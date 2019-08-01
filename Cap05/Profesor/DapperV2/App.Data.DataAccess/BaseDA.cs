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
                var cnxString = "SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql";

                return cnxString;
            }
        }

        public string GetStringValue(IDataReader reader, string campo)
        {
           return reader.IsDBNull(reader.GetOrdinal(campo))
                 ? null : reader.GetString(reader.GetOrdinal(campo));
        }

        //public int GetValue(IDataReader reader, string campo) 
        //{
        //  |  int value = 0;
        //    int ordinal = reader.GetOrdinal(campo);
        //    value = reader.GetInt32(ordinal);

        //    return value;
        //}        


        //public int? GetValueNull(IDataReader reader, string campo)
        //{
        //    int? value = 0;
        //    int ordinal = reader.GetOrdinal(campo);
        //    value = reader.IsDBNull(ordinal)?new Nullable<int>():reader.GetInt32(ordinal);

        //    return value;
        //}
    }
}
