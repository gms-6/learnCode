//#include <mysql.h>
#include <iostream>
using namespace std;

class MySqlModel
{
public:
	bool connect()
	{
		/*MYSQL* conn = mysql_init(nullptr);
		bool res = mysql_real_connect(conn, "localhost", "root", "123456", "wicsdb_fawde_block", 3306, nullptr, 0) == nullptr;
		if (!res)
			cout << "���ӳɹ�" << endl;
		else
		{
			cout << "����ʧ��" << endl;
			return false;
		}
		string sql1 = "SELECT * FROM user_info";
		int res1 = mysql_query(conn, sql1.c_str());
		if (res1 == 0)
		{
			cout << "��ѯ�ɹ�" << endl;
		}
		else
		{
			cout << "��ѯʧ��" << endl;
			return false;
		}
		MYSQL_RES* result = mysql_store_result(conn);
		int colNum = mysql_num_fields(result);
		if (result != nullptr)
		{
			MYSQL_ROW row;
			while ((row = mysql_fetch_row(result)))
			{
				for (int i = 0; i < colNum; ++i)
				{
					cout << row[i] << "\t";
				}
				cout << endl;
			}
			mysql_free_result(result);
		}
		mysql_close(conn);*/
		return true;
		
	}

};