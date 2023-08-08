#include <vector>
#include<algorithm>
#include <iostream>
#include "TreeNode.cpp"

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
		status.assign(n, false);
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
	void backtrack(vector<vector<int>>& res, vector<int>& output, vector<bool>& status, vector<int>& nums)
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
				backtrack(res, output, status, nums);
				output.pop_back();
				status[i] = false;;
			}
		}
	}

	vector<int> PreOrderTraversal(TreeNode* root)
	{
		vector<int> list;
		PreOrderTraversalDFS(root, list);
		return list;
	}
	void PreOrderTraversalDFS(TreeNode* root, vector<int>& list)
	{
		if (root == nullptr)
			return;
		list.push_back(root->val);
		PreOrderTraversalDFS(root->left,list);
		PreOrderTraversalDFS(root->right,list);
	}

	vector<int> InOrderTraversal(TreeNode* root)
	{
		vector<int> list;
		InOrderTraversalDFS(root,list);
		return list;
	}
	void InOrderTraversalDFS(TreeNode* root,vector<int>& list)
	{
		if (root == nullptr)
			return;
		InOrderTraversalDFS(root->left,list);
		list.push_back(root->val);
		InOrderTraversalDFS(root->right,list);
	}

	
	vector<int> PostOrderTraversal(TreeNode* root)
	{
		vector<int> list;
		PostOrderTraversalDFS(root,list);
		return list;
	}
	void PostOrderTraversalDFS(TreeNode* root,vector<int>& list)
	{
		if (root == nullptr)
			return;
		PostOrderTraversalDFS(root->left,list);
		PostOrderTraversalDFS(root->right,list);
		list.push_back(root->val);
	}


	/*输入： nums = [4, 3, 2, 3, 5, 2, 1], k = 4
		输出： True
		说明： 有可能将其分成 4 个子集（5），（1, 4），（2, 3），（2, 3）等于总和。*/
	bool CanPartitionKSubsets1(vector<int> &nums,int k)
	{
		int sum = 0;
		for (int num : nums)
		{
			sum += num;
		}
		if (sum % k != 0)
			return false;
		int target = sum / k;
		vector<int> bucket(k, target);
		sort(nums.begin(),nums.end(),greater<int>());
		return CanPartitionKSubsets1DFS(nums,0,k,bucket);
	}
	bool CanPartitionKSubsets1DFS(vector<int> &nums, int t, int k, vector<int> &bucket)
	{
		if (t == nums.size())
		{
			return true;
		}
		else
		{
			for (int i = 0; i < k; ++i)
			{
				if (i > 0 && bucket[i - 1] == bucket[i])
					continue;
				if (bucket[i] >= nums[t])
				{
					bucket[i] -= nums[t];
					bool tmp = CanPartitionKSubsets1DFS(nums, t + 1, k, bucket);
					if (tmp)
						return true;
					bucket[i] += nums[t];
				}
			}
			return false;
		}
	}

};