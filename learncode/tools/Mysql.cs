using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace learncode.tools
{
    public class Mysql
    {
        string connStr = $"server =172.17.51.1;port=3306;database=WICSDB_SYF;user=wics;password=wics;SslMode=None;Connect Timeout=180;pooling=true;charset=utf8";

        public void Execute(string sql)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connStr);
            mySqlConnection.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql,mySqlConnection))
            {
                int res=cmd.ExecuteNonQuery();
                Console.WriteLine(res+"\n"+sql);
            }

        }



    }
}
