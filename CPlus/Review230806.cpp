#include <vector>
#include<algorithm>
#include <iostream>

using namespace std;

class Review230806
{
	
public:
	vector<vector<int>> premute(vector<int>& nums)
	{
			int n = nums.size();
			vector<vector<int>> res;
			vector<bool> status;
			vector<int> output;
			status.assign(n,false);
			backtrack(res, output, status, nums);
			for (auto tmp1 : res)
			{
				for (auto tmp2 : tmp1)
				{
					cout << tmp2 << " ";
				}
				cout << endl;
			}
			return res;
	}
	void backtrack(vector<vector<int>>& res,vector<int>&output,vector<bool>& status,vector<int>& nums)
	{
		if (output.size() == nums.size())
		{
			res.push_back(output);
			return;
		}
		for (int i = 0; i < nums.size(); ++i)
		{
			if (!status[i])
			{
				status[i] = true;
				output.push_back(nums[i]);
				backtrack(res,output,status,nums);
				output.pop_back();
				status[i] = false;;
			}
		}
	}
};