#include <mysql.h>
#include <iostream>
using namespace std;

class MySqlModel
{
public:
	bool connect()
	{
		MYSQL* conn = mysql_init(nullptr);
		bool res = mysql_real_connect(conn, "localhost", "root", "123456", "wicsdb_fawde_block", 3306, nullptr, 0) == nullptr;
		if (!res)
			cout << "连接成功" << endl;
		else
		{
			cout << "连接失败" << endl;
			return false;
		}
		string sql1 = "SELECT * FROM user_info";
		int res1 = mysql_query(conn, sql1.c_str());
		if (res1 == 0)
		{
			cout << "查询成功" << endl;
		}
		else
		{
			cout << "查询失败" << endl;
			return false;
		}
		MYSQL_RES* result = mysql_store_result(conn);
		if (result != nullptr)
		{
			MYSQL_ROW row;
			while ((row = mysql_fetch_row(result)))
			{
				cout << row[0] << "\t" << row[1] << "\t" << row[2] << "\t" << row[3] << endl;;
			}
			mysql_free_result(result);
		}
		mysql_close(conn);
		return true;
		
	}

};