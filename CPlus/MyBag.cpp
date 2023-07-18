#include <vector>
#include<math.h>
using namespace std;


class MyBag
{
public:
	int NP01(vector<int> v, vector<int> w, int m)
	{
		int n = v.size();
		vector<int> dp;
		dp.reserve(n+1);
		for (int i = 1; i <= n; ++i)
		{
			for (int j = m; j >= v[i - 1]; --j)
			{
				dp[j] = max(dp[j], dp[j - v[i - 1] + w[i - 1]]);
			}
		}
		return dp[n];
	}

	int NPFull(vector<int> v, vector<int> w,int m)
	{
		int n = v.size();
		vector<int> dp(n+1);
		
		for (int i = 1; i <= n; ++i)
		{
			for (int j = v[i - 1]; j <= m; ++j)
			{
				dp[j] = max(dp[j], dp[j - v[i - 1]] + w[i - 1]);
			}
		}
		return dp[n];
	}
};