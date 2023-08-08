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

};