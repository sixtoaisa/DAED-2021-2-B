using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocio
{
    public class ClsNegPerson
    {
        ClsDAOPerson daoPerson = new ClsDAOPerson();

        public DataTable GetAll()
        {
            return daoPerson.GetAll();
        }

        public DataTable GETByValue(String value)
        {
            return daoPerson.GETByValue(value);
        }

    }
}
