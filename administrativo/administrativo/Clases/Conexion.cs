using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administrativo.Clases
{
    class Conexion
    {
        public MySqlConnection getConexion()
        {
            return new MySqlConnection("data source=localhost; user id=root; password=12345678; database=recursos_humanos");
        }
    }
}
