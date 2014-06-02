using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administrativo.Clases
{
    class User_group
    {        MySqlConnection con = null;
        public int id { get; set; }
        public String name { get; set; }

        public User_group() { }

        public User_group(int id, String name) {
            this.id = id;
            this.name = name;
        }
        public User_group(int id)
        {
            this.id = id;
        }

        public List<User_group> findAll()
        {
            List<User_group> listUserGroup = null;
            String sql = "select * from user_group";
            try
            {
                con = new Conexion().getConexion();
                listUserGroup = new List<User_group>();
                con.Open();

                MySqlCommand sqlCom = new MySqlCommand(sql, con);
                MySqlDataReader res = sqlCom.ExecuteReader();

                while (res.Read()) listUserGroup.Add(new User_group(res.GetInt32(0), res.GetString(1)));
                return listUserGroup;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR User_Group.findAll() " + ex.Message);
                return listUserGroup;
            }

        }

        public List<User_group> getPrivilegio()
        {
            List<User_group> listUserGroup = null;
             String sql = "SELECT b.id_privilegios, b.nombre FROM usergroup_privilegios AS a "+
            "INNER JOIN privilegios AS b "+
            "ON (a.id_privilegios = b.id_privilegios) "+
            "INNER JOIN user_group AS c "+
            "ON (a.id_user_group = c.id_user_group) "+
            "WHERE c.id_user_group = "+this.id;
        try
        {
            con = new Conexion().getConexion();
            listUserGroup = new List<User_group>();
            con.Open();

            MySqlCommand sqlCom = new MySqlCommand(sql, con);
            MySqlDataReader res = sqlCom.ExecuteReader();

            while (res.Read()) listUserGroup.Add(new User_group(res.GetInt32(0), res.GetString(1)));
            return listUserGroup;
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR User_Group.getPrivilegio() " + ex.Message);
            return listUserGroup;
        }
        }
    }
}
