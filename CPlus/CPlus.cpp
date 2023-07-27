// CPlus.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include<fstream>
#include <vector>
#include <algorithm>
#include<string>
#include<thread>
#include <map>
#include <set>
#include <unordered_map>
#include<math.h>
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

#pragma region MyRegion
	/*MySqlModel sqlModel;
	sqlModel.connect();*/
#pragma endregion

#pragma region vector
	//front back
	//begin end
	//cbegin cend
	//crbegin crend
	//rbegin rend
	//push_back pop_back
	//vector<int> ve;
	//ve.assign(6,6);
	///*for (auto num : ve)
	//{
	//	cout << num << endl;
	//}*/
	//vector<int>::iterator beg;
	//vector<int>::const_reverse_iterator crbeg;
	//for (crbeg = ve.crbegin(); crbeg != ve.crend(); crbeg++)
	//{
	//	cout << *crbeg << endl;
	//}
#pragma endregion

#pragma region 1
/*string s1;
getline(cin, s1);
int res = 0;
for (int i = s1.size() - 1; i >= 0; i--)
{
	if (s1[i] == ' ')
	{
		break;
	}
	else
	{
		res++;
	}

}
cout << res;*/
#pragma endregion

#pragma region 2
/*string str;
getline(cin, str);
char tar, low, up;
cin >> tar;
int res = 0;
low = tolower(tar);
up = toupper(tar);
for (int i = 0; i < str.size(); ++i)
{
	if (str[i] == low || str[i] == up)
		res++;
}
cout << res;*/
#pragma endregion

#pragma region 3
//int nums[501];
	//int count;
	//cin >> count;
	//int num;
	//vector<int> vec;
	//vec.assign(501,0);

	////map<int, int> map1;
	//map<int, int, std::greater<int>> map1;
	//set<int, less<int>> map2;
	//for (int i = 0; i < count; ++i)
	//{
	//	cin >> num;
	//	map2.insert(num);
	//	/*auto ite = map2.find(num);
	//	if (ite == map1.end() && map1[num] == 0)
	//	{
	//		map1[num] = 1;
	//	}*/
	//}
	//for (auto tmp : map2)
	//{
	//	cout << tmp << endl;
	//}
	///*for (int i = 0; i < 501; ++i)
	//{
	//	if (vec[i] != 0)
	//	{
	//		cout << i << endl;
	//	}
	//}*/
#pragma endregion

#pragma region 4
/*string src;
	getline(cin,src);
	int rep = 0;
	string str;
	for (int i = 0; i < src.size(); ++i)
	{

		str.push_back(src[i]);
		rep++;
		if (rep == 8)
		{
			rep = 0;
			cout << str << endl;
			str.clear();
		}
	}
	if (str.size() != 0)
	{
		for (int i = 0; i < 8 - rep; ++i)
		{
			str.push_back('0');
		}
		cout << str;
	}*/
#pragma endregion

#pragma region 5
	/*string str;
		getline(cin,str);
		unordered_map<char, int> unmap;
		unmap['0'] = 0;
		unmap['1'] = 1;
		unmap['2'] = 2;
		unmap['3'] = 3;
		unmap['4'] = 4;
		unmap['5'] = 5;
		unmap['6'] = 6;
		unmap['7'] = 7;
		unmap['8'] = 8;
		unmap['9'] = 9;
		unmap['A'] = 10;
		unmap['B'] = 11;
		unmap['C'] = 12;
		unmap['D'] = 13;
		unmap['E'] = 14;
		unmap['F'] = 15;
		int res = 0;
		int pow1 = 0;
		for (int i = str.size() - 1; i > 1; --i)
		{
			res = unmap[str[i]] * pow(16, pow1++) + res;
		}
		cout << res;*/
#pragma endregion

#pragma region 6
		/*int num = 0;
			cin >> num;
			int target = num;
			string res;
			for (int i = 2; i <= sqrt(num); ++i)
			{
				while (target % i == 0)
				{
					res =res+ to_string( i)+" ";
					target /= i;
				}
			}
			if (target != 1)
				res+= to_string(target);
			cout << res;*/
#pragma endregion

