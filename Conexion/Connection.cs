using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ClaryLegales_Ventas.Conexion
{
    public class Connection
    {
        public MySqlConnection ConnectionMysql()
        {
            string MyConString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
            MySqlConnection connection = new MySqlConnection(MyConString);
            return connection;
        }
    }

    public class Connection2
    {
        public String[] CN_3(int id)
        {
            string[] texto = { "#", "#", "#", "#" };
            try
            {
                Connection connectionMysql = new Connection();
                MySqlConnection connection = connectionMysql.ConnectionMysql();
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader Reader; command.CommandText = "select * from productos WHERE id =" + id;
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    texto[0] = (Reader["producto"].ToString());
                    texto[1] = (Reader["precio"].ToString());
                    texto[2] = (Reader["inventario"].ToString());
                }
                connection.Close();
                Reader.Close();
 
            }   
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
           
            }
            return texto;
        }

    }
}
