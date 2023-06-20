using learncode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode
{
    public class Review
    {
        Dictionary<Node, Node> cacheNode = new Dictionary<Node, Node>();
        public ListNode tempHead = new ListNode(0);

        IList<IList<int>> list;
        IList<int> cap;

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            int n = intervals.Length;
            int left = newInterval[0];
            int right = newInterval[1];
            bool placed = false;
            List<int[]> ansList = new List<int[]>();
            foreach (var interval in intervals)
            {
                if(interval[0]>right)
                {
                    if(!placed)
                    {
                        ansList.Add(new int[] { left,right});
                        placed = true;
                    }
                    ansList.Add(interval);
                }
                else if(interval[1]<left)
                {
                    ansList.Add(interval);
                }
                else
                {
                    left = Math.Min(left,interval[0]);
                    right = Math.Max(right,interval[1]);
                }
            }
            if (!placed)
                ansList.Add(new int[] {left,right});
            int[][] ans = new int[ansList.Count][];
            for(int i=0;i<ansList.Count;++i)
            {
                ans[i] = ansList[i];
            }
            return ans;
        }
        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            dp[0] = 1;
            int max = 1;
            for (int i = 1; i < n; ++i)
            {
                dp[i] = 1;
                for (int j = 0; j < i; ++j)
                {
                    if (nums[j] < nums[i])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                if (dp[i] > max)
                    max = dp[i];
            }
            return max;
        }

        public string RemoveKdigits(string num, int k)
        {
            int n = num.Length;
            LinkedList<char> deque = new LinkedList<char>();
            int length = num.Length;
            for (int i = 0; i < length; ++i)
            {
                char digit = num[i];
                while (deque.Count != 0 && k > 0 && deque.Last.Value > digit)
                {
                    deque.RemoveLast();
                    k--;
                }
                deque.AddLast(digit);
            }
            for (int i = 0; i < k; ++i)
            {
                deque.RemoveLast();
            }
            StringBuilder ret = new StringBuilder();
            bool leadingZero = true;
            while (deque.Count != 0)
            {
                char digit = deque.First.Value;
                deque.RemoveFirst();
                if (leadingZero && digit == '0')
                    continue;
                leadingZero = false;
                ret.Append(digit);
            }
            return ret.Length == 0 ? "0" : ret.ToString();
        }
        public string RemoveFrontZero(string num)
        {
            int k = 0;
            int n = num.Length;
            for (int i = 0; i < n; ++i)
            {
                if (num[i] == '0')
                {
                    while (i < n && num[i] == '0')
                    {
                        i++;
                    }
                    k = i;
                    break;
                }
                else
                    break;
            }
            if (k == n)
                return "0";
            else
            {
                return num.Substring(k, n - k);
            }
        }
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            IList<string> ans = new List<string>();
            for (int h = 0; h < 12; ++h)
            {
                for (int m = 0; m < 60; ++m)
                {
                    if (BitCountWhile(h) + BitCountWhile(m) == turnedOn)
                    {
                        ans.Add(h + ":" + (m < 10 ? "0" : "") + m);
                    }
                }
            }
            return ans;

        }
        public int BitCountWhile(int i)
        {
            int count = 0;
            while (i != 0)
            {
                if ((i & 1) == 1)
                    count++;
                i >>= 1;
            }
            return count;
        }
        private int BitCount(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i = i + (i >> 8);
            i = i + (i >> 16);
            return i & 0x3f;
        }
        public int MyAtoi(string s)
        {
            long result = 0;
            int positive = 1;
            List<char> list = new List<char>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] == ' ')
                    continue;
                if (s[i] == '-')
                    positive = -1;
                if (s[i] >= 48 && s[i] <= 57)
                {
                    int k = i;
                    while (k < s.Length && (s[k] >= 48 && s[k] <= 57))
                    {
                        list.Add(s[k]);
                        k++;
                    }
                    break;
                }
            }
            int pow = 1;
            for (int i = list.Count - 1; i >= 0; --i)
            {
                result = result + (list[i] - '0') * pow;
                pow *= 10;
                if (result * positive < int.MinValue)
                {
                    result = int.MinValue;
                    break;
                }
                else if (result * positive > int.MaxValue)
                {
                    result = int.MaxValue;
                    break;
                }
            }
            return (int)result * positive;

        }
        public int FindNthDigit(int n)
        {
            int count = 0;
            double num = 9;
            double sum = 0;
            while (n > sum)
            {
                count += 1;
                sum += num * count;
                num *= 10;
            }
            num /= 10;
            sum -= num * count;
            string target = ((int)((n - sum - 1) / count)).ToString();
            int yu = (int)((n - sum - 1) % count);
            if (target.Length == count - 1)
            {
                if (yu == 0)
                    return 1;
                else
                    return target[yu - 1] - '0';
            }
            else
                return target[yu] - '0';
        }
        public int AddMinimum(string word)
        {
            int n = word.Length;
            int count = 0;
            for (int i = 0; i < n; ++i)
            {
                if (word[i] == 'c')
                    count += 2;
                else if (word[i] == 'b')
                {
                    if (i + 1 < n)
                    {
                        if (word[i + 1] == 'c')
                        {
                            count += 1;
                            i += 1;
                        }
                        else
                        {
                            count += 2;
                        }
                    }
                    else
                    {
                        count += 2;
                    }
                }
                else if (word[i] == 'a')
                {
                    if (i == n - 1)
                    {
                        count += 2;
                    }
                    else
                    {
                        if (word[i + 1] == 'b')
                        {
                            if (i + 1 == n - 1)
                            {
                                i = i + 1;
                                count += 1;
                            }
                            else
                            {
                                if (word[i + 2] == 'c')
                                {
                                    i += 2;
                                }
                                else
                                {
                                    i += 1;
                                    count += 1;
                                }
                            }
                        }
                        else if (word[i + 1] == 'c')
                        {
                            i += 1;
                            count += 1;
                        }
                        else
                            count += 2;
                    }
                }

            }
            return count;

        }
        public string DecodeString(string s)
        {
            int n = s.Length;
            Stack<char> stack = new Stack<char>();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < n; ++i)
            {
                if (stack.Count == 0 && !(s[i] >= 48 && s[i] <= 57))
                    str.Append(s[i]);
                else if (s[i] == ']')
                {
                    StringBuilder tmp = new StringBuilder();
                    while (stack.Peek() != '[')
                    {
                        tmp.Append(stack.Pop());
                    }
                    stack.Pop();
                    string strTmp = tmp.ToString();
                    tmp.Clear();
                    for (int j = strTmp.Length - 1; j >= 0; --j)
                    {
                        tmp.Append(strTmp[j]);
                    }
                    strTmp = tmp.ToString();
                    int count = 0;
                    int index = 0;
                    while (stack.Count > 0 && stack.Peek() >= 47 && stack.Peek() <= 57)
                    {
                        count = (int)(count + (stack.Pop() - '0') * Math.Pow(10, index++));
                    }
                    for (int j = 0; j < count; j++)
                    {
                        if (stack.Count == 0)
                        {
                            str.Append(strTmp);
                        }
                        else
                        {
                            for (int k = 0; k < strTmp.Length; ++k)
                            {
                                stack.Push(strTmp[k]);
                            }
                        }
                    }
                }
                else
                {
                    stack.Push(s[i]);
                }
            }
            return str.ToString();

        }
        public bool IsPerfectSquare(int num)
        {
            double x0 = num;
            double x1 = (x0 + num / x0) / 2;
            while (Math.Abs(x1 - x0) > 1e-6)
            {
                x0 = x1;
                x1 = (x0 + num / x0) / 2;
            }
            int x2 = (int)x0;
            return x2 * x2 == num;

            //if (num == 1)
            //    return true;
            //long l = 1;
            //long r = num;
            //long mid = l + (r - l) / 2;
            //while (r - l > 1)
            //{
            //    mid = l + (r - l) / 2;
            //    if (mid * mid > num)
            //        r = mid;
            //    else if (mid * mid < num)
            //        l = mid;
            //    else
            //        return true;
            //}
            //if (l * l == num || r * r == num)
            //    return true;
            //else
            //    return false;
            //
        }
        public bool CanMeasureWater(int jug1Capacity, int jug2Capacity, int targetCapacity)
        {
            if (targetCapacity == 0)
                return true;
            if (jug1Capacity + jug2Capacity < targetCapacity)
                return false;
            int big = Math.Max(jug1Capacity, jug2Capacity);
            int small = jug1Capacity + jug2Capacity - big;
            while (big % small != 0)
            {
                int temp = small;
                small = big % small;
                big = temp;
            }
            return targetCapacity % small == 0;

        }
        public int GCD(int a, int b)
        {
            //while(b!=0)
            //{
            //    int r = a % b;
            //    a = b;
            //    b = r;
            //}
            //return b;
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int[] dp = new int[n];
            for (int i = 0; i < n; ++i)
                dp[i] = 1;
            int maxSize = 1;
            int maxVal = dp[0];
            for (int i = 1; i < n; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (nums[i] % nums[j] == 0)
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                if (maxSize < dp[i])
                {
                    maxSize = dp[i];
                    maxVal = nums[i];
                }
            }
            IList<int> res = new List<int>();
            if (maxSize == 1)
            {
                res.Add(nums[0]);
                return res;
            }
            for (int i = n - 1; i >= 0 && maxSize > 0; --i)
            {
                if (dp[i] == maxSize && maxVal % nums[i] == 0)
                {
                    res.Add(nums[i]);
                    maxVal = nums[i];
                    maxSize--;
                }
            }
            return res;

        }
        public int CountNumbersWithUniqueDigits(int n)
        {
            int total = (int)Math.Pow(10, n);
            int count = 0;
            for (int i = 0; i < total; ++i)
            {
                HashSet<int> hash = new HashSet<int>();
                bool res = true;
                int temp = i;
                while (temp != 0)
                {

                    if (!hash.Add(temp % 10))
                    {
                        res = false;
                        break;
                    }
                    temp /= 10;
                }
                if (res)
                    count++;
            }
            return count;

        }
        public IList<TreeNode> GenerateTrees(int n)
        {
            return GenerateTreesDFS(1, n);
        }
        public IList<TreeNode> GenerateTreesDFS(int start, int end)
        {
            IList<TreeNode> allTrees = new List<TreeNode>();
            if (start > end)
            {
                allTrees.Add(null);
                return allTrees;
            }
            for (int i = start; i <= end; ++i)
            {
                IList<TreeNode> leftTrees = GenerateTreesDFS(start, i - 1);
                IList<TreeNode> rightTrees = GenerateTreesDFS(i + 1, end);
                foreach (var left in leftTrees)
                {
                    foreach (var right in rightTrees)
                    {
                        TreeNode curr = new TreeNode();
                        curr.left = left;
                        curr.right = right;
                        allTrees.Add(curr);
                    }
                }
            }
            return allTrees;
        }



        //public IList<TreeNode> GenerateTrees(int n)
        //{
        //    if (n == 0)
        //        return new List<TreeNode>();
        //    return GenerateTreesDFS(1,n);
        //}
        //public IList<TreeNode> GenerateTreesDFS(int start,int end)
        //{
        //    IList<TreeNode> allTrees = new List<TreeNode>();
        //    if(start>end)
        //    {
        //        allTrees.Add(null);
        //        return allTrees;
        //    }
        //    for(int i=start;i<=end;++i)
        //    {
        //        IList<TreeNode> left = GenerateTreesDFS(start,i-1);
        //        IList<TreeNode> right = GenerateTreesDFS(i+1,end);
        //        foreach(var l in left)
        //        {
        //            foreach(var r in right)
        //            {
        //                TreeNode currTree = new TreeNode(i);
        //                currTree.left = l; 
        //                currTree.right = r;
        //                allTrees.Add(currTree);
        //            }
        //        }
        //    }
        //    return allTrees;
        //}
        public string AddBinary(string a, string b)
        {
            int an = a.Length;
            int bn = b.Length;
            List<int> list = new List<int>();
            int add = 0;
            int i = an - 1, j = bn - 1;
            while (i >= 0 || j >= 0)
            {
                int sum1 = 0;
                int sum2 = 0;
                int sum = 0;
                if (i >= 0)
                {
                    sum1 = int.Parse(a[i].ToString());
                    i--;
                }
                if (j >= 0)
                {
                    sum2 = int.Parse(b[j].ToString());
                    j--;
                }
                sum = sum1 + sum2 + add;
                add = sum / 2;
                list.Add(sum % 2);
            }
            if (add != 0)
                list.Add(add);
            StringBuilder sb = new StringBuilder();
            for (int k = list.Count - 1; k >= 0; k--)
            {
                sb.Append(list[k]);
            }
            return sb.ToString();

        }
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }
            string ans = "0";
            int m = num1.Length, n = num2.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                StringBuilder curr = new StringBuilder();
                int add = 0;
                for (int j = n - 1; j > i; j--)
                {
                    curr.Append(0);
                }
                int y = num2[i] - '0';
                for (int j = m - 1; j >= 0; j--)
                {
                    int x = num1[j] - '0';
                    int product = x * y + add;
                    curr.Append(product % 10);
                    add = product / 10;
                }
                if (add != 0)
                {
                    curr.Append(add % 10);
                }
                ans = AddStrings(ans, new string(curr.ToString().Reverse().ToArray()));
            }
            return ans;


        }
        private string AddStrings(string num1, string num2)
        {
            int i = num1.Length - 1, j = num2.Length - 1, add = 0;
            StringBuilder ans = new StringBuilder();
            while (i >= 0 || j >= 0 || add != 0)
            {
                int x = i >= 0 ? num1[i] - '0' : 0;
                int y = j >= 0 ? num2[j] - '0' : 0;
                int result = x + y + add;
                ans.Append(result % 10);
                add = result / 10;
                i--;
                j--;
            }
            return new string(ans.ToString().Reverse().ToArray());
        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            int n = candidates.Length;
            list = new List<IList<int>>();
            cap = new List<int>();
            Array.Sort(candidates);
            CombinationSum2DFS(0, target, candidates, 0);
            return list;
        }
        public void CombinationSum2DFS(int sum, int target, int[] candidates, int index)
        {
            if (sum == target)
            {
                list.Add(new List<int>(cap));
            }
            else if (sum < target)
            {
                for (int i = index; i < candidates.Length; ++i)
                {
                    if (i > index && candidates[i] == candidates[i - 1])
                        continue;
                    cap.Add(candidates[i]);
                    CombinationSum2DFS(sum + candidates[i], target, candidates, i + 1);
                    cap.RemoveAt(cap.Count - 1);


                }
            }
        }
        public bool IsValidSudoku(char[][] board)
        {
            int n = board.Length;
            int[,] rows = new int[9, 9];
            int[,] columns = new int[9, 9];
            int[,,] subboxes = new int[3, 3, 9];
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    char c = board[i][j];
                    if (c != '.')
                    {
                        int index = c - '0' - 1;
                        rows[i, index]++;
                        columns[j, index]++;
                        subboxes[i / 3, j / 3, index]++;
                        if (rows[i, index] > 1 || columns[j, index] > 1 || subboxes[i / 3, j / 3, index] > 1)
                            return false;
                    }
                }
            }
            return true;
        }
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;
            int i = n - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
                i--;
            if (i >= 0)
            {
                int j = n - 1;
                while (j >= 0 && nums[i] >= nums[j])
                    j--;
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
            int count = 0;
            for (int j = i + 1; j < n - 1 - count; ++j)
            {
                int temp = nums[j];
                nums[j] = nums[n - 1 - count];
                nums[n - 1 - count] = temp;
                count++;
            }

        }
        public string Convert1(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            List<List<char>> list = new List<List<char>>(numRows);
            for (int i = 0; i < numRows; ++i)
                list.Add(new List<char>());
            int flag = 1;
            int row = 0;

            for (int i = 0; i < s.Length; ++i)
            {
                list[row].Add(s[i]);
                row += flag;
                if (row == numRows - 1 || row == 0)
                    flag = -flag;
            }
            string res = "";
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = 0; j < list[i].Count; ++j)
                {
                    res += list[i][j];
                }
            }
            return res;
        }
        public int MinimumVisitedCells(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            if (m == 1 && n == 1)
                return 0;
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            return dp[m - 1, n - 1] == 0 ? -1 : dp[m - 1, n - 1];
        }
        public long[] Distance(int[] nums)
        {
            int n = nums.Length;
            long[] arr = new long[n];

            if (n == 1)
            {
                arr[0] = 0;
                return arr;
            }
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; ++i)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], new List<int>(i));
                }
                else
                {
                    foreach (var temp in dic[nums[i]])
                    {
                        arr[i] += Math.Abs(i - temp);
                        arr[temp] += Math.Abs(i - temp);
                    }
                    dic[nums[i]].Add(i);
                }
            }
            return arr;
        }
        public int DiagonalPrime(int[][] nums)
        {
            int n = nums.Length;
            int max = int.MinValue;
            HashSet<int> hash = new HashSet<int>();
            bool flag = false;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (!hash.Contains(nums[i][j]))
                    {
                        if (i == j && DiagonalPrimeIsPrime(nums[i][j]))
                        {
                            flag = true;
                            hash.Add(nums[i][j]);
                            if (nums[i][j] > max)
                                max = nums[i][j];
                        }
                        if (j == n - 1 - i && DiagonalPrimeIsPrime(nums[i][j]))
                        {
                            flag = true;
                            hash.Add(nums[i][j]);
                            if (nums[i][j] > max)
                                max = nums[i][j];
                        }
                    }

                }
            }
            if (flag)
                return max;
            else
                return 0;
        }
        public bool DiagonalPrimeIsPrime(int num)
        {
            if (num == 1)
                return false;
            for (int i = 2; i * i <= num; ++i)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            int n = nums.Length;
            if (n < 3)
                return list;
            Array.Sort(nums);
            for (int i = 0; i < n - 3; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                int fir = nums[i];
                int tmptarget = target - fir;
                for (int j = i + 1; j < n - 2; ++j)
                {
                    if (nums[j] > tmptarget)
                        break;
                    if (j > 0 && nums[j] == nums[j - 1])
                        continue;
                    int l = j + 1;
                    int r = n - 1;
                    while (l < r)
                    {
                        int sum = nums[j] + nums[l] + nums[r];
                        if (sum == tmptarget)
                        {
                            IList<int> temp = new List<int>();
                            temp.Add(fir);
                            temp.Add(nums[j]);
                            temp.Add(l);
                            temp.Add(r);
                            list.Add(temp);
                        }
                        else if (sum < tmptarget) l++;
                        else if (sum > tmptarget) r--;
                    }
                }
            }
            return list;

        }
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            int length = strs[0].Length;
            int count = strs.Length;
            for (int i = 0; i < length; ++i)
            {
                char c = strs[0][i];
                for (int j = 1; j < count; ++j)
                {
                    if (i == strs[j].Length || strs[j][i] != c)
                        return strs[0].Substring(0, i + 1);
                }
            }
            return strs[0];
        }
        public int LengthOfLongestSubstring(string s)
        {
            HashSet<char> hash = new HashSet<char>();
            int right = -1, ans = 0;
            int n = s.Length;
            for (int i = 0; i < n; ++i)
            {
                if (i != 0)
                    hash.Remove(s[i - 1]);
                while (right + 1 < n && !hash.Contains(s[right + 1]))
                {
                    hash.Add(s[right + 1]);
                    right++;
                }
                ans = Math.Max(ans, right - i + 1);
            }
            return ans;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode tmp = head;
            int add = 0;
            while (l1 != null || l2 != null)
            {
                int fir = 0;
                int sec = 0;
                int sum;
                if (l1 != null)
                {
                    fir = l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sec = l2.val;
                    l2 = l2.next;
                }
                sum = fir + sec + add;
                if (sum >= 10)
                {
                    add = 1;
                    sum -= 10;
                }
                else
                    add = 0;
                tmp.val = sum;
                if (!(l1 == null && l2 == null))
                {
                    tmp.next = new ListNode();
                    tmp = tmp.next;
                }
            }
            if (add != 0)
                tmp.next = new ListNode(add);
            return head;
        }
        public int SuperPow(int a, int[] b)
        {
            int ans = 1;
            for (int i = b.Length - 1; i >= 0; --i)
            {
                ans = (int)((long)ans * SuperPowFastPower(a, b[i]) % 1337);
                a = SuperPowFastPower(a, 10);
            }
            return ans;
        }
        public int SuperPowFastPower(int x, int n)
        {
            int result = 1;
            while (n != 0)
            {
                if (n % 2 == 1)
                {
                    result = (int)((long)result * x % 1337);
                }
                n /= 2;
                x = (int)((long)x * x % 1337);
            }
            return result;
        }
        public int rob(TreeNode root)
        {
            int[] ans = postOrder(root);
            return ans.Max();
        }
        public int[] postOrder(TreeNode root)
        {
            if (root == null)
                return new int[] { 0, 0 };
            int[] left = postOrder(root.left);
            int[] right = postOrder(root.right);
            int v1 = left[0] + right[0]; //选子节点
            int v2 = left[1] + right[1] + root.val;
            v2 = Math.Max(v1, v2);
            return new int[] { v2, v1 };
        }
        public bool IsValidSerialization(string preorder)
        {
            Stack<string> stack = new Stack<string>();
            foreach (string node in preorder.Split(','))
            {
                stack.Push(node);
                while (stack.Count >= 3 && stack.Peek() == "#" && stack.ElementAt(1) == "#" && stack.ElementAt(2) != "#")
                {
                    stack.Pop();
                    stack.Pop();
                    stack.Pop();
                    stack.Push("#");
                }
            }
            return stack.Count == 1 && stack.Pop() == "#";
        }
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
                return head;
            ListNode headnext = head.next;
            ListNode fir = head;
            ListNode sec = head.next;

            while (sec.next != null && fir.next != null)
            {
                if (fir.next == sec)
                {
                    fir.next = sec.next;
                    fir = fir.next;
                }
                else if (sec.next == fir)
                {
                    sec.next = fir.next;
                    sec = sec.next;
                }
            }
            if (fir.next == null)
            {
                sec.next = null;
                fir.next = headnext;
            }
            else if (sec.next == null)
            {
                fir.next = headnext;
            }
            return head;

        }
        public int CoinChange(int[] coins, int amount)
        {
            int max = amount + 1;
            int[] dp = new int[amount + 1];
            for (int i = 0; i < amount + 1; ++i)
            {
                dp[i] = max;
            }
            dp[0] = 0;
            for (int i = 1; i <= amount; ++i)
            {
                for (int j = 0; j < coins.Length; ++j)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }
            return dp[amount] > amount ? -1 : dp[amount];

            //if (amount == 0)
            //    return 0;
            //int[] dp = new int[amount + 1];
            //int n = coins.Length;
            //dp[0] = 0;
            //for (int i = 1; i <= amount; ++i)
            //{
            //    int min = int.MaxValue;
            //    for (int j = 0; j < n; ++j)
            //    {
            //        if(i-coins[j]>=0)
            //        {
            //            if(i-coins[j]==0)
            //            {
            //                min = -1;
            //                break;
            //            }
            //            else
            //            {
            //                if(dp[i-coins[j]]!=0)
            //                {
            //                    min = Math.Min(min, dp[i - coins[j]]);
            //                }
            //            }
            //        }
            //    }
            //    if (min == -1)
            //    {
            //        dp[i] = 1;
            //    }
            //    else if (min == 0|| min == int.MaxValue)
            //    {
            //        dp[i]=0;
            //    }
            //    else
            //    {
            //        dp[i] = min + 1;
            //    }
            //}
            //return dp[amount]==0?-1:dp[amount];
        }
        public int NthSuperUglyNumber(int n, int[] primes)
        {
            int[] dp = new int[n + 1];
            int m = primes.Length;
            int[] pointers = new int[m];
            int[] nums = new int[m];
            for (int i = 0; i < m; ++i)
            {
                nums[i] = 1;
            }
            for (int i = 1; i <= n; ++i)
            {
                int minNum = nums.Min();
                dp[i] = minNum;
                for (int j = 0; j < m; ++j)
                {
                    if (nums[j] == minNum)
                    {
                        pointers[j]++;
                        nums[j] = dp[pointers[j]] * primes[j];
                    }
                }
            }
            return dp[n];
        }
        public bool IsPrime(int n)
        {
            if (n == 1)
                return false;
            for (int i = 2; i * i <= n; ++i)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        public bool CanWinNim(int n)
        {
            if (n == 1 || n == 2 || n == 3)
                return true;
            int fir = 1, sec = 1, third = 1;
            for (int i = 4; i <= n; ++i)
            {
                if (fir == 0 || sec == 0 || third == 0)
                {
                    fir = sec;
                    sec = third;
                    third = 1;
                }
                else
                {
                    fir = sec;
                    sec = third;
                    third = 0;
                }
            }
            return third == 1 ? true : false;

        }
        public void ShiftDown(int[] nums, int n, int cur)
        {
            int child = 2 * cur + 1;
            while (child < n)
            {
                if (child + 1 < n && nums[child + 1] < nums[child])
                    ++child;
                if (nums[child] < nums[cur])
                {
                    int temp = nums[child];
                    nums[child] = nums[cur];
                    nums[child] = temp;
                    cur = child;
                    child = 2 * cur + 1;
                }
                else
                    break;
            }
        }
        public void BinaryTreePathsDFS(TreeNode root, IList<string> list, IList<int> target)
        {
            target.Add(root.val);
            if (root.left == null && root.right == null)
            {
                string[] str = new string[target.Count];
                for (int i = 0; i < target.Count; ++i)
                    str[i] = target[i].ToString();
                list.Add(string.Join("->", str));
            }
            else
            {
                BinaryTreePathsDFS(root.left, list, target);
                target.RemoveAt(target.Count - 1);
                BinaryTreePathsDFS(root.right, list, target);
                target.RemoveAt(target.Count - 1);
            }
        }
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int x = 0, y = n - 1;
            while (x < m && y >= 0)
            {
                if (matrix[x][y] == target)
                    return true;
                if (matrix[x][y] > target)
                    --y;
                else
                    ++x;
            }
            return false;
        }
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] left = new int[n];
            int[] right = new int[n];
            int[] ans = new int[n];
            left[0] = 1;
            right[n - 1] = 1;
            for (int i = 1; i < n; ++i)
            {
                left[i] = left[i - 1] * nums[i - 1];
            }
            for (int i = n - 2; i >= 0; --i)
            {
                right[i] = right[i + 1] * nums[i + 1];
            }
            for (int i = 0; i < n; ++i)
                ans[i] = left[i] * right[i];
            return ans;

        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == p || root == q || root == null)
                return root;
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            if (left != null && right != null)
                return root;
            if (left == null)
                return right;
            return left;
        }
        //public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        //{
        //    TreeNode tmp = root;
        //    IList<TreeNode> list1 = SearchTree(tmp, p);
        //    tmp = root;
        //    IList<TreeNode> list2 = SearchTree(tmp, q);
        //    TreeNode target = new TreeNode();
        //    int min = Math.Min(list1.Count, list2.Count);
        //    for(int i=0;i<min;++i)
        //    {
        //        if (list1[i] == list2[i])
        //            target = list1[i];
        //    }
        //    return target;
        //}
        public IList<TreeNode> SearchTree(TreeNode root, TreeNode key)
        {
            IList<TreeNode> list = new List<TreeNode>();
            while (root != null)
            {
                list.Add(root);
                if (key.val == root.val)
                    return list;
                else if (key.val < root.val)
                    root = root.left;
                else if (key.val > root.val)
                    root = root.right;
            }
            return list;
        }
        public bool IsPowerOfFour(int n)
        {
            return n > 0 && (n & (n - 1)) == 0 && (n & 0xaaaaaaaa) == 0;
        }
        public long fastPower(long base1, long power)
        {
            long result = 1;
            while (power > 0)
            {
                //if(power%2==0)
                //{
                //    power /= 2;
                //    base1 = base1 * base1 % 1000;
                //}
                //else
                //{
                //    power = power - 1;
                //    result = result * base1 % 1000;
                //    power = power / 2;
                //    base1 = base1 * base1 % 1000;
                //}

                if (power % 2 == 1)
                {
                    result = result * base1 % 1000;
                }
                power /= 2;
                base1 = base1 * base1 % 1000;
            }
            return result;
        }
        public IList<string> SummaryRanges(int[] nums)
        {
            IList<string> list = new List<string>();
            if (nums.Length == 0)
                return list;
            int l = 0, r = 0;
            for (int i = 0; i < nums.Length; ++i)
            {
                l = nums[i];
                r = nums[i];
                int k = i + 1;
                while (k < nums.Length && nums[k] == nums[k - 1] + 1)
                {
                    r = nums[k];
                    k++;
                }
                if (l == r)
                {
                    list.Add($"{l}");
                }
                else
                {
                    list.Add($"{l}->{r}");
                    i = k - 1;
                }
            }
            return list;
        }
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            int area1 = (ax2 - ax1) * (ay2 - ay1), area2 = (bx2 - bx1) * (by2 - by1);
            int overlapWidth = Math.Min(ax2, bx2) - Math.Max(ax1, bx1), overlapHeight = Math.Min(ay2, by2) - Math.Max(ay1, by1);
            int overlapArea = Math.Max(overlapWidth, 0) * Math.Max(overlapHeight, 0);
            return area1 + area2 - overlapArea;
        }
        public int MaximalSquare(char[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[,] dp = new int[m, n];
            int max = 0;
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (matrix[i][j] == '1')
                    {
                        if (i == 0 || j == 0)
                            dp[i, j] = 1;
                        else
                        {
                            int tmpMin = Math.Min(dp[i - 1, j - 1], dp[i - 1, j]);
                            dp[i, j] = Math.Min(dp[i, j - 1], tmpMin) + 1;

                        }
                        if (max < dp[i, j])
                            max = dp[i, j];

                    }
                }
            }
            return max * max;
            //int MaxSquare = 0;
            //int m = matrix.Length;
            //int n = matrix[0].Length;
            //for (int i = 0; i < m; ++i)
            //{
            //    for (int j = 0; j < n; ++j)
            //    {
            //        if (matrix[i][j] == '1')
            //        {
            //            if (MaxSquare < 1)
            //                MaxSquare = 1;
            //            int count = 1;
            //            while (i + count < m && j + count < n)
            //            {

            //                if (IsSquare(matrix, i,j,count))
            //                {
            //                    if ((count + 1) * (count + 1) > MaxSquare)
            //                    {
            //                        MaxSquare = (count + 1) * (count + 1);
            //                    }
            //                    count++;
            //                }
            //                else
            //                    break;
            //            }
            //        }
            //    }
            //}
            //return MaxSquare;

        }
        public bool IsSquare(char[][] matrix, int x, int y, int count)
        {
            for (int i = y; i <= y + count; ++i)
            {
                if (matrix[x + count][i] != '1')
                    return false;
            }
            for (int i = x; i <= x + count; ++i)
            {
                if (matrix[i][y + count] != '1')
                    return false;
            }
            return true;
        }
        public int QuickSelect(int[] nums, int low, int high, int k)
        {
            if (low <= high)
                return -1;
            int i = low;
            int j = high + 1;
            int key = nums[low];
            while (true)
            {
                while (nums[++i] < key)
                {
                    if (i == high)
                        break;
                }
                while (nums[--j] > key)
                {
                    if (j == low)
                        break;
                }
                if (i >= j)
                    break;
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
            int temp1 = nums[low];
            nums[low] = nums[j];
            nums[j] = temp1;
            if (j > k)
                QuickSelect(nums, low, j - 1, k);
            if (j < k)
                QuickSelect(nums, j + 1, high, k);
            if (j == k)
                return nums[j];
            return 0;

        }
        /// <summary>
        /// 填坑法 快速排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public void QuickSort(int[] nums, int left, int right)
        {
            if (left >= right)
                return;
            int i = left, j = right;
            int key = nums[left];
            while (i < j)
            {
                while (i < j && nums[j] >= key)
                    j--;
                nums[i] = nums[j];
                while (i < j && nums[i] <= key)
                    i++;
                nums[j] = nums[i];
            }
            nums[i] = key;
            QuickSort(nums, left, i - 1);
            QuickSort(nums, i + 1, right);
        }
        public int MiceAndCheese(int[] reward1, int[] reward2, int k)
        {
            int n = reward1.Length;
            List<int> list = new List<int>();
            int max = 0;
            for (int i = 0; i < n; ++i)
            {
                max += reward2[i];
                list.Add(reward1[i] - reward2[i]);
            }
            list.Sort();
            for (int i = k - 1; i < list.Count; ++i)
            {
                max += list[i];
            }
            return max;
        }
        public void QuickSort(int[,] nums, int l, int r, int n)
        {
            if (l >= r)
                return;
            int i = l;
            int j = r;
            int num = nums[0, l];
            while (i < j)
            {
                while (i < j && nums[0, j] >= num)
                    j--;
                while (i < j && nums[0, i] <= num)
                    i++;
                if (i < j)
                {
                    Swap(nums, i, j);
                }
            }
            Swap(nums, l, i);
            QuickSort(nums, l, i - 1, n);
            QuickSort(nums, i + 1, r, n);

        }
        public void Swap(int[,] nums, int i, int j)
        {
            int temp = nums[0, i];
            nums[0, i] = nums[0, j];
            nums[0, j] = temp;
            temp = nums[1, i];
            nums[1, i] = nums[1, j];
            nums[1, j] = temp;
        }
        public IList<IList<int>> FindMatrix(int[] nums)
        {
            int[] numlen = new int[201];
            int max = 0;
            IList<IList<int>> list = new List<IList<int>>();
            HashSet<int> hash = new HashSet<int>();
            List<int> nu = new List<int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (hash.Add(nums[i]))
                {
                    nu.Add(nums[i]);
                }
                numlen[nums[i]] += 1;
                if (max < numlen[nums[i]])
                    max = numlen[nums[i]];
            }
            for (int j = 0; j < max; ++j)
            {
                IList<int> temp = new List<int>();
                for (int i = 0; i < nu.Count; ++i)
                {
                    if (numlen[nu[i]]-- > 0)
                    {
                        temp.Add(nu[i]);
                    }

                }
                list.Add(temp);
            }
            return list;
        }
        public int FindTheLongestBalancedSubstring(string s)
        {
            int n = s.Length;
            if (n == 0)
                return 0;
            int max = 0;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; ++i)
            {
                if (s[i] == '0')
                {
                    stack.Push(s[i]);
                }
                else if (s[i] == '1')
                {
                    int count = stack.Count;
                    int k = i;
                    while (stack.Count != 0 && k < n)
                    {
                        if (s[k] == '1')
                        {
                            stack.Pop();
                            k++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (max < 2 * (count - stack.Count))
                        max = 2 * (count - stack.Count);
                    stack.Clear();
                    i = k - 1;
                }
            }
            return max;

        }
        public int MinSubArrayLen(int target, int[] nums)
        {
            int start = 0, end = 0;
            int sum = 0;
            int min = int.MaxValue;
            while (end < nums.Length)
            {
                sum += nums[end];
                while (sum >= target)
                {
                    int n = end - start + 1;
                    if (n < min)
                        min = n;
                    sum -= nums[start];
                    start++;
                }
                end++;
            }
            if (min == int.MinValue)
                return 0;
            else
                return min;
        }
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            IList<IList<int>> list = new List<IList<int>>();
            IList<int> tp = new List<int>();
            int[] din = new int[numCourses];
            for (int i = 0; i < numCourses; ++i)
            {
                IList<int> temp = new List<int>();
                list.Add(temp);
            }
            for (int i = 0; i < prerequisites.Length; ++i)
            {
                int a = prerequisites[i][1];
                int b = prerequisites[i][0];
                list[a].Add(b);
                din[b]++;
            }
            return CanFinishTopSort(list, tp, din);
        }
        /// <summary>
        /// 拓扑排序
        /// </summary>
        /// <param name="list"></param>
        /// <param name="tp"></param>
        /// <param name="din"></param>
        /// <returns></returns>
        public bool CanFinishTopSort(IList<IList<int>> list, IList<int> tp, int[] din)
        {
            Queue<int> que = new Queue<int>();
            for (int i = 0; i < list.Count; ++i)
            {
                if (din[i] == 0)
                    que.Enqueue(i);
            }
            int v = 0;

            while (que.Count != 0)
            {
                v++;
                int x = que.Dequeue();
                tp.Add(x);
                for (int i = 0; i < list[x].Count; ++i)
                    if ((--din[list[x][i]]) == 0)
                        que.Enqueue(list[x][i]);
            }
            return v == list.Count;
        }
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            Dictionary<char, char> dics = new Dictionary<char, char>();
            Dictionary<char, char> dict = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; ++i)
            {
                char x = s[i], y = t[i];
                if (((dics.ContainsKey(x)) && dics[x] != y) || (dict.ContainsKey(y) && dict[y] != x))
                    return false;
                dics.Add(x, y);
                dict.Add(y, x);
            }
            return true;
        }
        public int CountPrimes(int n)
        {
            int[] isPrime = new int[n];
            int ans = 0;
            for (int i = 2; i < n; ++i)
            {
                if (isPrime[i] == 0)
                {
                    ans += 1;
                    if ((long)i * i < n)
                    {
                        for (int j = i * i; j < n; j += i)
                        {
                            isPrime[j] = 1;
                        }
                    }
                }
            }
            return ans;

            //int count = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    if (IsPirmeNum(i))
            //        count++;
            //}
            //return count;
        }
        public bool IsPirmeNum(int num)
        {
            if (num == 0)
                return false;
            if (num == 1)
                return false;
            if (num == 2)
                return true;
            for (int i = 2; i * i <= num; ++i)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
        public int RangeBitwiseAnd(int left, int right)
        {
            if (left == int.MaxValue && left == right)
                return left;
            int result = left;
            for (int i = left + 1; i <= right; ++i)
            {
                if (result == 0)
                    break;
                result = i & result;
                if (i == int.MaxValue)
                    break;
            }
            return result;
        }
        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            bool[,] gri = new bool[m, n];
            int count = 0;
            int[][] direction = new int[4][] { new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 } };
            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (grid[i][j] == '1' && !gri[i, j])
                    {
                        NumIslandsDFS(grid, gri, direction, i, j);
                        count++;
                    }
                }
            }
            return count;
        }
        public void NumIslandsDFS(char[][] grid, bool[,] gri, int[][] direction, int x, int y)
        {
            if (grid[x][y] == '0' || gri[x, y])
                return;
            gri[x, y] = true;
            for (int i = 0; i < direction.Length; ++i)
            {
                int x1 = x + direction[i][0];
                int y1 = y + direction[i][1];
                if (x1 >= 0 && x1 < grid.Length && y1 >= 0 && y1 < grid[0].Length)
                {
                    NumIslandsDFS(grid, gri, direction, x1, y1);
                }
            }
        }
        public int Rob(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            else if (n == 2)
            {
                if (nums[0] > nums[1])
                    return nums[0];
                else
                    return nums[1];
            }
            int prepre = nums[0];
            int pre = nums[1] > prepre ? nums[1] : prepre;
            int curr = 0;
            for (int i = 2; i < n; ++i)
            {
                curr = Math.Max(prepre + nums[i], pre);
                prepre = pre;
                pre = curr;
            }
            return curr;
            //int[] dp = new int[n];
            //dp[0] = nums[0];
            //dp[1]=nums[1]>dp[0]?nums[1]:dp[0];
            //for (int i = 2; i < n; ++i)
            //{
            //    dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            //}
            //return dp[n - 1];
        }

        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null)
                return list;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            while (que.Count != 0)
            {
                int count = 0;
                int size = que.Count;
                while (count < size)
                {
                    TreeNode node = que.Dequeue();
                    count++;
                    if (node.left != null)
                        que.Enqueue(node.left);
                    if (node.right != null)
                        que.Enqueue(node.right);
                    if (count == size)
                        list.Add(node.val);
                }
            }
            return list;
        }
        public uint reverseBits(uint n)
        {
            uint temp = 0;
            uint a = 0;
            for (int i = 0; i < 32; i++)
            {
                uint flag = n & 1;
                temp += flag ^ a;
                if (i == 3)
                {
                    break;
                }
                temp = temp << 1;
                n = n >> 1;
            }
            return temp;
        }
        public void Rotate(int[] nums, int k)
        {
            int n = nums.Length;
            k = k % n;
            int count = gcd(k, n);
            for (int start = 0; start < count; ++start)
            {
                int current = start;
                int prev = nums[start];
                do
                {
                    int next = (current + k) % n;
                    int temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                }
                while (start != current);
            }

        }
        public int gcd(int x, int y)
        {
            return y > 0 ? gcd(y, x % y) : x;
        }
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            IList<string> list = new List<string>();
            if (s.Length < 10)
                return list;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i + 9 < s.Length; i++)
            {
                if (!dic.ContainsKey(s.Substring(i, 10)))
                {
                    dic.Add(s.Substring(i, 10), 1);
                }
                else
                {
                    dic[s.Substring(i, 10)] += 1;
                }
            }
            foreach (KeyValuePair<string, int> temp in dic)
            {
                if (temp.Value > 1)
                    list.Add(temp.Key);
            }
            return list;
        }
        public string LargestNumber(int[] nums)
        {
            string[] str = new string[nums.Length];
            for (int i = 0; i < nums.Length; ++i)
            {
                str[i] = nums[i].ToString();
            }
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                for (int j = 0; j < nums.Length - 1 - i; ++j)
                {
                    if (str[j][0] < str[j + 1][0])
                    {
                        string temp = str[j];
                        str[j] = str[j + 1];
                        str[j + 1] = temp;
                    }
                    else if (str[j][0] == str[j + 1][0])
                    {
                        string s1 = str[j] + str[j + 1];
                        string s2 = str[j + 1] + str[j];
                        for (int m = 0; m < s1.Length; ++m)
                        {
                            char c1 = s1[m];
                            char c2 = s2[m];
                            s1.Substring(0, 10);
                            if (s1[m] > s2[m])
                                break;
                            if (s1[m] < s2[m])
                            {
                                string temp = str[j];
                                str[j] = str[j + 1];
                                str[j + 1] = temp;
                                break;
                            }
                        }
                    }
                }
            }
            StringBuilder str1 = new StringBuilder();
            foreach (string s in str)
            {
                str1.Append(s);
            }
            return str1.ToString();
        }
        public int TrailingZeroes(int n)
        {

            int ans = 0;
            while (n != 0)
            {
                n /= 5;
                ans += n;
            }
            return ans;

        }
        public int TitleToNumber(string columnTitle)
        {
            int number = 0;
            int multiple = 1;
            for (int i = columnTitle.Length - 1; i >= 0; ++i)
            {
                int k = columnTitle[i] - 'A' + 1;
                number += k * multiple;
                multiple *= 26;
            }
            return number;

        }

        public string FractionToDecimal(int numerator, int denominator)
        {

            int f = 1;

            if (numerator < 0 && denominator > 0)
            {
                numerator *= -1;
                f = -1;
            }
            else if (numerator > 0 && denominator < 0)
            {
                denominator *= -1;
                f = -1;
            }
            int interger = numerator / denominator;
            int remainer = numerator % denominator;
            if (remainer == 0)
            {
                if (f == -1)
                    return $"-{interger}";
                else
                    return $"{interger}";
            }
            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> list = new List<int>();
            bool flag = false;
            int index1 = 0, index2 = 0;
            int index = 0;
            StringBuilder str = new StringBuilder();
            while (remainer != 0)
            {
                int re1 = remainer / denominator;
                int re2 = remainer % denominator;
                list.Add(re1);
                if (!dic.ContainsKey(re2))
                {
                    dic.Add(re2, index);
                    remainer = re2 * 10;
                }
                else
                {
                    flag = true;
                    index1 = dic[re2] + 1;
                    index2 = index;
                    break;
                }
                index++;
            }
            if (f == -1)
                str.Append($"-{interger}.");
            else
                str.Append($"{interger}.");

            if (flag)
            {
                for (int i = 1; i < index1; i++)
                {
                    str.Append($"{list[i]}");
                }
                str.Append("(");
                for (int i = index1; i <= index2; i++)
                {
                    str.Append($"{list[i]}");
                }
                str.Append(")");
            }
            else
            {
                for (int i = 1; i < list.Count; ++i)
                {
                    str.Append($"{list[i]}");
                }
            }
            return str.ToString();

        }
        public int CompareVersion(string version1, string version2)
        {
            HashSet<int> v = new HashSet<int>();
            int n = version1.Length;
            int m = version2.Length;
            int i = 0, j = 0;
            while (i < n || j < m)
            {
                int x = 0;
                for (; i < n && version1[i] != '.'; ++i)
                {
                    x = x * 10 + version1[i] - '0';
                }
                ++i;
                int y = 0;
                for (; j < m && version2[j] != '.'; ++j)
                {
                    y = y * 10 + version2[j] - '0';
                }
                ++j;
                if (x != y)
                    return x > y ? 1 : -1;
            }
            return 0;


            #region 官方解
            //string[] v1 = version1.Split('.');
            //string[] v2 = version2.Split('.');
            //for(int i=0;i<v1.Length||i<v2.Length;++i)
            //{
            //    int x = 0, y = 0;
            //    if (i < v1.Length)
            //        x = int.Parse(v1[i]);
            //    if (i < v2.Length)
            //        y = int.Parse(v2[i]);
            //    if (x > y)
            //        return 1;
            //    if (x < y)
            //        return -1;
            //}
            //return 0;
            #endregion

            #region 太长
            //string[] ver1 = version1.Split('.');
            //string[] ver2 = version2.Split('.');
            //int result = 0;
            //if(ver1.Length<ver2.Length)
            //{
            //    for(int i=0;i<ver1.Length;++i)
            //    {
            //        int a = Convert.ToInt32(ver1[i]);
            //        int b = Convert.ToInt32(ver2[i]);
            //        if(a>b)
            //        {
            //            result = 1;
            //            break;
            //        }
            //        else if(a<b)
            //        {
            //            result = -1;
            //            break;
            //        }
            //    }
            //    if(result==0)
            //    {
            //        for(int i=ver1.Length; i<ver2.Length; ++i)
            //        {
            //            int ver2value = Convert.ToInt32(ver2[i]);
            //            if (ver2value > 0)
            //            {
            //                result = -1;
            //                break;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < ver2.Length; ++i)
            //    {
            //        int a = Convert.ToInt32(ver2[i]);
            //        int b = Convert.ToInt32(ver1[i]);
            //        if (a > b)
            //        {
            //            result = -1;
            //            break;
            //        }
            //        else if (a < b)
            //        {
            //            result = 1;
            //            break;
            //        }
            //    }
            //    if (result == 0)
            //    {
            //        for (int i = ver2.Length; i < ver1.Length; ++i)
            //        {
            //            int ver1value = Convert.ToInt32(ver1[i]);
            //            if (ver1value > 0)
            //            {
            //                result = 1;
            //                break;
            //            }
            //        }
            //    }
            //}
            //return result;
            #endregion
        }
        public int FindMin(int[] nums)
        {
            int n = nums.Length;
            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] < nums[right])
                    right = mid;
                else
                    left = mid + 1;
            }
            return nums[right];
        }
        public int MaxSubArray(int[] nums)
        {
            int n = nums.Length;
            int[] dp = new int[n];
            dp[0] = nums[0];
            int max = -10001;
            for (int i = 1; i < nums.Length; ++i)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 1] + nums[i]);
            }
            foreach (var item in dp)
            {
                if (max < item)
                    max = item;
            }
            return max;
        }

        public int MaxProduct(int[] nums)
        {
            int n = nums.Length;
            int[] dpMax = new int[n];
            int[] dpMin = new int[n];
            dpMax[0] = nums[0];
            dpMin[0] = nums[0];
            for (int i = 1; i < n; ++i)
            {
                dpMax[i] = Math.Max(dpMin[i - 1] * nums[i], dpMax[i - 1] * nums[i]);
                dpMax[i] = Math.Max(dpMax[i], nums[i]);
                dpMin[i] = Math.Min(dpMin[i - 1] * nums[i], dpMin[i - 1] * nums[i]);
                dpMin[i] = Math.Min(dpMin[i], nums[i]);
            }
            int max = -11;
            foreach (var item in dpMin)
            {
                if (max < item)
                    max = item;
            }
            return max;
        }
        public int EvalRPN(string[] tokens)
        {
            if (tokens.Length == 1)
                return Convert.ToInt32(tokens[0]);
            int result = 0;
            Stack<string> stack = new Stack<string>();
            //stack.Push(tokens[0]);
            for (int i = 0; i < tokens.Length; ++i)
            {
                if (tokens[i] == "+" || tokens[i] == "-" || tokens[i] == "*" || tokens[i] == "/")
                {
                    int b = Convert.ToInt32(stack.Pop());
                    int a = Convert.ToInt32(stack.Pop());
                    int temp = EvalRPNCalc(a, tokens[i], b);
                    stack.Push(temp.ToString());
                }
                else
                {
                    stack.Push(tokens[i]);
                }
            }
            return Convert.ToInt32(stack.Pop());
        }
        public int EvalRPNCalc(int a, string b, int c)
        {
            int d = 0;
            switch (b)
            {
                case "+":
                    d = a + c;
                    break;
                case "-":
                    d = a - c;
                    break;
                case "*":
                    d = a * c;
                    break;
                case "/":
                    d = a / c;
                    break;
            }
            return d;
        }
        public ListNode InsertionSortList1(ListNode head)
        {
            if (head == null)
                return head;
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode lastSorted = head;
            ListNode curr = head.next;
            while (curr != null)
            {
                if (lastSorted.val <= curr.val)
                    lastSorted = lastSorted.next;
                else
                {
                    ListNode prev = dummyHead;
                    while (prev.next.val <= curr.val)
                        prev = prev.next;
                    lastSorted.next = curr.next;
                    curr.next = prev.next;
                    prev.next = curr;
                }
                curr = lastSorted.next;
            }
            return dummyHead.next;
        }


        public ListNode InsertionSortList(ListNode head)
        {
            if (head.next == null)
                return head;
            ListNode temphead = head;
            while (temphead != null)
            {
                ListNode newhead = new ListNode(-5001);
                ListNode thead = head;
                newhead.next = thead;

                Stack<ListNode> que = new Stack<ListNode>();
                while (newhead != temphead)
                {
                    que.Push(newhead);
                    newhead = newhead.next;
                }
                ListNode target = new ListNode(temphead.val);
                ListNode pre = que.Peek();
                while (que.Count > 0)
                {
                    pre = que.Pop();
                    if (pre.val > target.val)
                    {
                        int temp = pre.val;
                        pre.next.val = pre.val;
                    }
                    else
                    {
                        break;
                    }
                }
                pre.next.val = target.val;
                temphead = temphead.next;
            }
            return head;
        }
        public void Qucik_Sort(List<int> nums, int begin, int end)
        {
            if (begin > end)
                return;
            int tmp = nums[begin];
            int i = begin;
            int j = end;
            while (i != j)
            {
                while (nums[j] >= tmp && j > i)
                    j--;
                while (nums[i] <= tmp && j > i)
                    i++;
                if (j > i)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }
            nums[begin] = nums[i];
            nums[i] = tmp;
            Qucik_Sort(nums, begin, i - 1);
            Qucik_Sort(nums, i + 1, end);
        }
        public int[] InsertionSorting(int[] nums)
        {
            for (int i = 1; i < nums.Length; ++i)
            {
                int index = nums[i];
                int j = i;
                while (j >= 1 && index < nums[j - 1])
                {
                    nums[j] = nums[j - 1];
                    j--;
                    Program.Show(nums);
                }
                nums[j] = index;
                Console.WriteLine();
            }
            return nums;



            //for (int i = 1; i < nums.Length; ++i)
            //{
            //    int target = nums[i];
            //    int j = i;
            //    while (j >= 1 && target < nums[j - 1])
            //    {
            //        nums[j] = nums[j - 1];
            //        j--;
            //    }
            //    nums[j] = target;
            //}
            //return nums;
        }

        public void ReorderList(ListNode head)
        {
            if (head.next == null)
                return;
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode newhead = head;
            while (newhead != null)
            {
                stack.Push(newhead);
                newhead = newhead.next;
            }
            newhead = head;
            ListNode last = stack.Pop();
            while (newhead.next != null && newhead.next != last)
            {
                ListNode lastbefore = stack.Pop();
                last.next = newhead.next;
                lastbefore.next = null;
                newhead.next = last;
                newhead = newhead.next.next;
                last = lastbefore;
            }




            //if (head.next == null)
            //    return;
            //tempHead = head;
            //ListNode last = head;
            //ReorderListDFS(last);
        }
        public ListNode ReorderListDFS(ListNode last)
        {
            if (last.next == null)
                return last;
            ListNode lastnode = ReorderListDFS(last.next);
            if (lastnode == null)
                return null;
            if (last == tempHead || tempHead.next == null)
                return null;
            else
            {
                lastnode.next = tempHead.next;
                last.next = null;
                tempHead.next = lastnode;
                tempHead = tempHead.next.next;
                return last;
            }
        }
        public bool WordBreak(string s, IList<string> wordDict)
        {

            //var wordDictSet = new HashSet<string>(wordDict);

            //var dp = new bool[s.Length + 1];
            //dp[0] = true;
            //for (int i = 1; i <= s.Length; ++i)
            //{
            //    for (int j = 0; j < i; ++j)
            //    {
            //        if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j)))
            //        {
            //            dp[i] = true;
            //            break;
            //        }
            //    }
            //}

            //return dp[s.Length];

            HashSet<string> wordDictSet = new HashSet<string>(wordDict);
            bool[] dp = new bool[s.Length + 1];
            dp[0] = true;
            for (int i = 1; i <= s.Length; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j)))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }
            return dp[s.Length];
        }



        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            Dictionary<char, int> dics = new Dictionary<char, int>();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; ++i)
            {
                if (!dics.ContainsKey(s[i]))
                    dics.Add(s[i], 1);
                else
                    dics[s[i]] += 1;
                if (!dict.ContainsKey(t[i]))
                    dict.Add(t[i], 1);
                else
                    dict[t[i]] += 1;
            }
            bool res = true;
            foreach (var item in dics)
            {
                if (!dict.ContainsKey(item.Key))
                {
                    res = false;
                    break;
                }
                if (item.Value != dict[item.Key])
                {
                    res = false;
                    break;
                }
            }
            return res;
        }
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int n = gas.Length;
            int curSum = 0;
            int totalSum = 0;
            int start = 0;
            for (int i = 0; i < n; ++i)
            {
                curSum += gas[i] - cost[i];
                totalSum += gas[i] - cost[i];
                if (curSum < 0)
                {
                    start = i + 1;
                    curSum = 0;
                }
            }
            if (totalSum < 0)
                return -1;
            return start;
        }
        public int SumNumbers(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            IList<int> target = new List<int>();
            SumNumbersDFS(root, target, list);
            int sum = 0;
            foreach (var item in list)
            {
                int n = item.Count;
                for (int i = 0; i < item.Count; i++)
                {
                    sum += item[i] * (int)Math.Pow(10, --n);
                }
            }
            return sum;
        }
        public void SumNumbersDFS(TreeNode root, IList<int> target, IList<IList<int>> list)
        {
            target.Add(root.val);
            if (root.left == null && root.right == null)
            {
                IList<int> temp = new List<int>(target);
                list.Add(temp);
            }
            else
            {
                if (root.left != null)
                {
                    SumNumbersDFS(root.left, target, list);
                    target.RemoveAt(target.Count - 1);
                }
                if (root.right != null)
                {
                    SumNumbersDFS(root.right, target, list);
                    target.RemoveAt(target.Count - 1);
                }

            }
        }
        public int MaxProfit(int[] prices)
        {
            int len = prices.Length;
            int[] dp = new int[len];
            int min = prices[0];
            dp[0] = 0;
            for (int i = 1; i < len; ++i)
            {
                if ((prices[i] - min) > dp[i - 1])
                {
                    dp[i] = prices[i] - min;
                    min = Math.Min(prices[i], min);
                }
                else
                {
                    dp[i] = dp[i - 1];
                }
            }
            return dp[len - 1];
        }
        public int MaxProfit2(int[] prices)
        {
            int n = prices.Length;
            int profit = 0;
            for (int i = 1; i < n; ++i)
            {
                if (prices[i] > prices[i - 1])
                    profit += prices[i] - prices[i - 1];
            }
            return profit;
        }
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            #region 动态规划
            //int n = triangle.Count;

            //int[,] dp = new int[n, n];
            //for(int i=0;i<n;++i)
            //{
            //    for(int j=0;j<=i;++j)
            //    {
            //        if (i == 0 && j == 0)
            //            dp[i, j] = triangle[i][j];
            //        else if(j==0)
            //        {
            //            dp[i, j] = dp[i - 1, j] + triangle[i][ j];
            //        }
            //        else if(i==j)
            //        {
            //            dp[i, j] = dp[i - 1, j - 1] + triangle[i][j];
            //        }
            //        else
            //        {
            //            dp[i, j] = Math.Min(dp[i - 1, j], dp[i - 1, j - 1]) + triangle[i][j];
            //        }
            //    }
            //}
            //int min = int.MaxValue;
            //for(int i=0;i<n;++i)
            //{
            //    if (dp[n - 1,i] < min)
            //        min = dp[n - 1,i];
            //}
            //return min;
            #endregion

            #region 动态规划 + 空间优化
            //int n = triangle.Count;
            //int[,] dp = new int[2, n];
            //dp[0, 0] = triangle[0][0];
            //for(int i=1;i<n;++i)
            //{
            //    int curr = i % 2;
            //    int prev = 1 - curr;
            //    dp[curr, 0] = dp[prev,0] + triangle[i][0];
            //    for(int j=1;j<i;++j)
            //    {
            //        dp[curr, j] = Math.Min(dp[prev, j - 1], dp[prev, j]) + triangle[i][j];
            //    }
            //    dp[curr,i] = dp[prev, i - 1] + triangle[i][i];
            //}
            //int min = dp[(n - 1) % 2, 0];
            //for(int i=1;i<n;++i)
            //{
            //    min = Math.Min(min,dp[(n-1)%2,i]);
            //}
            //return min;
            #endregion

            #region 动态规划，在原三角形上进行状态转移
            int m = triangle.Count;
            for (int i = m - 2; i >= 0; i--)
            {
                IList<int> thisList = triangle[i];
                IList<int> nextList = triangle[i + 1];
                for (int j = 0; j < thisList.Count; j++)
                {
                    thisList[j] = thisList[j] + Math.Min(nextList[j], nextList[j + 1]);
                }
            }
            return triangle[0][0];

            #endregion
        }
        public Node1 Connect(Node1 root)
        {
            if (root == null)
                return root;
            Queue<Node1> que = new Queue<Node1>();
            que.Enqueue(root);
            while (que.Count != 0)
            {
                int len = que.Count;
                while (len-- > 0)
                {
                    Node1 node = que.Dequeue();
                    if (len == 0)
                    {
                        node.next = null;
                    }
                    else
                    {
                        node.next = que.Peek();
                    }
                    if (node.left != null)
                        que.Enqueue(node.left);
                    if (node.right != null)
                    {
                        que.Enqueue(node.right);
                    }
                }
            }
            return root;

        }
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
            IList<TreeNode> list = new List<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                list.Add(node);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }
            root.left = null;
            root.right = null;
            TreeNode tempNode = root;
            for (int i = 1; i < list.Count; ++i)
            {
                tempNode.right = list[i];

                tempNode = tempNode.right;
                tempNode.left = null;
            }
        }
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {

            IList<IList<int>> list = new List<IList<int>>();
            if (root == null)
                return list;
            IList<int> target = new List<int>();
            target.Add(root.val);
            PathSumDFS(root, targetSum, 0, target, list);
            return list;
        }
        public void PathSumDFS(TreeNode root, int targetSum, int sum, IList<int> target, IList<IList<int>> list)
        {
            sum += root.val;
            if (root.left == null && root.right == null)
            {
                if (sum == targetSum)
                {
                    IList<int> temp = new List<int>(target);
                    list.Add(temp);
                }
            }
            else
            {
                if (root.left != null)
                {
                    target.Add(root.left.val);
                    PathSumDFS(root.left, targetSum, sum, target, list);
                    target.RemoveAt(target.Count - 1);
                }
                if (root.right != null)
                {
                    target.Add(root.right.val);
                    PathSumDFS(root.right, targetSum, sum, target, list);
                    target.RemoveAt(target.Count - 1);
                }
            }

        }
        public bool HasPathSum1(TreeNode root, int sum)
        {
            if (root == null)
                return false;
            Queue<TreeNode> queNode = new Queue<TreeNode>();
            Queue<int> queVal = new Queue<int>();
            queNode.Enqueue(root);
            queVal.Enqueue(root.val);
            while (queNode.Count != 0)
            {
                TreeNode now = queNode.Dequeue();
                int temp = queVal.Dequeue();
                if (now.left == null && now.right == null)
                {
                    if (temp == sum)
                        return true;
                    continue;
                }
                if (now.left != null)
                {
                    queNode.Enqueue(now.left);
                    queVal.Enqueue(now.left.val + temp);
                }
                if (now.right != null)
                {
                    queNode.Enqueue(now.right);
                    queVal.Enqueue(now.right.val + temp);
                }
            }
            return false;
        }
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;
            return HasPathSumDFS(root, targetSum, 0);
        }
        public bool HasPathSumDFS(TreeNode root, int targetSum, int sum)
        {
            sum += root.val;
            if (root.left == null && root.right == null)
            {
                if (sum == targetSum)
                    return true;
                else
                    return false;
            }
            else
            {
                bool IsTarget = false;
                if (root.left != null)
                {
                    IsTarget = HasPathSumDFS(root.left, targetSum, sum) || IsTarget;
                }
                if (IsTarget)
                    return IsTarget;
                if (root.right != null)
                {
                    IsTarget = HasPathSumDFS(root.right, targetSum, sum) || IsTarget;
                }
                return IsTarget;
            }

        }

        public int MinDepth(TreeNode root)
        {

            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;
            int min = int.MaxValue;
            if (root.left != null)
                min = Math.Min(MinDepth(root.left), min);
            if (root.right != null)
                min = Math.Min(MinDepth(root.right), min);
            return min + 1;
        }

        public bool IsBalanced(TreeNode root)
        {
            return IsBalancedheight(root) >= 0;
        }
        public int IsBalancedheight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = IsBalancedheight(root.left);
            int right = IsBalancedheight(root.right);
            if (left == -1 || right == -1 || Math.Abs(left - right) > 1)
                return -1;
            else
                return Math.Max(left, right) + 1;
        }
        public TreeNode SortedListToBST(ListNode head)
        {
            IList<int> nums = new List<int>();
            int count = 0;
            while (head != null)
            {
                count++;
                nums.Add(head.val);
                head = head.next;
            }
            return SortedListToBSTDFS(nums, 0, count - 1);
        }
        public TreeNode SortedListToBSTDFS(IList<int> nums, int left, int right)
        {
            if (left > right)
                return null;
            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = SortedListToBSTDFS(nums, left, mid - 1);
            root.right = SortedListToBSTDFS(nums, mid + 1, right);
            return root;
        }
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTDFS(nums, 0, nums.Length - 1);
        }
        public TreeNode SortedArrayToBSTDFS(int[] nums, int left, int right)
        {
            if (left > right)
                return null;
            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = SortedArrayToBSTDFS(nums, left, mid - 1);
            root.right = SortedArrayToBSTDFS(nums, mid + 1, right);
            return root;
        }

        public TreeNode BuildTree1(int[] inorder, int[] postorder)
        {
            if (inorder.Length != postorder.Length)
                return null;
            int len = inorder.Length;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < len; ++i)
            {
                dic.Add(inorder[i], i);
            }
            return myBuildTree1(inorder, postorder, 0, len - 1, 0, len - 1, dic);
        }
        public TreeNode myBuildTree1(int[] inorder, int[] postorder, int inLeft, int inRight, int postLeft, int postRight, Dictionary<int, int> dic)
        {
            if (postLeft > postRight)
                return null;
            int postroot = postRight;
            int inroot = dic[postorder[postroot]];
            TreeNode root = new TreeNode(postorder[postroot]);
            int size_left_subtree = inroot - inLeft;
            root.left = myBuildTree1(inorder, postorder, inLeft, inroot - 1, postLeft, postLeft + size_left_subtree - 1, dic);
            root.right = myBuildTree1(inorder, postorder, inroot + 1, inRight, postLeft + size_left_subtree, postRight - 1, dic);
            return root;
        }


        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length != inorder.Length)
                return null;
            int n = preorder.Length;
            Dictionary<int, int> indexMap = new Dictionary<int, int>();
            for (int i = 0; i < n; ++i)
            {
                indexMap.Add(inorder[i], i);
            }
            return myBuildTree(preorder, inorder, 0, n - 1, 0, n - 1, indexMap);

        }
        public TreeNode myBuildTree(int[] preorder, int[] inorder, int preLeft, int preRight, int inLeft, int inRight, Dictionary<int, int> indexMap)
        {
            if (preLeft > preRight)
                return null;
            int preroot = preLeft;
            int inroot = indexMap[preorder[preroot]];

            TreeNode root = new TreeNode(preorder[preroot]);

            int size_left_subtree = inroot - inLeft;

            root.left = myBuildTree(preorder, inorder, preLeft + 1, preLeft + size_left_subtree, inLeft, inroot - 1, indexMap);

            root.right = myBuildTree(preorder, inorder, preLeft + size_left_subtree + 1, preRight, inroot + 1, inRight, indexMap);
            return root;

        }
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null)
                return list;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            bool IsRight = true;
            while (que.Count != 0)
            {
                int count = que.Count;
                int[] level = new int[count];
                while (count > 0)
                {
                    TreeNode node = que.Dequeue();
                    level[IsRight ? (level.Length - count) : (count - 1)] = node.val;
                    count--;
                    if (node.left != null)
                        que.Enqueue(node.left);
                    if (node.right != null)
                        que.Enqueue(node.right);
                }
                list.Add(level.ToList());
                IsRight = !IsRight;
            }
            return list;
        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            else if ((p == null && q != null) || (p != null && q == null))
                return false;
            if (p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
            else
                return false;
        }

        public bool IsValidBST(TreeNode root)
        {
            IList<int> list = new List<int>();
            IsValidBSTDigui(root, list);
            for (int i = 0; i < list.Count - 1; ++i)
            {
                if (list[i + 1] <= list[i])
                    return false;
            }
            return true;
        }
        public void IsValidBSTDigui(TreeNode root, IList<int> list)
        {
            if (root == null)
                return;
            IsValidBSTDigui(root.left, list);
            list.Add(root.val);
            IsValidBSTDigui(root.right, list);
        }
        public bool IsValidBSTmid(TreeNode root, int lower, int upper)
        {
            if (root == null)
                return true;
            if (root.val <= lower || root.val >= upper)
                return false;

            return IsValidBSTmid(root.left, lower, root.val) && IsValidBSTmid(root.right, root.val, upper);
        }

        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if (left == right)
                return head;
            ListNode Head1 = new ListNode(501);
            ListNode newHead = Head1;
            newHead.next = head;
            ListNode fir = new ListNode();
            ListNode sec = new ListNode();
            int count = 0;
            while (newHead.next != null)
            {
                ListNode leftNode = newHead.next;
                count++;
                if (count == left)
                {
                    fir = newHead;
                    ListNode rightNode = leftNode;
                    while (rightNode.next != null)
                    {
                        count++;
                        if (count == right)
                        {
                            rightNode = rightNode.next;
                            sec = rightNode.next;
                            rightNode.next = null;
                            ReverseBetweenReverse(leftNode, rightNode, fir, sec);
                            fir.next = rightNode;
                            leftNode.next = sec;
                            break;
                        }
                        else
                            rightNode = rightNode.next;
                    }
                    break;

                }
                else
                {
                    newHead = newHead.next;
                }
            }
            return Head1.next;
        }
        public ListNode ReverseBetweenReverse(ListNode head, ListNode tail, ListNode fir, ListNode sec)
        {
            if (head == null || head.next == null)
                return null;
            ListNode temp = ReverseBetweenReverse(head.next, tail, fir, sec);
            ListNode newHead = head.next;
            newHead.next = head;
            head.next = temp;
            return newHead;
        }

        public ListNode Partition(ListNode head, int x)
        {
            if (head == null || head.next == null)
                return head;
            ListNode small = new ListNode(-101);
            ListNode smallTemp = small;
            ListNode large = new ListNode();
            ListNode largeTemp = large;
            while (head != null)
            {
                ListNode temp = new ListNode(head.val);
                if (head.val < x)
                {
                    smallTemp.next = temp;
                    smallTemp = smallTemp.next;
                }
                else
                {
                    largeTemp.next = temp;
                    largeTemp = largeTemp.next;
                }
                head = head.next;
            }
            smallTemp.next = large.next;
            return small.next;
        }


        public bool isSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            return compare(root.left, root.right);
        }

        public bool compare(TreeNode left, TreeNode right)
        {
            if (left == null && right != null)
                return false;
            if (left != null && right == null)
                return false;
            if (left == null && right == null)
                return true;
            if (left.val != right.val) return false;
            bool outside = compare(left.left, right.right);
            bool inside = compare(left.right, right.left);
            return outside && inside;
        }


        public IList<int> Preorder(Node root)
        {
            IList<int> list = new List<int>();
            PreorderRecursion(root, list);
            return list;
        }
        private void PreorderRecursion(Node root, IList<int> list)
        {
            if (root == null)
                return;
            list.Add(root.val);
            foreach (var item in root.children)
            {
                PreorderRecursion(item, list);
            }
        }
        public TreeNode invertTree(TreeNode root)
        {
            if (root == null)
                return null;
            Queue<TreeNode> deque = new Queue<TreeNode>();
            deque.Enqueue(root);
            while (deque.Count != 0)
            {
                int size = deque.Count;
                while (size-- > 0)
                {
                    TreeNode node = deque.Dequeue();
                    swapChildren(node);
                    if (node.left != null) deque.Enqueue(node.left);
                    if (node.right != null) deque.Enqueue(node.right);
                }
            }
            return root;

        }


        //public TreeNode invertTree(TreeNode root)
        //{
        //    if (root == null)
        //    {
        //        return null;
        //    }
        //    invertTree(root.left);
        //    invertTree(root.right);
        //    swapChildren(root);
        //    return root;
        //}
        private void swapChildren(TreeNode root)
        {
            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;
        }


        public IList<IList<int>> levelOrder(TreeNode root)
        {
            IList<IList<int>> reList = new List<IList<int>>();
            checkFun02(root, reList);
            return reList;
        }
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="node"></param>
        /// <param name="deep"></param>
        /// <param name="reList"></param>
        public void checkFun01(TreeNode node, int deep, IList<IList<int>> reList)
        {
            if (node == null)
                return;
            deep++;
            if (reList.Count < deep)
            {
                IList<int> item = new List<int>();
                reList.Add(item);
            }
            reList[deep - 1].Add(node.val);
            checkFun01(node.left, deep, reList);
            checkFun01(node.right, deep, reList);
        }
        public void checkFun02(TreeNode node, IList<IList<int>> reList)
        {
            if (node == null)
                return;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(node);
            while (que.Count != 0)
            {
                IList<int> itemList = new List<int>();
                int len = que.Count();
                while (len > 0)
                {
                    TreeNode tmpNode = que.Dequeue();
                    itemList.Add(tmpNode.val);
                    if (tmpNode.left != null) que.Enqueue(tmpNode.left);
                    if (tmpNode.right != null) que.Enqueue(tmpNode.right);
                    len--;
                }
                reList.Add(itemList);
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null && n == 1)
                return null;
            ListNode temp = head;
            int index = RemoveNthFromEndrRcursion(temp, n);
            if (index == n)
            {
                head = head.next;
            }
            return head;
        }
        private int RemoveNthFromEndrRcursion(ListNode head, int n)
        {
            if (head == null)
            {
                return 0;
            }
            int index = RemoveNthFromEndrRcursion(head.next, n) + 1;
            if (index == n + 1)
            {
                head.next = head.next.next;
            }

            return index;

        }


        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode pre = head.next;
            ListNode newHead = new ListNode(-1, head);
            while (newHead.next != null)
            {
                ListNode next1 = newHead.next;
                if (next1.next != null)
                {
                    ListNode next2 = next1.next;
                    next1.next = next2.next;
                    next2.next = next1;
                    newHead.next = next2;
                    newHead = next1;

                }
                else
                {
                    newHead = next1;
                }
            }
            return pre;

        }


        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;




            //暴力
            //ListNode ans = null;
            //for (ListNode x = head; x != null; x = x.next)
            //{
            //    ans = new ListNode(x.val, ans);
            //}
            //return ans;


            //递归
            //if (head == null || head.next == null)
            //    return head;
            //ListNode newHead = ReverseList(head.next);
            //head.next.next = head;
            //head.next = null;
            //return newHead;

        }




        public ListNode GenerateListNode(int[] nums)
        {
            ListNode head = new ListNode(nums[0]);
            ListNode temp = head;
            for (int i = 0; i < nums.Length; ++i)
            {
                if (i == nums.Length - 1)
                {
                    temp.val = nums[i];
                }
                else
                {
                    temp.val = nums[i];
                    ListNode next = new ListNode();
                    temp.next = next;
                    temp = temp.next;
                }
            }
            return head;
        }




        public ListNode RemoveElements(ListNode head, int val)
        {

            if (head == null)
                return head;
            ListNode temp1 = new ListNode(-1);
            ListNode list = new ListNode(-1);
            list.next = head;
            temp1 = list;
            while (temp1.next != null)
            {
                ListNode temp = temp1.next;
                if (temp.val == val && temp.next != null)
                {
                    temp1.next = temp.next;
                    temp.next = null;
                }
                else if (temp.val == val && temp.next == null)
                {
                    temp1.next = null;
                }
                else
                {
                    temp1 = temp1.next;
                }
            }
            return list.next;
        }


        public void Solve(char[][] board)
        {
            int row = board.Length;
            int column = board[0].Length;
            int[][] flags = new int[row][];
            int[][] dir = new int[4][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            for (int i = 0; i < row; ++i)
            {
                flags[i] = new int[column];
                for (int j = 0; j < column; ++j)
                {
                    if (i == 0 || j == 0 || i == row - 1 || j == column - 1)
                    {
                        if (board[i][j] == 'O')
                            flags[i][j] = 2;
                    }
                    else if (board[i][j] == 'O')
                        flags[i][j] = 1;
                }
            }
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {
                    if (i == 0 || j == 0 || i == row - 1 || j == column - 1)
                    {
                        if (flags[i][j] == 2)
                        {
                            SolveSearch(i, j, dir, row, column, flags);
                        }
                    }
                }
            }
            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < column; ++j)
                {
                    if (flags[i][j] == 1)
                        board[i][j] = 'X';
                }
            }
        }
        public void SolveSearch(int nowi, int nowj, int[][] dir, int row, int column, int[][] flags)
        {
            for (int i = 0; i < 4; i++)
            {
                int fir = nowi + dir[i][0];
                int sec = nowj + dir[i][1];
                if (fir < 0 || fir >= row || sec < 0 || sec >= column)
                    continue;
                if (flags[fir][sec] == 1)
                {
                    flags[fir][sec] = 2;
                    SolveSearch(fir, sec, dir, row, column, flags);
                }
            }
        }


        public int LongestConsecutive(int[] nums)
        {
            ISet<int> dic = new HashSet<int>();
            int max = 0;
            foreach (int num in nums)
            {
                dic.Add(num);
            }
            foreach (int num in dic)
            {
                if (!dic.Contains(num - 1))
                {

                    int maxNum = num;
                    while (dic.Contains(maxNum + 1))
                    {
                        maxNum += 1;
                    }
                    max = Math.Max(max, maxNum - num + 1);
                }
            }
            return max;



            //ISet<int> dic = new HashSet<int>();
            //int max = 0;
            //foreach(int num in nums)
            //{
            //    dic.Add(num);
            //}
            //for(int i=0;i<nums.Length;++i)
            //{
            //    if(!dic.Contains(nums[i]-1))
            //    {
            //        int currentNum = nums[i];
            //        int currentStreak = 1;
            //        while(dic.Contains(currentNum+1))
            //        {
            //            currentNum += 1;
            //            currentStreak += 1;
            //        }
            //        max = Math.Max(max,currentStreak);
            //    }
            //}
            //return max;
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;
            ListNode newHead = head;
            while (newHead.next != null)
            {
                ListNode node = newHead.next;
                if (node.val == newHead.val)
                {
                    while (node.next != null)
                    {
                        if (node.val == node.next.val)
                        {
                            node = node.next;
                        }
                        else
                            break;
                    }
                    if (node.next == null)
                    {
                        newHead.next = null;
                    }
                    else
                    {
                        newHead.next = node.next;
                        newHead = newHead.next;
                    }
                }
                else
                    newHead = newHead.next;
            }
            return head;
        }
        public ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode temp = new ListNode(101);
            temp.next = head;
            ListNode newHead = temp;

            while (newHead.next != null && newHead.next.next != null)
            {
                ListNode node = newHead.next;
                ListNode node1 = node.next;
                if (node.val == node1.val && node.val != newHead.val)
                {
                    while (node1.next != null)
                    {
                        if (node1.next.val == node1.val)
                            node1 = node1.next;
                        else
                            break;
                    }
                    if (node1.next == null)
                    {
                        newHead.next = null;
                    }
                    else
                    {
                        newHead.next = node1.next;
                    }
                }
                else
                    newHead = node;
            }
            return temp.next;
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (k == 0 || head == null || head.next == null)
                return head;
            int n = 1;
            ListNode item = head;
            while (item.next != null)
            {
                item = item.next;
                n++;
            }
            int add = n - k % n;
            if (add == n)
                return head;
            item.next = head;
            while (add-- > 0)
                item = item.next;
            ListNode ret = item.next;
            item.next = null;
            return ret;
        }




        #region N皇后 基于集合的回溯
        //public IList<IList<string>> SolveNQueens(int n)
        //{
        //    int[] queens = new int[n];
        //    for (int i = 0; i < n; ++i)
        //        queens[i] = -1;
        //    IList<IList<string>> list = new List<IList<string>>();
        //    HashSet<int> columns = new HashSet<int>();
        //    HashSet<int> diagonals1 = new HashSet<int>();
        //    HashSet<int> diagonals2 = new HashSet<int>();
        //    backtrack(list,queens,n,0,columns,diagonals1,diagonals2);

        //    return list;
        //}
        //public void backtrack(IList<IList<string>> list, int[] queens, int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        //{
        //    if (row == n)
        //    {
        //        IList<string> temp = generateRow(queens);
        //        list.Add(temp);
        //    }
        //    else
        //    {
        //        for(int i=0;i<n;++i)
        //        {
        //            if (columns.Contains(i))
        //                continue;
        //            int diagonal1 = row - i;
        //            if (diagonals1.Contains(diagonal1))
        //                continue;
        //            int diagonal2 = row + i;
        //            if (diagonals2.Contains(diagonal2))
        //                continue;
        //            columns.Add(i);
        //            queens[row] = i;
        //            diagonals1.Add(diagonal1);
        //            diagonals2.Add(diagonal2);
        //            backtrack(list,queens,n,row+1,columns,diagonals1,diagonals2);
        //            queens[row] = -1;
        //            columns.Remove(i);
        //            diagonals1.Remove(diagonal1);
        //            diagonals2.Remove(diagonal2);
        //        }
        //    }
        //}
        //public IList<string> generateRow(int[] queens)
        //{
        //    IList<string> list = new List<string>();
        //    for(int i=0;i<queens.Length;++i)
        //    {
        //        char[] temp = new char[queens.Length];
        //        for (int j = 0; j < temp.Length; ++j)
        //            temp[j] = '.';
        //        temp[queens[i]] = 'Q';
        //        list.Add(new string(temp));
        //    }
        //    return list;
        //}
        #endregion

    }
}
