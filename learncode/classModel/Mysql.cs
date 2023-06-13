using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel
{
    public class Mysql
    {
        string server = "127.0.0.1";
        string port = "3306";
        string database = "learn";
        string user = "root";
        string password = "";
        
        public Mysql(string host,string database,string user,string password)
        {
            server = host;
            this.database = database;
            this.user= user;
            this.password= password;
        }

    }
}
