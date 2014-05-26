using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Windows;
namespace administrativo.Clases
{
    class DepartamentoClass
    {
        public int id { get; set; }
        public String nombre {get; set;}
        public String rut_jefe {get; set;}

        public DepartamentoClass(){}
        public DepartamentoClass(int id)
        {
            this.id = id;
        }
        public DepartamentoClass(int id, String nombre, String rut_jefe)
        {
            this.id = id;
            this.nombre = nombre;
            this.rut_jefe = rut_jefe;
        }
        public DepartamentoClass(String nombre, String rut_jefe)
        {
            this.nombre = nombre;
            this.rut_jefe = rut_jefe;
        }
        public int save() {
            String query = "insert into departamento (nombre, id_jefe) values('" + this.nombre + "'," + int.Parse(this.rut_jefe) + ")";
            MySqlConnection con = null;
            try
            {
                con = new Conexion().getConexion();
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand(query, con);


                return sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine("EEROR " + ex.Message);
                return 0;
            }
        }

        public int Delete()
        {
            String query = "DELETE  FROM departamento where id_departamento = "+this.id;
            MySqlConnection con = null;
            try
            {
                con = new Conexion().getConexion();
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand(query, con);


                return sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine("EEROR " + ex.Message);
                return 0;
            }
        }

        public int update()
        {
            String query = "update departamento set nombre='" + this.nombre + "', id_jefe= " + int.Parse(this.rut_jefe) + " where id_departamento = "+this.id;
            MySqlConnection con = null;
            try
            {
                con = new Conexion().getConexion();
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand(query, con);


                return sqlCom.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine("EEROR " + ex.Message);
                return 0;
            }
        }

        public List<DepartamentoClass> findAll()
        {
            List<DepartamentoClass> depto = null;
            String query = "select id_departamento, nombre, IFNULL(id_jefe,'Asignar jefe') as id_jefe from departamento";
            MySqlConnection con = null;
            try
            {

                con = new Conexion().getConexion();
                con.Open();
                MySqlCommand sqlCom = new MySqlCommand(query, con);
                MySqlDataReader res = sqlCom.ExecuteReader();

                depto = new List<DepartamentoClass>();
                
                while (res.Read())
                {

                    DepartamentoClass rows = new DepartamentoClass(res.GetInt32(0), res.GetString(1), res.GetString(2));
                    depto.Add(rows);
                }
                con.Close();
                return depto;
            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine("EEROR "+ex.Message);
                return depto;
            }
        }
    }
}
