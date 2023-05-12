using learncode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.ReviewCode
{
    public class Revire230505
    {
        static int SEG_COUNT = 4;
        List<string> ans = new List<string>();
        int[] segments = new int[SEG_COUNT];
        IList<int> list = new List<int>();
        public int CountBattleships(char[][] board)
        {
            int m = board.Length;
            int n = board[0].Length;
            bool[][] bod = new bool[m][];
            for (int i = 0; i < m; ++i)
                bod[i] = new bool[n];
            int[][] dir= new int[4][] { new int[] {1,0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
            for(int i=0;i<m;++i)
            {
                for(int j=0;j<n;++j)
                {
                    if (!bod[i][j] && board[i][j]=='X')
                    {
                        int index = -1;
                        bod[i][j] = true;
                        for(int k=0;k<4;++k)
                        {
                            if (i + dir[k][0] >= m || j + dir[k][1] >= n)
                                continue;
                            if (board[i + dir[k][0]][j + dir[k][1]]=='X')
                            {
                                index = k;
                                break;
                            }
                        }
                        int left= dir[index][0], right=j;
                        while (tmpi + dir[index][0] < m && tmpj + dir[index][1]<n)
                        {
                            bod[tmpi + dir[index][0]][tmpj + dir[index][1]] = true;
                            
                        }
                        
                    }
                }
            }
        }
        /// <summary>
        /// 未提交
        /// </summary>
        /// <param name="heights"></param>
        /// <returns></returns>
        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            int m = heights.Length;
            int n = heights[0].Length;
            IList<IList<int>> list=new List<IList<int>>();
            for(int i=0;i<m;++i)
            {
                int j = 0;
                bool res = true;
                for(j=0;j<n;++j)
                {
                    res = true;
                    res &= PacificAtlanticLeftDFS(heights,i,j);
                    res &= PacificAtlanticRightDFS(heights,i,j);
                    if (res)
                        list.Add(new List<int>() { i, j });
                }
            }
            return list;
        }
        private bool PacificAtlanticRightDFS(int[][] heights, int fir, int sec)
        {
            if (fir == heights.Length - 1 || sec == heights[0].Length - 1)
                return true;
            int cur = heights[fir][sec];
            int curDown = heights[fir + 1][sec];
            int curRight = heights[fir][sec + 1];
            bool res = false;
            if (cur >= curDown)
                res |= PacificAtlanticRightDFS(heights, fir + 1, sec);
            if (cur >= curRight)
                res |= PacificAtlanticRightDFS(heights, fir, sec + 1);
            return res;
        }
        private bool PacificAtlanticLeftDFS(int[][] heights, int fir, int sec)
        {
            if (fir == 0 || sec == 0)
                return true;
            int cur = heights[fir][sec];
            int curUp = heights[fir - 1][sec];
            int curLeft = heights[fir][sec - 1];
            bool res = false;
            if (cur >= curUp)
                res |= PacificAtlanticLeftDFS(heights, fir - 1, sec);
            if (cur >= curLeft)
                res |= PacificAtlanticLeftDFS(heights, fir, sec - 1);
            return res;
        }
        public bool CanPartition(int[] nums)
        {
            int n = nums.Length;
            if (n == 1)
                return false;
            int sum = 0, maxNum = 0;
            foreach (int num in nums)
            {
                sum += num;
                maxNum = Math.Max(num, maxNum);
            }
            if (sum % 2 != 0)
                return false;
            int target = sum / 2;
            if (maxNum > target)
                return false;
            bool[][] dp = new bool[n][];
            for (int i = 0; i < n; ++i)
            {
                dp[i] = new bool[target + 1];
                dp[i][0] = true;
            }
            dp[0][nums[0]] = true;
            for (int i = 1; i < n; ++i)
            {
                int num = nums[i];
                for (int j = 1; j <= target; ++j)
                {
                    if (j >= num)
                        dp[i][j] = dp[i - 1][j] | dp[i - 1][j - num];
                    else
                        dp[i][j] = dp[i - 1][j];
                }
            }
            return dp[n - 1][target];
        }
        public int ThirdMax(int[] nums)
        {
            int n = nums.Length;
            long max1 = long.MinValue, max2 = long.MinValue, max3 = long.MinValue;
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] > max1)
                {
                    max3 = max2;
                    max2 = max1;
                    max1 = nums[i];
                }
                else if (nums[i] > max2 && nums[i] < max1)
                {
                    max3 = max2;
                    max2 = nums[i];
                }
                else if (nums[i] > max3 && nums[i] < max2)
                    max3 = nums[i];
            }
            if (max3 == long.MinValue)
                return (int)max1;
            return (int)max3;
        }
        public int NumberOfArithmeticSlices(int[] nums)
        {
            int n = nums.Length;
            if (n < 3)
                return 0;
            int sum = 0;
            int count = 0, dif = 0;
            for (int i = 1; i < n; ++i)
            {
                if (count == 0)
                {
                    dif = nums[i] - nums[i - 1];
                    count = 2;
                }
                else
                {
                    if (dif == nums[i] - nums[i - 1])
                        count++;
                    else
                    {
                        if (count >= 3)
                            sum += (count * count - 3 * count + 2) / 2;
                        count = 2;
                        dif = nums[i] - nums[i - 1];

                    }
                }
            }
            if (count >= 3)
                sum += (count * count - 3 * count + 2) / 2;
            return sum;
        }
        public int LongestSubstring(string s, int k)
        {
            int ans = 0;
            int n = s.Length;
            char[] cs = s.ToCharArray();
            int[] cnt = new int[26];
            for (int p = 1; p <= 26; p++)
            {
                for (int i = 0, j = 0, tot = 0, sum = 0; i < n; ++i)
                {
                    int u = cs[i] - 'a';
                    cnt[i]++;
                    if (cnt[u] == 1) tot++;
                    if (cnt[u] == k) sum++;
                    while (tot > p)
                    {
                        int t = cs[j++] - 'a';
                        cnt[t]--;
                        if (cnt[t] == 0) tot--;
                        if (cnt[t] == k - 1) sum--;
                    }
                    if (tot == sum) ans = Math.Max(ans, i - j + 1);
                }
            }
            return ans;
        }
        Random random = new Random(); public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            return null;

            //IList<IList<int>> list = new List<IList<int>>();
            //int m = nums1.Length;
            //int n = nums2.Length;
            //int[][] num = new int[m * n][];
            //int index = 0;
            //bool flag = false;
            //if (k >= m * n)
            //{
            //    flag = true;
            //    k = m * n;
            //}
            //for (int i = 0; i < m; ++i)
            //{
            //    for (int j = 0; j < n; ++j)
            //    {
            //        num[index++] = new int[] { nums1[i],nums2[j]};
            //    }
            //}
            //Array.Sort(num, (a, b) => {
            //    return a[0] + a[1] - b[0] - b[1];
            //});
            //int sum = -1;

            //for(int i=0;i< k; ++i)
            //{
            //    list.Add(new List<int>() {num[i][0],num[i][1] });

            //}
            //return list;

        }
        public int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, (a, b) =>
            {
                if (a[0] != b[0])
                {
                    return a[0] - b[0];
                }
                else
                    return b[1] - a[1];
            });
            int n = people.Length;
            int[][] ans = new int[n][];
            foreach (var item in people)
            {
                int spaces = item[1] + 1;
                for (int i = 0; i < n; ++i)
                {
                    if (ans[i] == null)
                        --spaces;
                    if (spaces == 0)
                    {
                        ans[i] = item;
                        break;
                    }
                }
            }
            return ans;

            //int n=people.Length;
            //List<int[]> list=new List<int[]>();
            //int i = ReconstructQueueSort(people);
            //for(;i<n-1;++i)
            //{
            //    int j = i;
            //    for(;j<n;j++)
            //    {
            //        int count = 0;
            //        for(int k=0;k<i;++k)
            //        {
            //            if (people[j][0] >= people[k][0])
            //                count++;
            //        }
            //        if (count == people[j][1])
            //            break;
            //    }
            //    ReconstructQueueSortswap(people,i,j);
            //}
            //return people;

        }
        private int ReconstructQueueSort(int[][] people)
        {
            int n = people.Length;
            int i = 0, j = n - 1;
            int index = 0;
            while (i < j)
            {
                while (i < j && people[i][1] == 0)
                    i++;
                while (i < j && people[j][1] != 0)
                    j--;
                if (i == j)
                    break;
                ReconstructQueueSortswap(people, i, j);
            }
            index = i;
            ReconstructQueueSortQuick(people, 0, i - 1);
            return index;
        }
        private void ReconstructQueueSortQuick(int[][] nums, int left, int right)
        {
            if (left >= right)
                return;
            int n = nums.Length;
            int i = left, j = right;
            int index = nums[i][0];
            while (i < j)
            {
                while (i < j && nums[j][0] >= index)
                    j--;
                nums[i][0] = nums[j][0];
                while (i < j && nums[i][0] <= index)
                    i++;
                nums[j][0] = nums[i][0];
            }
            nums[i][0] = index;
            ReconstructQueueSortQuick(nums, left, i - 1);
            ReconstructQueueSortQuick(nums, i + 1, right);
        }
        private void ReconstructQueueSortswap(int[][] people, int i, int j)
        {
            int temp = people[i][0];
            people[i][0] = people[j][0];
            people[j][0] = temp;
            temp = people[i][1];
            people[i][1] = people[j][1];
            people[j][1] = temp;
        }
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                if (dic.ContainsKey(nums[i]))
                    dic[nums[i]] += 1;
                else
                    dic.Add(nums[i], 1);
            }
            int m = dic.Count;
            int[,] tmp = new int[2, m];
            int index = 0;
            foreach (var num in dic)
            {
                tmp[0, index] = num.Key;
                tmp[1, index] = num.Value;
                index++;
            }
            TopKFrequentQuickSort(tmp, 0, m - 1);
            int[] target = new int[k];
            for (int i = 0; i < k; ++i)
            {
                target[i] = tmp[0, i];
            }
            return target;

        }
        private void TopKFrequentQuickSort(int[,] nums, int left, int right)
        {
            if (left >= right)
                return;
            int i = left, j = right;
            int index = nums[1, left];
            int index1 = nums[0, left];
            while (i < j)
            {
                while (i < j && nums[1, j] <= index)
                    j--;
                nums[1, i] = nums[1, j];
                nums[0, i] = nums[0, j];
                while (i < j && nums[1, i] >= index)
                    i++;
                nums[1, j] = nums[1, i];
                nums[0, j] = nums[0, i];
            }
            nums[0, i] = index1;
            nums[1, i] = index;
            TopKFrequentQuickSort(nums, left, i - 1);
            TopKFrequentQuickSort(nums, i + 1, right);
        }
        public bool IsAdditiveNumber(string num)
        {
            int n = num.Length;
            for (int secondStart = 1; secondStart < n - 1; ++secondStart)
            {
                if (num[0] == '0' && secondStart != 1)
                    break;
                for (int secondEnd = secondStart; secondEnd < n - 1; ++secondEnd)
                {
                    if (num[secondStart] == '0' && secondStart != secondEnd)
                        break;
                    if (Valid(secondStart, secondEnd, num))
                        return true;
                }
            }
            return false;
        }
        private bool Valid(int secondStart, int secondEnd, string num)
        {
            int n = num.Length;
            int firstStart = 0, firstEnd = secondStart - 1;
            while (secondEnd <= n - 1)
            {
                string third = StringAdd(num, firstStart, firstEnd, secondStart, secondEnd);
                int thirdStart = secondEnd + 1;
                int thirdEnd = secondEnd + third.Length;
                if (thirdEnd >= n || !num.Substring(thirdStart, thirdEnd - thirdStart + 1).Equals(third))
                {
                    break;
                }
                if (thirdEnd == n - 1)
                    return true;
                firstStart = secondStart;
                firstEnd = secondEnd;
                secondStart = thirdStart;
                secondEnd = thirdEnd;

            }
            return false;
        }
        private string StringAdd(string s, int firstStart, int firstEnd, int secondStart, int secondEnd)
        {
            StringBuilder third = new StringBuilder();
            int carry = 0, cur = 0;
            while (firstEnd >= firstStart || secondEnd >= secondStart || carry != 0)
            {
                cur = carry;
                if (firstEnd >= firstStart)
                {
                    cur += s[firstEnd] - '0';
                    --secondEnd;
                }
                if (secondEnd >= secondStart)
                {
                    cur += s[secondEnd] - '0';
                    --secondEnd;
                }
                carry = cur / 10;
                cur %= 10;
                third.Append((char)(cur + '0'));
            }
            char[] arr = third.ToString().ToCharArray();
            Array.Reverse(arr);
            third.Length = 0;
            foreach (char c in arr)
                third.Append(c);
            return third.ToString();
        }
        public int FindKthLargest(int[] nums, int k)
        {
            int len = nums.Length;
            int target = len - k;
            int left = 0;
            int right = len - 1;
            while (true)
            {
                int pivotIndex = partition(nums, left, right);
                if (pivotIndex == target)
                    return nums[pivotIndex];
                else if (pivotIndex < target)
                    left = pivotIndex + 1;
                else
                    right = pivotIndex - 1;
            }
        }
        private int partition(int[] nums, int left, int right)
        {
            int randomIndex = left + random.Next(right - left + 1);
            partitionSwap(nums, left, randomIndex);

            int pivot = nums[left];
            int le = left + 1;
            int ge = right;

            while (true)
            {
                while (le <= ge && nums[le] < pivot)
                    le++;
                while (le <= ge && nums[ge] > pivot)
                    ge--;
                if (le >= ge)
                    break;
                partitionSwap(nums, le, ge);
                le++;
                ge--;
            }
            partitionSwap(nums, left, ge);
            return ge;
        }
        private void partitionSwap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
        public int MinOperations(int[] nums)
        {
            int pre = nums[0] - 1, res = 0;
            foreach (int num in nums)
            {
                pre = Math.Max(pre + 1, num);
                res += pre - num;
            }
            return res;
        }
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            Dictionary<char, char> dics = new Dictionary<char, char>();
            Dictionary<char, char> dict = new Dictionary<char, char>();
            int n = s.Length;
            for (int i = 0; i < n; ++i)
            {
                bool a = dics.ContainsKey(s[i]);
                bool b = dict.ContainsKey(t[i]);
                if ((a & !b) || (!a & b))
                    return false;
                else if (a & b)
                {
                    if (dics[s[i]] != t[i] || dict[t[i]] != s[i])
                        return false;
                }
                else if (!a & !b)
                {
                    dics.Add(s[i], t[i]);
                    dict.Add(t[i], s[i]);

                }
            }
            return true;
        }
        public string StringTrim(string s)
        {
            int n = s.Length;
            int i = 0;
            bool flag = false;
            int start = 0;
            int end = n - 1;
            while (!flag)
            {
                if (s[i] == ' ')
                {
                    start++;
                }
                else
                {
                    flag = true;
                }
                i++;
            }
            flag = false;
            i = n - 1;
            while (!flag)
            {
                if (s[i] == ' ')
                    end--;
                else
                    flag = true;
                i--;
            }
            return s.Substring(start, end - start + 1);
        }
        public ListNode SortList(ListNode head)
        {
            if (head == null)
                return head;
            int length = 0;
            ListNode node = head;
            while (node != null)
            {
                length++;
                node = node.next;
            }
            ListNode dummyHead = new ListNode(0, head);
            for (int subLength = 1; subLength < length; subLength <<= 1)
            {
                ListNode prev = dummyHead, curr = dummyHead.next;
                while (curr != null)
                {
                    ListNode head1 = curr;
                    for (int i = 1; i < subLength && curr.next != null; ++i)
                    {
                        curr = curr.next;
                    }
                    ListNode head2 = curr.next;
                    curr.next = null;
                    curr = head2;
                    for (int i = 1; i < subLength && curr != null && curr.next != null; i++)
                    {
                        curr = curr.next;
                    }
                    ListNode next = null;
                    if (curr != null)
                    {
                        next = curr.next;
                        curr.next = null;
                    }
                    ListNode merged = Merge(head1, head2);
                    prev.next = merged;
                    while (prev.next != null)
                        prev = prev.next;
                    curr = next;
                }
            }
            return dummyHead.next;
        }
        public ListNode Merge(ListNode head1, ListNode head2)
        {
            ListNode dummyHead = new ListNode();
            ListNode temp = dummyHead, temp1 = head1, temp2 = head2;
            while (temp1 != null && temp2 != null)
            {
                if (temp1.val <= temp2.val)
                {
                    temp.next = temp1;
                    temp1 = temp1.next;
                }
                else
                {
                    temp.next = temp2;
                    temp2 = temp2.next;
                }
                temp = temp.next;
            }
            if (temp1 != null)
            {
                temp.next = temp1;
            }
            else if (temp2 != null)
                temp.next = temp2;
            return dummyHead.next;
        }
        public void InsertionSort(int[] nums)
        {
            int n = nums.Length;
            for (int i = 1; i < n; ++i)
            {
                int index = nums[i];
                int j = i;
                while (j >= 1 && index <= nums[j - 1])
                {
                    nums[j] = nums[j - 1];
                    j--;
                }
                nums[j] = index;
            }
        }
        public ListNode SortList123(ListNode head)
        {
            IList<int> list = new List<int>();
            ListNode tmp = new ListNode();
            tmp = head;
            while (tmp != null)
            {
                list.Add(tmp.val);
                tmp = tmp.next;
            }
            QuickSort(list, 0, list.Count - 1);
            tmp = head;
            int i = 0, n = list.Count;
            while (i < n)
            {
                tmp.val = list[i];
                tmp = tmp.next;
            }
            return head;

        }
        public void QuickSort(IList<int> nums, int left, int right)
        {
            if (left >= right)
                return;
            int n = nums.Count;
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
        public int WiggleMaxLength(int[] nums)
        {
            int down = 1, up = 1;
            for (int i = 1; i < nums.Length; ++i)
            {
                if (nums[i] > nums[i - 1])
                    up = down + 1;
                else if (nums[i] < nums[i - 1])
                    down = up + 1;
            }
            return nums.Length == 0 ? 0 : Math.Max(down, up);
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return list;
            InorderTraversalDFS(root);
            return list;
        }
        private void InorderTraversalDFS(TreeNode root)
        {
            if (root == null)
                return;
            InorderTraversalDFS(root.left);
            list.Add(root.val);
            InorderTraversalDFS(root.right);
        }
        public int FindLength(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int m = nums2.Length;
            int ret = 0;
            for (int i = 0; i < n; ++i)
            {
                int len = Math.Min(m, n - i);
                int maxLen = maxLength(nums1, nums2, i, 0, len);
                ret = Math.Max(ret, maxLen);
            }
            for (int i = 0; i < m; ++i)
            {
                int len = Math.Min(n, m - i);
                int maxLen = maxLength(nums1, nums2, 0, i, len);
                ret = Math.Max(ret, maxLen);
            }
            return ret;
        }
        private int maxLength(int[] A, int[] B, int addA, int addB, int len)
        {
            int ret = 0, k = 0;
            for (int i = 0; i < len; ++i)
            {
                if (A[addA + i] == B[addB + i])
                    k++;
                else
                    k = 0;
                ret = Math.Max(ret, k);
            }
            return ret;
        }
        public IList<string> RestoreIpAddresses(string s)
        {
            segments = new int[SEG_COUNT];
            RestoreIpAddressesDFS(s, 0, 0);
            return ans;
        }
        public void RestoreIpAddressesDFS(string s, int segId, int segStart)
        {
            if (segId == SEG_COUNT)
            {
                if (segStart == s.Length)
                {
                    StringBuilder ipAddr = new StringBuilder();
                    for (int i = 0; i < SEG_COUNT; ++i)
                    {
                        ipAddr.Append(segments[i]);
                        if (i != SEG_COUNT - 1)
                        {
                            ipAddr.Append('.');
                        }
                    }
                    ans.Add(ipAddr.ToString());
                }
                return;
            }
            if (segStart == s.Length)
                return;
            if (s[segStart] == '0')
            {
                segments[segId] = 0;
                RestoreIpAddressesDFS(s, segId + 1, segStart + 1);
            }
            int addr = 0;
            for (int segEnd = segStart; segEnd < s.Length; ++segEnd)
            {
                addr = addr * 10 + (s[segEnd] - '0');
                if (addr > 0 && addr <= 0xFF)
                {
                    segments[segId] = addr;
                    RestoreIpAddressesDFS(s, segId + 1, segEnd + 1);
                }
                else
                    break;
            }
        }
        public int[][] Merge(int[][] intervals)
        {
            int m = intervals.Length;
            if (m == 1)
                return intervals;
            Array.Sort(intervals, (a, b) =>
            {
                if (a[0] != b[0])
                {
                    return a[0] - b[0];
                }
                else
                {
                    return b[1] - a[1];
                }
            });
            IList<int[]> mergeList = new List<int[]>();
            mergeList.Add(intervals[0]);
            for (int i = 1; i < m; ++i)
            {
                int[] curr = intervals[i];
                int[] prev = mergeList[mergeList.Count - 1];
                if (curr[0] == prev[0])
                    continue;
                if (curr[0] <= prev[1])
                {
                    prev[1] = Math.Max(prev[1], curr[1]);
                }
                else
                {
                    mergeList.Add(curr);
                }
            }
            return mergeList.ToArray();
        }
    }
}
