using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace learncode.tools
{
    public class Mysql
    {
        string connStr = $"server =;port=3306;database=WICSDB_SYF;user=wics;password=wics;SslMode=None;Connect Timeout=180;pooling=true;charset=utf8";

        public void Execute(string sql)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connStr);
            mySqlConnection.Open();
            using (MySqlCommand cmd = new MySqlCommand(sql,mySqlConnection))
            {
                int res=cmd.ExecuteNonQuery();
                Console.WriteLine(res+"\n"+sql);
            }
            DataTable dt=new DataTable();
            using (MySqlDataAdapter da=new MySqlDataAdapter(sql,mySqlConnection))
            {
                da.Fill(dt);
                
            }


        }

        public T Calc<T>(T a,T b)
            where T:struct
        {
            return a;
        }



    }
}
