using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel
{
    public  class MyBag
    {

        public int NPMulti(int[] v1, int[] wei, int[] count ,int m)
        {
            int n = v1.Length;
            IList<int> v = new List<int>();
            IList<int> w = new List<int>();
            long cnt = 1;
            v.Add(0);
            w.Add(0);
            for(long i=1;i<=n;++i)
            {
                for(long j = 1; j <= count[i];++i)
                {
                    v.Add(v1[i-1]);
                    w.Add(wei[i-1]);
                    cnt++;
                }
            }
            return 0;
        }
        public int NPFull(int[] v, int[] w,int m)
        {
            int n = v.Length;
            //int[][] dp = new int[n+1][];
            int[] dp = new int[n+1];
            //for(int i=0;i<n+1;i++)
            //{
            //    dp[i] = new int[m + 1];
            //}
            for(int i=1;i<=n;++i)
            {
                for (int j = v[i-1]; j <= m; ++j)
                    dp[j] = Math.Max(dp[j], dp[j - v[i - 1]] + w[i-1]);
            }
            return dp[m];
            //for(int i=1;i<n+1;i++)
            //{
            //    for(int j=1;j<m+1;j++)
            //    {
            //        dp[i][j] = dp[i - 1][j];
            //        if (j >= v[i-1])
            //            dp[i][j] = Math.Max(dp[i][j], dp[i][j - v[i - 1]] + w[i-1]);
            //    }
            //    Show(dp);
            //}
            //return dp[n][m];
        }

        public int NP01(int[] v, int[] w,int m)
        {
            int n = v.Length;
            //int[][] dp = new int[n+1][];
            int[] dp = new int[m + 1];
            //for(int i = 0; i <= n; i++)
            //{
            //    dp[i] = new int[m+1];
            //}
            for (int i = 1; i <= n; ++i)
            {
                for(int j = m; j >= v[i-1];--j)
                {
                    dp[j] = Math.Max(dp[j], dp[j - v[i - 1]] + w[i-1]);
                }
                Show(dp);
            }
            return dp[m];
            //for(int i=1;i<=n;++i)
            //{
            //    for(int j=1;j<=m;++j)
            //    {
            //        dp[i][j] = dp[i - 1][j];
            //        if (j >= v[i-1])
            //            dp[i][j] = Math.Max(dp[i][j], dp[i - 1][j - v[i-1]] + w[i-1]);
            //    }
            //    Show(dp);
            //}
            //return dp[n][m];

        }

        private void Show(int[][] dp)
        {
            int m = dp.Length;
            int n = dp[0].Length;
            for(int i=0;i<m;++i)
            {
                for(int j=0;j<n;++j)
                {
                    Console.Write(dp[i][j].ToString().PadRight(5));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private void Show(int[] dp)
        {
            int n = dp.Length;
            for (int i = 0; i < n; ++i)
            {
                Console.Write(dp[i].ToString().PadRight(5));
            }
            Console.WriteLine();
        }
    }
}
