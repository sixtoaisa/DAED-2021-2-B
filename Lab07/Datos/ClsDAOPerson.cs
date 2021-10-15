using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class ClsDAOPerson : ClsDAO
    {

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
            con.Close();

            return dt;
        }

        public DataTable GETByValue(String value)
        {

            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "FindPersonByData";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@Busqueda";
            parametro.Value = value;
            parametro.SqlDbType = SqlDbType.NVarChar;

            cmd.Parameters.Add(parametro);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
           
            con.Close();

            return dt;
        }

    }
}