#pragma region 8
			/*map<int, int> tablemap;
				int count;
				cin >> count;
				string inputStr;
				for (int i = 0; i < count; ++i)
				{
					getline(cin,inputStr);
					int a, b;
					cin >> a >> b;
					tablemap[a]+=b;
				}
				for (pair<int, int> tmp : tablemap)
				{
					cout << tmp.first << " " << tmp.second << endl;
				}*/
#pragma endregion

#pragma region 9
				/*set<char> HashSet;
					string num;
					getline(cin,num);

					for (int i = num.size() - 1; i >= 0; --i)
					{
						auto ite = HashSet.find(num[i]);
						if (ite == HashSet.end())
						{
							HashSet.insert(num[i]);
							cout << num[i];
						}
					}*/
#pragma endregion

#pragma region MyRegion
					/*vector<int> numSet;
						numSet.assign(128,0);
						string str;
						getline(cin, str);
						int res = 0;
						for (int i = 0; i < str.size(); ++i)
						{
							if (str[i] >= 0 && str[i] <= 127 && numSet[str[i]] == 0)
							{
								res += 1;
								numSet[str[i]] += 1;
							}
						}
						cout << res;*/
#pragma endregion

#pragma region MyRegion
						/*string str;
							getline(cin,str);
							for (int i = str.size()-1; i >=0; --i)
							{
								cout << str[i];
							}*/
#pragma endregion

#pragma region MyRegion
							/*string str;
								while (getline(cin, str))
								{
									vector<string> list1;
									string tmp;
									for (int i = 0; i < str.size(); ++i)
									{
										if (str[i] == ' ')
										{
											list1.push_back(tmp);
											tmp.clear();
										}
										else
										{
											tmp.push_back(str[i]);
										}
									}
									if (!tmp.empty())
										list1.push_back(tmp);
									for (int i = list1.size() - 1; i >= 0; i--)
									{
										if (i == 0)
										{
											cout << list1[i];
										}
										else
										{
											cout << list1[i] << " ";
										}
									}
								}*/
#pragma endregion

#pragma region MyRegion
								/*int count = 0;
									cin >> count;
									vector<string> list;
									for (int i = 0; i < count; ++i)
									{
										string tmp;
										cin >> tmp;
										list.push_back(tmp);
									}
									sort(list.begin(),list.end());
									for (string s : list)
										cout << s<<endl;*/
#pragma endregion

#pragma region MyRegion
										/*int num;
											cin >> num;
											int res = 0;
											while (num != 0)
											{
												if ((num & 1) == 1)
												{
													res++;
												}
												num >>= 1;
											}
											cout << res;*/
#pragma endregion

#pragma region 16 未完成
											/*int totalMon,count;
												cin >> totalMon >> count;
												vector<int[]> list;
												vector<int> dp;
												vector<int> select;
												dp.assign(totalMon+1,0);
												select.assign(count,0);
												for (int i = 0; i < count; ++i)
												{
													int v, p, q;
													cin >> v >> p >> q;
													list.push_back({v,p,q});
												}

												for (int i = 1; i <= count; ++i)
												{
													if (list[i - 1][2] == 0)
													{
														for (int j = totalMon; j >= list[i - 1][0]; j--)
														{
															if (dp[j] < dp[j - list[i - 1][0]])
															{
																select[i - 1] = 1;
															}
														}
													}
												}*/
#pragma endregion

	string str;
	int x = 0, y = 0;
	string tmp;
	while (getline(cin, str, ';'))
	{
		if (str.size() >= 2 && str.size() <= 3&&(str[0]=='A'||str[0]=='D'||str[0]=='W'||str[0]=='S'))
		{
			bool res = false;
			int step = 0;
			if (str.size() == 2 && str[1] >= '1' && str[1] <= '9')
			{
				res = true;
				step = str[1] - '0';
			}
			else if (str.size() == 3 && str[1] >= '1' && str[1] <= '9' && str[2] >= '0' && str[2] <= '9')
			{
				res = true;
				step = (str[1] - '0') * 10 + str[2] - '0';
			}
			if (res)
			{
				if (str[0] == 'A')
				{
					x -= step;
				}
				else if (str[0] == 'D')
				{
					x += step;
				}
				else if (str[0] == 'W')
				{
					y += step;
				}
				else if (str[0] == 'S')
				{
					y -= step;
				}
			}

		}
	}
	cout << x << "," << y;


	return 0;

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
