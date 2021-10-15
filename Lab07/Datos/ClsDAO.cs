using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class ClsDAO
    {
        public SqlConnection con;

        public ClsDAO()
        {
            String str = "Server=DESKTOP-FK8R0OS\\LOCAL;DataBase=School;Integrated Security=true;";
            con = new SqlConnection(str);
        }

       
    }
}
