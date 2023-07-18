// CPlus.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include<fstream>
#include <vector>
#include <algorithm>
#include<string>
#include<thread>
#include "MySqlModel.cpp"

using namespace std;

int main()
{
#pragma region MyRegion
	/*ifstream reader("D:/test.txt");
	vector<int> list;
	string str;
	while (getline(reader, str))
	{
		string num;
		for (int i = 0; i < str.length(); ++i)
		{
			if (str[i] == '-')
			{
				if (num.length() == 1 && num[0] == '-')
					continue;
				if (num.length() > 0)
				{
					list.push_back(stoi(num));
					num.clear();
				}
				num += '-';
			}
			else if (isdigit(str[i]))
			{
				num += str[i];
				if(i==str.length()-1)
					list.push_back(stoi(num));
			}
			else
			{
				if (num.length() == 1 && num[0] == '-' || num.length() == 0)
				{
					num.clear();
				}
				else
				{
					list.push_back(stoi(num));
					num.clear();
				}
			}
		}
	}
	sort(list.begin(), list.end());
	int sum = 0;
	string res;
	for (int n : list)
	{
		sum += n;
		if (n >= 0)
		{
			res += "+";
		}
		res += to_string(n);
	}
	std::cout << res<<"="<<sum; */
#pragma endregion

	MySqlModel sqlModel;
	sqlModel.connect();

}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
