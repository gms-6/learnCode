using learncode.Model;
using learncode.ReviewCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode
{
    public class Program
    {
        public static int TARGET = 24;
        public static double EPSILON = 1e-6;
        public static int ADD = 0, MuLTIPLY = 1, SUBTRACK = 2, DIVIDE = 3;
        public static void Main()
        {
            Revire230505 test = new Revire230505();
            Review test1 = new Review();
            int[] nums1 = {1,2,3};
            int[] nums2 = { 8,9,8,8};
            //int[][] mat = new int[][] { 
            //    new int[] {1,2,2,3,5 }, 
            //    new int[] { 3,2,3,4,4 }, 
            //    new int[] {2,4,5,3,1}, 
            //    new int[] {6,7,1,4,5 }, 
            //    new int[] { 5,1,1,2,4 }};
            int[][] mat = new int[][] {
                new int[] { -52,31  },
                new int[] { -73,-26  },
                new int[] { 82,97  },
                new int[] { -65,-11  },
                new int[] { -62,-11  },
                new int[] { -62,-49  },
                new int[] { 95,99  },
                new int[] { 58,95  },
                new int[] { -31,39  },
                new int[] { 66,98  },
                new int[] { -63,2  },
                new int[] { 30,47  },
                new int[] { -40,-26  }
            };
            var l1= test1.GenerateListNode(nums1);
            var l2= test1.GenerateListNode(nums2);
            var head = test.AddTwoNumbers(l1,l2);
            //Show(nums1);
            Console.ReadKey();
        }
        /// <summary>
        /// O(N)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <param name="cur"></param>
        public void shiftDown(int[] nums,int n,int cur)
        {
            int child = 2 * cur + 1;
            while(child<n)
            {
                if (child + 1 < n && nums[child + 1] < nums[child])
                    ++child;
                if(nums[child]<nums[cur])
                {
                    int temp = nums[child];
                    nums[child] = nums[cur];
                    nums[cur] = temp;
                    cur = child;
                    child = 2 * cur + 1;
                }
            }
        }
        /// <summary>
        /// O(Nlog(N))
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        /// <param name="cur"></param>
        public void shiftUP(int[] nums,int n,int cur)
        {
            int parent = (cur - 1) / 2;
            while(cur>0)
            {
                if (nums[parent] > nums[cur])
                {
                    int temp = nums[parent];
                    nums[parent] = nums[cur];
                    nums[cur] = temp;
                    cur = parent;
                    parent = (cur - 1) / 2;
                }
                else
                    break;
            }
        }
        /// <summary>
        /// 下滤建立小根堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        public void createHeapDown(int[] nums,int n)
        {
            for(int i=(n-2)/2;i>=0;--i)
            {
                shiftDown(nums,n,i);
            }
        }
        /// <summary>
        /// 上滤建立小根堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="n"></param>
        public void createHeapUp(int[] nums,int n)
        {
            for(int i=1;i<n;++i)
            {
                shiftUP(nums,n,i);
            }
        }
        public IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> solutions = new List<IList<string>>();
            int[] queens = new int[n];
            for (int i = 0; i < n; ++i)
            {
                queens[i] = -1;
            }
            HashSet<int> columns = new HashSet<int>();
            HashSet<int> diagonals1 = new HashSet<int>();
            HashSet<int> diagonals2 = new HashSet<int>();
            backtrack(solutions, queens, n, 0, columns, diagonals1, diagonals2);
            return solutions;
        }
        public void backtrack(IList<IList<string>> solutions, int[] queens, int n, int row, HashSet<int> columns, HashSet<int> diagonals1, HashSet<int> diagonals2)
        {
            if (row == n)
            {
                IList<string> board = generateBoard(queens, n);
                solutions.Add(board);
            }
            else
            {
                for (int i = 0; i < n; ++i)
                {
                    if (columns.Contains(i))
                    {
                        continue;
                    }
                    int diagonal1 = row - i;
                    if (diagonals1.Contains(diagonal1))
                        continue;
                    int diagonal2 = row + i;
                    if (diagonals2.Contains(diagonal2))
                        continue;
                    queens[row] = i;
                    columns.Add(i);
                    diagonals1.Add(diagonal1);
                    diagonals2.Add(diagonal2);
                    backtrack(solutions, queens, n, row + 1, columns, diagonals1, diagonals2);
                    queens[row] = -1;
                    columns.Remove(i);
                    diagonals1.Remove(diagonal1);
                    diagonals2.Remove(diagonal2);
                }
            }
        }
        public IList<string> generateBoard(int[] queens, int n)
        {
            IList<string> board = new List<string>();
            for (int i = 0; i < n; ++i)
            {
                char[] row = new char[n];
                for (int j = 0; j < n; ++j)
                {
                    row[j] = '.';

                }
                row[queens[i]] = 'Q';
                board.Add(new string(row));
            }
            return board;
        }
        public string GetPermutation(int n, int k)
        {
            if (n == 1)
            {
                return "1";
            }
            int total = 1;
            int[] nums = new int[n];
            for (int i = 1; i <= n; ++i)
            {
                nums[i - 1] = i;
                total *= i;
            }
            List<string> list = new List<string>();
            bool[] flag = new bool[n];
            int[] gen = new int[n];
            GetPermutationDFS(0, k, flag, gen, nums, list);
            return list[k - 1];

        }
        private bool GetPermutationDFS(int step, int targetIndex, bool[] flag, int[] gen, int[] nums, List<string> list)
        {

            if (step == flag.Length)
            {
                string str = null;
                for (int i = 0; i < gen.Length; ++i)
                {
                    str += $"{gen[i]}";
                }
                list.Add(str);
                if (list.Count == targetIndex)
                    return true;
                else
                    return false;

            }
            for (int i = 0; i < gen.Length; ++i)
            {
                if (!flag[i])
                {
                    flag[i] = true;
                    gen[step] = nums[i];
                    bool res = GetPermutationDFS(step + 1, targetIndex, flag, gen, nums, list);
                    if (res)
                        return true;
                    flag[i] = false;

                }
            }
            return false;
        }
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            IList<int> path = new List<int>();
            if (nums.Length == 0)
            {
                list.Add(path);
                return list;
            }
            bool[] used = new bool[nums.Length];
            Array.Sort(nums);
            SubsetsWithDupDFS(nums, 0, used, list, path);
            return list;
        }
        private void SubsetsWithDupDFS(int[] nums, int startIndex, bool[] used, IList<IList<int>> list, IList<int> path)
        {
            list.Add(new List<int>(path));
            if (startIndex >= nums.Length)
            {
                return;
            }
            for (int i = startIndex; i < nums.Length; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1])
                    continue;
                used[i] = true;
                path.Add(nums[i]);
                SubsetsWithDupDFS(nums, i + 1, used, list, path);
                path.RemoveAt(path.Count - 1);
                used[i] = false;
            }
        }
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (candidates.Length == 1)
            {
                if (candidates[0] == target)
                {
                    IList<int> temp = new List<int>() { target };
                    list.Add(temp);
                }
                return list;
            }

            IList<int> cap = new List<int>();
            int sum = 0;
            bool[] flag = new bool[candidates.Length];
            Array.Sort(candidates);
            CombinationSum2DFS(sum, target, 0, false, candidates, cap, list, flag);
            return list;
        }
        private void CombinationSum2DFS(int sum, int target, int index, bool res, int[] candidates, IList<int> cap, IList<IList<int>> list, bool[] flag)
        {
            if (sum >= target)
            {
                if (sum == target)
                {
                    IList<int> temp = new List<int>();
                    foreach (var item in cap)
                    {
                        temp.Add(item);
                    }
                    list.Add(temp);
                }
            }
            else
            {
                for (int i = index; i < candidates.Length; ++i)
                {
                    if (flag[i])
                        continue;
                    if (i > 0 && candidates[i] == candidates[i - 1] && !flag[i - 1])
                        continue;
                    if (i == candidates.Length - 1)
                        res = true;
                    else
                        res = false;
                    flag[i] = true;
                    cap.Add(candidates[i]);
                    int temp = sum + candidates[i];
                    CombinationSum2DFS(temp, target, i, res, candidates, cap, list, flag);
                    if (res && cap.Count != 0)
                        cap.RemoveAt(cap.Count - 1);
                    if (temp >= target)
                    {
                        if (cap.Count != 0)
                        {
                            cap.RemoveAt(cap.Count - 1);
                        }
                    }
                    flag[i] = false;

                }
            }
        }
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            int len = nums.Length;
            IList<IList<int>> list = new List<IList<int>>();
            bool[] flag = new bool[len];
            int[] target = new int[len];
            Array.Sort(nums);
            Dfs(0, list, flag, target, nums);
            return list;
        }
        private void Dfs(int step, IList<IList<int>> list, bool[] flag, int[] target, int[] nums)
        {
            if (step == nums.Length)
            {
                IList<int> temp = new List<int>();
                for (int i = 0; i < target.Length; ++i)
                {
                    temp.Add(target[i]);
                }
                list.Add(temp);
            }
            else
            {
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (flag[i])
                        continue;
                    if (i > 0 && nums[i] == nums[i - 1] && !flag[i - 1])
                        continue;
                    flag[i] = true;
                    target[step] = nums[i];
                    Dfs(step + 1, list, flag, target, nums);
                    flag[i] = false;
                }
            }

        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            IList<int> cap = new List<int>();
            int sum = 0;
            CombinationSumDFS(sum, target, 0, candidates, cap, list, false);
            return list;
        }
        private void CombinationSumDFS(int sum, int target, int index, int[] candidates, IList<int> cap, IList<IList<int>> list, bool flag)
        {
            if (sum >= target)
            {
                if (sum == target)
                {
                    IList<int> temp = new List<int>();
                    foreach (var item in cap)
                    {
                        temp.Add(item);
                    }
                    list.Add(temp);
                }
            }
            else
            {
                for (int i = index; i < candidates.Length; ++i)
                {
                    if (i == candidates.Length - 1)
                        flag = true;
                    else
                        flag = false;
                    cap.Add(candidates[i]);
                    int temp = sum + candidates[i];
                    CombinationSumDFS(temp, target, i, candidates, cap, list, flag);
                    if (flag && cap.Count != 0)
                    {
                        cap.RemoveAt(cap.Count - 1);
                    }
                    if (temp >= target)
                    {
                        if (cap.Count != 0)
                        {
                            cap.RemoveAt(cap.Count - 1);
                            continue;
                        }
                    }
                }
            }
        }
        public int Search12(int[] nums, int target)
        {
            int n = nums.Length;
            if (n == 0)
                return -1;
            else if (n == 1)
            {
                return nums[0] == target ? 0 : -1;
            }
            int left = 0, right = n - 1;
            while (left <= right)
            {
                int mid = (left + right) >> 1;
                if (nums[mid] == target)
                    return mid;
                if (nums[0] <= nums[mid])
                {
                    if (target >= nums[0] && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (target > nums[mid] && target <= nums[n - 1])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return -1;
        }
        public bool Search(int[] nums, int target)
        {
            return true;
        }

        public int RemoveDuplicates(int[] nums)
        {
            int n = nums.Length;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < n - count; ++i)
            {
                Show(nums);
                if (dic.ContainsKey(nums[i]))
                {
                    if (dic[nums[i]] == 2)
                    {
                        for (int j = i + 1; j < n - count; ++j)
                        {
                            nums[j - 1] = nums[j];
                        }
                        count++;
                        i--;
                    }
                    else
                        dic[nums[i]] += 1;
                }
                else
                {
                    dic.Add(nums[i], 1);
                }
            }
            return n - count;

        }
        public bool Exist(char[][] board, string word)
        {
            int h = board.Length, w = board[0].Length;
            bool[,] visited = new bool[h, w];
            for (int i = 0; i < h; ++i)
            {
                for (int j = 0; j < w; ++j)
                {
                    bool flag = ExistCheck(board, visited, i, j, word, 0);
                    if (flag)
                        return true;
                }
            }
            return false;
        }
        private bool ExistCheck(char[][] board, bool[,] visited, int i, int j, string s, int k)
        {
            if (board[i][j] != s[k])
                return false;
            else if (k == s.Length - 1)
                return true;
            visited[i, j] = true;
            int[][] dirctions = new int[4][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
            bool result = false;
            foreach (var dir in dirctions)
            {
                int newi = i + dir[0], newj = j + dir[1];
                if (newi >= 0 && newi < board.Length && newj >= 0 && newj < board[0].Length)
                {
                    if (!visited[newi, newj])
                    {
                        bool flag = ExistCheck(board, visited, newi, newj, s, k + 1);
                        if (flag)
                        {
                            result = true;
                            break;
                        }
                    }
                }
            }
            visited[i, j] = false;
            return result;
        }


        public IList<IList<int>> Subsets(int[] nums)
        {
            int n = nums.Length;
            IList<IList<int>> list = new List<IList<int>>();
            list.Add(new List<int>());

            for (int i = 1; i <= nums.Length; ++i)
            {
                int[] targets = new int[i];
                SubsetsDFS(0, 0, nums, targets, list);
            }
            return list;
        }
        private void SubsetsDFS(int step, int index, int[] nums, int[] targets, IList<IList<int>> list)
        {
            if (step == targets.Length)
            {
                IList<int> temp = new List<int>();
                for (int i = 0; i < targets.Length; ++i)
                {
                    temp.Add(targets[i]);
                }
                list.Add(temp);
            }
            else
            {
                for (int i = index; i < nums.Length; ++i)
                {
                    targets[step] = nums[i];
                    SubsetsDFS(step + 1, i + 1, nums, targets, list);
                }
            }
        }
        public IList<IList<int>> Combine(int n, int k)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (n == 1)
            {
                IList<int> temp = new List<int>();
                temp.Add(n);
                list.Add(temp);
                return list;
            }
            int[] targets = new int[k];
            CombineDFS(0, 1, n, targets, list);
            return list;
        }
        private void CombineDFS(int step, int index, int n, int[] targets, IList<IList<int>> list)
        {
            if (step == targets.Length)
            {
                IList<int> temp = new List<int>();
                for (int i = 0; i < targets.Length; ++i)
                {
                    temp.Add(targets[i]);
                }
                list.Add(temp);
                return;
            }
            for (int i = index; i <= n; ++i)
            {
                targets[step] = i;
                CombineDFS(step + 1, i + 1, n, targets, list);
            }
        }

        public int MySqrt(int x)
        {
            if (x == 0)
                return 0;
            double x0 = x;
            double x1 = (x0 + x / x0) / 2;
            while (Math.Abs(x1 - x0) > 0.001)
            {
                x0 = x1;
                x1 = (x0 + x / x0) / 2;
            }
            return (int)x1;
        }
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int n = s1.Length, m = s2.Length, t = s3.Length;

            if (n + m != t)
                return false;
            bool[,] dp = new bool[n + 1, m + 1];
            dp[0, 0] = true;
            for (int i = 0; i <= n; ++i)
            {
                for (int j = 0; j <= m; ++j)
                {
                    int p = i + j - 1;
                    if (i > 0)
                    {
                        dp[i, j] = dp[i, j] || (dp[i - 1, j] && s1[i - 1] == s3[p]);
                    }
                    if (j > 0)
                    {
                        dp[i, j] = dp[i, j] || (dp[i, j - 1] && s1[j - 1] == s3[p]);
                    }
                }
            }
            return dp[n, m];

        }
        public int[][] GenerateMatrix(int n)
        {
            if (n == 1)
                return new int[1][] { new int[1] { 1 } };
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; ++i)
            {
                matrix[i] = new int[n];
            }
            int[][] dir = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            int fir = 0, sec = 0;
            int index = 0;
            for (int i = 1; i < n * n + 1; ++i)
            {
                matrix[fir][sec] = i;
                if (fir + dir[index][0] >= n || fir + dir[index][0] < 0 || sec + dir[index][1] >= n || sec + dir[index][1] < 0 || matrix[fir + dir[index][0]][sec + dir[index][1]] != 0)
                {
                    index++;
                    index = index == 4 ? 0 : index;
                }
                fir = fir + dir[index][0];
                sec = sec + dir[index][1];
            }
            return matrix;
        }


        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 1)
                return new int[1][] { new int[2] { intervals[0][0], intervals[0][1] } };
            int row = intervals.Length;
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < row - 1 - i; ++j)
                {
                    if (intervals[j][0] > intervals[j + 1][0])
                    {
                        int temp = intervals[j][0];
                        intervals[j][0] = intervals[j + 1][0];
                        intervals[j + 1][0] = temp;
                        temp = intervals[j][1];
                        intervals[j][1] = intervals[j + 1][1];
                        intervals[j + 1][1] = temp;
                    }
                }
            }
            int left = intervals[0][0], right = intervals[0][1];
            for (int i = 0; i < row; ++i)
            {
                int tempLeft = intervals[i][0];
                int tempRight = intervals[i][1];
                if (tempLeft <= right)
                {
                    if (tempRight >= right)
                        right = tempRight;
                }
                else
                {
                    List<int> temp1 = new List<int>() { left, right };
                    list.Add(temp1);
                    left = tempLeft;
                    right = tempRight;
                }
            }
            list.Add(new List<int>() { left, right });

            int[][] result = new int[list.Count][];
            for (int i = 0; i < list.Count; ++i)
            {
                result[i] = new int[2] { list[i][0], list[i][1] };
            }

            return result;
        }
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> list = new List<int>();
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[][] dir = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            bool[,] flag = new bool[m, n];
            int index = 0;
            int fir = 0, sec = 0;
            //list.Add(matrix[0][0]);
            for (int i = 0; i < m * n - 1; ++i)
            {
                flag[fir, sec] = true;
                list.Add(matrix[fir][sec]);
                if (fir + dir[index][0] >= m || fir + dir[index][0] < 0 || sec + dir[index][1] >= n || sec + dir[index][1] < 0 || flag[fir + dir[index][0], sec + dir[index][1]])
                {
                    index++;
                    if (index == 4)
                        index = 0;
                }
                fir = fir + dir[index][0];
                sec = sec + dir[index][1];
            }
            return list;

        }
        public bool CanJump(int[] nums)
        {
            int len = nums.Length;
            int maxPosition = 0;
            for (int i = 0; i < len; ++i)
            {
                if (i <= maxPosition)
                {
                    maxPosition = Math.Max(maxPosition, nums[i] + i);
                    if (maxPosition >= len - 1)
                        return true;
                }
            }
            return false;



            //int len = nums.Length;
            //if (len == 1 && nums[0] == 0)
            //    return false;
            //int[,] dp = new int[len,len];
            //dp[len - 1, len - 1] = 0;
            //int max = 0;
            //for(int i=len-2;i>=0;--i)
            //{
            //    if(nums[i]+i>=len-1)
            //    {
            //        dp[i, len - 1] = 1;
            //    }
            //    else if(nums[i]!=0)
            //    {
            //        for(int j=i+1;j<=nums[i]+i;++j)
            //        {
            //            if (max < dp[j, len - 1])
            //                max = dp[j, len - 1];
            //        }
            //        if(max==0)
            //        {
            //            dp[i, len - 1] = 0;
            //        }
            //        else
            //        {
            //            dp[i, len - 1] = max + 1;
            //            max = 0;
            //        }
            //    }
            //    else if(nums[i]==0)
            //    {
            //        dp[i, len - 1] = 0;
            //    }
            //}

            //return dp[0, len - 1]>0?true:false;
        }
        public void Rotate(int[][] matrix)
        {
            int n = matrix.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][n - 1 - i];
                    matrix[j][n - 1 - i] = temp;

                }
            }
        }

        public string CountAndSay(int n)
        {
            if (n == 1)
                return "1";
            return CountAndSayDigui(1, "1", n);
        }
        private string CountAndSayDigui(int step, string str, int n)
        {
            if (step == n)
                return str;
            bool flag = false;
            string temp = "";
            int count = 0;
            char num = ' ';
            for (int i = 0; i < str.Length; ++i)
            {
                num = str[i];
                count++;
                int k = i + 1;
                flag = true;
                while (k < str.Length)
                {
                    if (str[k] == num)
                    {
                        ++k;
                        count++;
                    }
                    else
                    {
                        temp += $"{count}{num}";
                        count = 0;
                        flag = false;
                        break;
                    }
                }
                i = k - 1;
            }
            if (flag)
            {
                temp += $"{count}{num}";
            }
            return CountAndSayDigui(step + 1, temp, n);
        }
        public int[] SearchRange(int[] nums, int target)
        {
            int left = FindLeft(nums, target);
            int right = FindRight(nums, target);
            if (left == -1)
                return new int[] { -1, -1 };
            else
                return new int[] { left, right };
        }

        private int FindRight(int[] nums, int target)
        {
            int len = nums.Length;
            int left = 0, right = len - 1;
            int mid;
            while (left < right)
            {
                mid = (left + right + 1) >> 1;

                //[right,mid-1]
                if (nums[mid] > target) right = mid - 1;
                //[mid+1,right]
                else if (nums[mid] < target) left = mid + 1;
                //[mid,right]
                else if (nums[mid] == target) left = mid;

            }
            return left;
        }

        private int FindLeft(int[] nums, int target)
        {
            int len = nums.Length;
            int left = 0, right = len - 1;
            int mid;

            while (left < right)
            {
                mid = (left + right) >> 1;
                //[left,mid-1]
                if (nums[mid] > target) right = mid - 1;
                //[mid+1,right]
                else if (nums[mid] < target) left = mid + 1;
                //[left,mid]
                else if (nums[mid] == target) right = mid;
            }
            if (nums[left] != target)
                return -1;
            else
                return left;
        }

        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> list = new List<string>();
            List<char> charList = GenerateParent(n);
            Dictionary<string, int> dic = new Dictionary<string, int>();

            char[] temp = new char[2 * n];
            bool[] flag = new bool[charList.Count];
            DFS(0, list, charList, temp, flag, dic);
            return list;


        }
        public bool Isparentheses(char[] temp)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < temp.Length; ++i)
            {
                if (temp[i] == '(')
                {
                    stack.Push(temp[i]);
                }
                else
                {
                    if (stack.Count == 0)
                        return false;
                    stack.Pop();

                }
            }
            if (stack.Count == 0)
                return true;
            else
                return false;
        }


        public void DFS(int step, IList<string> list, List<char> charList, char[] temp, bool[] flag, Dictionary<string, int> dic)
        {
            if (step == charList.Count)
            {
                string str = new string(temp);
                if (!dic.ContainsKey(str))
                {
                    if (Isparentheses(temp))
                    {
                        list.Add(str);
                        dic.Add(str, 1);
                    }
                }
            }
            else
            {
                for (int i = 0; i < charList.Count; i++)
                {
                    if (!flag[i])
                    {
                        flag[i] = true;
                        temp[step] = charList[i];
                        DFS(step + 1, list, charList, temp, flag, dic);
                        flag[i] = false;
                    }
                }
            }
        }


        public List<char> GenerateParent(int n)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < n; i++)
            {
                list.Add('(');
                list.Add(')');
            }
            return list;
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //ListNode tempHead = new ListNode() ;
            //tempHead.next = head;
            //int count = 1;
            //int index = 1;
            //while (tempHead.next != null)
            //{
            //    count++;
            //    tempHead = tempHead.next;
            //}
            //ListNode tempHead1 = head;
            //while (index != count - n )
            //{
            //    index++;
            //    tempHead1 = tempHead1.next;
            //}
            //ListNode temp = tempHead1.next;
            //tempHead.next = temp.next;
            return head;



        }

        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            List<char> list = new List<char>();
            IList<string> result = new List<string>();
            char[] twoChar = new char[digits.Length];
            InitDic(dic);

            bool[] flag = new bool[list.Count];
            DFS(0, digits, dic, result, twoChar);
            return result;
        }
        public void DFS(int step, string digits, Dictionary<int, string> dic, IList<string> result, char[] twoChar)
        {
            if (step == digits.Length)
            {
                result.Add(new string(twoChar));
            }
            else
            {
                int n = Convert.ToInt32($"{digits[step]}");
                dic.TryGetValue(n, out string str);
                for (int i = 0; i < str.Length; i++)
                {
                    twoChar[step] = str[i];
                    DFS(step + 1, digits, dic, result, twoChar);

                }
            }
        }
        public void InitDic(Dictionary<int, string> dic)
        {
            dic.Add(2, "abc");
            dic.Add(3, "def");
            dic.Add(4, "ghi");
            dic.Add(5, "jkl");
            dic.Add(6, "mno");
            dic.Add(7, "pqrs");
            dic.Add(8, "tuv");
            dic.Add(9, "wxyz");

        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            int len = nums.Length;
            if (len < 3)
                return list;
            Array.Sort(nums);
            for (int i = 0; i < len - 2; ++i)
            {
                if (nums[i] > 0)
                    break;
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int j = i + 1, k = len - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        IList<int> temp = new List<int>() { nums[i], nums[j], nums[k] };
                        list.Add(temp);
                        while (j < k && nums[j] == nums[j + 1])
                            ++j;
                        while (j < k && nums[k] == nums[k - 1])
                            --k;
                        ++j;
                        --k;
                    }
                    else if (sum > 0)
                        --k;
                    else if (sum < 0)
                        ++j;
                }
            }
            return list;
        }
        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int best = 1000000;
            for (int i = 0; i < n; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                int j = i + 1, k = n - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == target)
                        return sum;
                    if (Math.Abs(sum - target) < Math.Abs(best - target))
                        best = sum;
                    if (sum > target)
                    {
                        int k0 = k - 1;
                        while (j < k0 && nums[k0] == nums[k])
                            --k0;
                        k = k0;
                    }
                    else
                    {
                        int j0 = j + 1;
                        while (j0 < k && nums[j0] == nums[j])
                            ++j0;
                        j = j0;
                    }
                }

            }
            return best;
        }
        public static int MyAtoi(string s)
        {
            bool negative = false;
            bool flag = false;
            int begin = 0, count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 49 && s[i] <= 57 && !flag)
                {
                    begin = i;
                    count++;
                    flag = true;
                }
                else if (s[i] >= 48 && s[i] <= 57 && flag)
                {
                    count++;
                }
                else if ((s[i] != ' ' || s[i] != '-' || s[i] != '"') && !flag)
                    return 0;
                else
                {
                    if (flag)
                    {
                        break;
                    }
                    flag = false;
                    count = 0;
                }
            }

            if (begin == 0 && count != 0)
            {
                double num1 = Convert.ToDouble(s.Substring(begin, count));

                if (num1 > int.MaxValue)
                {
                    return int.MaxValue;
                }
                else
                    return (int)num1;
            }
            else if (begin != 0)
            {
                double num1 = Convert.ToDouble(s.Substring(begin, count));

                if (s[begin - 1] == '-')
                {
                    num1 = num1 * (-1);
                    if (num1 < int.MinValue)
                        return int.MinValue;
                    else
                        return (int)num1;
                }
                else
                {
                    if (num1 > int.MaxValue)
                        return int.MaxValue;
                    else
                        return (int)num1;
                }

            }
            else
                return 0;

        }




        public static string LongestPalindrome1(string s)
        {
            int len = s.Length;
            int[,] dp = new int[len, len];
            int begin = 0, max = 0;
            for (int j = 0; j < len; ++j)
            {
                for (int i = 0; i <= j; ++i)
                {
                    if (i == j)
                    {
                        dp[i, j] = 1;
                        if (max < j - i + 1)
                        {
                            max = j - i + 1;
                            begin = i;
                        }
                    }
                    else if (s[i] == s[j])
                    {
                        if ((j - i) > 2)
                        {
                            dp[i, j] = dp[i + 1, j - 1];
                            if (dp[i, j] == 1)
                            {
                                if (max < j - i + 1)
                                {
                                    max = j - i + 1;
                                    begin = i;
                                }
                            }
                        }
                        else
                        {
                            dp[i, j] = 1;
                            if (max < j - i + 1)
                            {
                                max = j - i + 1;
                                begin = i;
                            }
                        }

                    }
                }
            }
            return s.Substring(begin, max);
        }
        public bool judgePoint24(int[] nums)
        {
            List<double> list = new List<double>();
            foreach (int num in nums)
            {
                list.Add(num);
            }
            return Dfs1(list);
        }
        private bool Dfs1(List<double> list)
        {
            if (list.Count == 1)
            {
                if (Math.Abs(list[0] - 24.0) < 0.001)
                    return true;
            }
            for (int i = 0; i < list.Count; ++i)
            {
                for (int j = i + 1; j < list.Count; ++j)
                {
                    foreach (double c in generatePossibleResults(list[i], list[j]))
                    {
                        List<double> nextRound = new List<double>();
                        nextRound.Add(c);
                        for (int k = 0; k < list.Count; ++k)
                        {
                            if (k == i || k == j)
                                continue;
                            nextRound.Add(list[k]);
                        }
                        if (Dfs1(nextRound))
                            return true;
                    }
                }
            }
            return false;
        }
        private List<double> generatePossibleResults(double a, double b)
        {
            List<double> res = new List<double>();
            res.Add(a + b);
            res.Add(a - b);
            res.Add(b - a);
            res.Add(a * b);
            res.Add(a / b);
            res.Add(b / a);
            return res;
        }

        public static bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            int count = pushed.Length;
            Stack<int> stack = new Stack<int>();
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                stack.Push(pushed[i]);
                while (!(stack.Count == 0) && popped[index] == stack.Peek())
                {
                    stack.Pop();
                    index++;
                }
            }
            if (stack.Count != 0)
                return false;
            else
            {
                return true;
            }



        }

        public static void DfsTest(int step, int n, int[] a, int[] hand)
        {
            if (step == n + 1)
            {
                for (int i = 1; i <= n; i++)
                    Console.Write(a[i] + "");
                Console.WriteLine();
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                if (hand[i] == 0)
                {
                    hand[i] = 1;
                    a[step] = i;
                    DfsTest(step + 1, n, a, hand);
                    hand[i] = 0;

                }
            }


        }

        public static void Show(IList<int> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
        public static void Show(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        public static int HowDays(int month, bool res, int sum)
        {
            if (month < 1)
                return sum;
            int days = 0;
            switch (month)
            {
                case 2:
                    if (res)
                        days = 29;
                    else
                        days = 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
                default:
                    days = 31;
                    break;
            }
            sum += days;
            return HowDays(month - 1, res, sum);
        }

        public static bool IsGeneral(char temp)
        {
            if ((temp >= 65 && temp <= 90) || (temp >= 97 && temp <= 122) || (temp >= 48 && temp <= 67))
                return true;
            else
                return false;

        }

        private static int CalcResult(int a, int b, char c)
        {
            int result = 0;
            switch (c)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;

            }
            return result;
        }

        #region 深度优先搜索 迷宫问题

        public void MazeDFS(int x, int y, int k)
        {

        }

        #endregion

        /// <summary>
        /// 全排列问题
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="v"></param>
        public static void DFS(int k, int n, int[] a, bool[] v)
        {
            if (k == n + 1)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.Write($"{a[i]} ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    if (!v[i])
                    {
                        v[i] = true;
                        a[k] = i;
                        DFS(k + 1, n, a, v);
                        v[i] = false;
                        a[k] = 0;
                    }
                }
            }
        }


        //public void dfs(int k)
        //{
        //    if (k == n + 1)
        //    {
        //        for (int i = 1; i < n; i++)
        //            Console.Write($"{a[i]}  ");
        //        Console.Write($"{a[n]}\n");
        //    }
        //    else
        //    {
        //        for (int i = 1; i <= n; i++)
        //        {
        //            if (!v[i])
        //            {
        //                v[i] = true;
        //                a[k] = i;
        //                dfs(k + 1);
        //                a[k] = 0;
        //                v[i] = false;
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// leet 5. 最长回文子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome(string s)
        {
            int len = s.Length;
            if (len < 2)
                return s;

            int maxLen = 1;
            int begin = 0;
            bool[][] dp = new bool[len][];
            for (int i = 0; i < len; i++)
            {
                dp[i] = new bool[len];
                dp[i][i] = true;
            }

            for (int j = 0; j < len; j++)
            {
                for (int i = 0; i > j; i++)
                {
                    if (s[i] != s[j])
                        dp[i][j] = false;
                    else
                    {
                        if (j - i < 3)
                            dp[i][j] = true;
                        else
                            dp[i][j] = dp[i + 1][j - 1];
                    }
                    if (dp[i][j] && j - i + 1 > maxLen)
                    {
                        maxLen = j - i + 1;
                        begin = i;
                    }
                }
            }
            return s.Substring(begin, maxLen);



            //for(int i=0;i<len;i++)
            //{
            //    for(int j=i+1;j<len;j++)
            //    {
            //        if (s[i] != s[j])
            //            dp[i][j] = false;
            //        else
            //        {
            //            if (j - i < 3)
            //                dp[i][j] = true;
            //            else
            //                dp[i][j] = dp[i + 1][j - 1];
            //        }
            //        if (dp[i][j] && j - i + 1 > maxLen)
            //        {
            //            maxLen = j - i + 1;
            //            begin = i;
            //        }
            //    }

            //}
            //return s.Substring(begin, maxLen + 1);
        }
        private void ShowArray(int[][] num)
        {

        }

        /// <summary>
        /// leet LCS 01. 下载插件
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int LeastMinutes(int n)
        {
            if (n == 1)
                return n;
            else
            {
                if (n % 2 == 0)
                    return n / 2 + 1;
                else
                    return n / 2 + 2;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="relation"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int NumWays(int n, int[][] relation, int k)
        {
            int[,] dp = new int[k + 1, n];
            dp[0, 0] = 1;
            for (int i = 0; i < k; i++)
            {
                foreach (int[] edge in relation)
                {
                    int src = edge[0], dst = edge[1];
                    dp[i + 1, dst] += dp[i, src];
                }
            }
            return dp[k, n - 1];
        }



        /// <summary>
        /// 1025. 除数博弈
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool DivisorGame(int n)
        {
            if (n == 1)
                return false;
            bool[] game = new bool[n + 1];
            game[1] = false;
            game[2] = true;
            for (int i = 3; i < n; i++)
            {
                game[i] = true;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0 && game[i - j] == true)
                    {
                        game[i] = false;
                        break;
                    }
                }
            }
            return game[n];
        }

        /// <summary>
        /// leet 509. 斐波那契数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fib(int n)
        {
            if (n == 0 || n == 1)
                return n;
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }


        /// <summary>
        /// leet 392. 判断子序列
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsSubsequence(string s, string t)
        {
            int sn = s.Length, tn = t.Length;
            int i = 0, j = 0;
            while (i < sn && j < tn)
            {
                if (s[i] == t[j])
                    i++;
                j++;
            }
            return i == sn;
        }

        /// <summary>
        /// leet 118. 杨辉三角
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> list = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                IList<int> list2 = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    list2.Add(1);
                }
                list.Add(list2);
            }
            if (numRows == 1 || numRows == 2)
            {
                return list;
            }
            for (int i = 2; i < numRows; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    list[i][j] = list[i - 1][j - 1] + list[i - 1][j];
                }
            }
            return list;
        }
        public static bool IsCharacter(char temp)
        {
            if ((temp >= 65 && temp <= 90) || (temp >= 97 && temp <= 122))
            {
                return true;
            }
            else
                return false;
        }
        public bool IsBrother(string none, string target, Dictionary<char, int> dic)
        {
            if (none.Length != target.Length)
                return false;
            if (none == target)
                return false;
            Dictionary<char, int> tempDic = new Dictionary<char, int>();
            foreach (var temp in dic)
            {
                tempDic.Add(temp.Key, temp.Value);
            }
            for (int i = 0; i < none.Length; i++)
            {
                if (tempDic.ContainsKey(none[i]) && tempDic[none[i]] != 0)
                {
                    tempDic[none[i]]--;
                }
                else
                    return false;
            }
            return true;
        }


        /// <summary>
        /// 错误返回1，正确返回0
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static int IsMaskValid(string mask)
        {
            string[] temp = mask.Split('.');

            int[] sep = new int[temp.Length];
            int count = 0;
            bool change = true;
            for (int i = 0; i < temp.Length; i++)
            {
                if (int.TryParse(temp[i], out sep[i]))
                {
                    if (sep[i] == 0)
                    {
                        count++;
                    }
                }
                else
                {
                    return 0;
                }
            }

            for (int i = 0; i < sep.Length - count - 1; i++)
            {
                if (sep[i] != 255)
                {
                    return 0;
                }
            }
            int target = sep[sep.Length - count - 1];
            for (int i = 0; i < 7; i++)
            {
                if ((target >> i) % 2 == 1 && (target >> (i + 1)) % 2 == 0)
                    return 0;
            }
            return 1;
        }
        public static int IsIpValid(string ip)
        {


            return 0;
        }

        public static bool IsValid(string str, out int step)
        {
            step = 0;
            if (str.Length == 3 && (str[0] == 'A' || str[0] == 'S' || str[0] == 'D' || str[0] == 'W') && (str[1] >= 49 && str[1] <= 57) && (str[2] >= 48 && str[2] <= 57))
            {
                char[] temp = new char[2] { str[1], str[2] };
                step = Convert.ToInt32(new String(temp));
                return true;
            }
            else if (str.Length == 2 && (str[0] == 'A' || str[0] == 'S' || str[0] == 'D' || str[0] == 'W') && (str[1] >= 49 && str[1] <= 57))
            {
                char[] temp = new char[1] { str[1] };
                step = Convert.ToInt32(new String(temp));
                return true;
            }
            else
                return false;
        }
    }


}




