using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel
{
    public class Mysql
    {
        string connSer = "server=localhost;database=learn;uid=root;pwd=123456";

        public Mysql()
        {
        }
        public void TransactionMethod()
        {
            using (MySqlConnection connect = new MySqlConnection(connSer))
            {
                MySqlTransaction trans = null;
                try
                {
                    connect.Open();
                    trans = connect.BeginTransaction();
                    MySqlCommand cmd = connect.CreateCommand();
                    cmd.Transaction = trans;
                    cmd.CommandText = "update tb_user as tb set tb.name=@name_1 where tb.id=@id_1;";
                    cmd.Parameters.Clear();
                    MySqlParameter[] parameters = new MySqlParameter[]
                    {
                    new MySqlParameter("@name_1","小王"),
                    new MySqlParameter("@id_1",1)
                    };
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    trans.Commit();
                    Console.WriteLine("事务执行成功");
                }
                catch (MySqlException ex)
                {
                    trans.Rollback();
                    Console.WriteLine("事务执行失败，回滚");
                }
                finally
                {
                    trans.Dispose();
                    connect.Close();
                }
            }
        }
        private void Show()
        {
            using (MySqlConnection connect = new MySqlConnection(connSer))
            {
                string cmdStr = "select * from tb_user;";
                MySqlCommand cmd = new MySqlCommand(cmdStr, connect);
                var reader = cmd.ExecuteReader();
            }
        }

    }
}
