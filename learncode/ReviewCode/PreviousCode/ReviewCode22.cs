using learncode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.ReviewCode.PreviousCode
{
    public class Review22
    {
        static int Size = 1010;
        int[,] DP = new int[Size, Size];
        int[,] DIR = new int[Size, Size];
        public int LCS_Length(string a, string b)
        {
            int M = a.Length;
            int N = b.Length;
            for (int i = 1; i <= M; ++i)
            {
                for (int j = 1; j <= N; ++j)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        DP[i, j] = DP[i - 1, j - 1] + 1;
                        DIR[i, j] = 1;
                    }
                    else if (DP[i - 1, j] >= DP[i, j - 1])
                    {
                        DP[i, j] = DP[i - 1, j];
                        DIR[i, j] = 2;
                    }
                    else
                    {
                        DP[i, j] = DP[i, j - 1];
                        DIR[i, j] = 3;
                    }
                }
            }
            return DP[M, N];
        }
        private void LCS(string a, int i, int j)
        {
            if (i == 0 || j == 0)
                return;
            if (DIR[i, j] == 1)
            {
                LCS(a, i - 1, j - 1);
                Console.WriteLine(a[i - 1]);
            }
            else if (DIR[i, j] == 2)
                LCS(a, i - 1, j);
            else if (DIR[i, j] == 3)
                LCS(a, i, j - 1);
        }
        private void LCS2(string a, string b, int i, int j)
        {
            if (i == 0 || j == 0)
                return;
            if (a[i - 1] == b[j - 1])
            {
                LCS2(a, b, i - 1, j - 1);
                Console.WriteLine(a[i - 1]);
            }
            else if (DP[i - 1, j] > DP[i, j - 1])
                LCS2(a, b, i - 1, j);
            else
                LCS2(a, b, i, j - 1);
        }
        public string ToHex(int num)
        {
            if (num == 0)
                return "0";
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(10, "a");
            dic.Add(11, "b");
            dic.Add(12, "c");
            dic.Add(13, "d");
            dic.Add(14, "e");
            dic.Add(15, "f");
            string str = "";
            if (num > 0)
            {
                while (num != 0)
                {
                    int tmpNum = num % 16;
                    num = num / 16;
                    if (tmpNum >= 10)
                    {
                        str += dic[tmpNum];
                    }
                    else
                    {
                        str += $"{tmpNum}";
                    }
                }
                str = new string(str.Reverse().ToArray());
            }
            else
            {
                if (num == int.MinValue)
                    str = "1000000000000000";
                else
                {
                    num = -num;
                    int[] bina = new int[32];
                    bina[0] = 1;
                    int i = 31;
                    while (num != 0)
                    {
                        int tmpNum = num % 2;
                        bina[i--] = tmpNum;
                        num /= 2;
                    }
                    for (i = 1; i < 32; ++i)
                    {
                        if (bina[i] == 0)
                            bina[i] = 1;
                        else
                            bina[i] = 0;
                    }
                    int add = 1;
                    for (i = 31; i > 0; --i)
                    {
                        if (add == 0)
                            break;
                        int sum = bina[i] + add;
                        if (sum == 2)
                        {
                            add = 1;
                            bina[i] = 0;
                        }
                        else
                        {
                            bina[i] = sum;
                            add = 0;
                        }
                    }
                    for (i = 8; i > 0; --i)
                    {
                        int nm = 0;
                        for (int j = i * 4 - 1; j >= i * 4 - 4; j--)
                        {
                            nm = nm * 2 + bina[j];
                        }
                        if (nm >= 10)
                            str += dic[nm];
                        else
                            str += $"{nm}";
                    }
                }

            }
            return str;
        }
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return 0;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            int sum = 0;
            while (que.Count != 0)
            {
                TreeNode node = que.Dequeue();
                if (node.left != null)
                {
                    if (node.left.left == null && node.left.right == null)
                        sum += node.left.val;
                    que.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    que.Enqueue(node.right);
                }

            }
            return sum;

        }
        public string RemoveKdigits(string num, int k)
        {
            int n = num.Length;
            if (n == k || n == 1)
                return "0";
            StringBuilder target = new StringBuilder(num);
            string minNum = RemoveFrontZero(num.Remove(0, 1));
            for (int i = 0; i < k; ++i)
            {
                string temp = num;
                int index = 0;
                for (int j = 0; j < temp.Length; ++j)
                {
                    string str = RemoveFrontZero(temp.Remove(j, 1));
                    if (minNum == "0" || str == "0")
                        return "0";
                    if (RemoveKdigitsBig(str, minNum))
                    {
                        minNum = str;
                        index = j;
                    }
                }
                num = num.Remove(index, 1);
            }
            return minNum;
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
        public bool RemoveKdigitsBig(string num1, string num2)
        {
            int m = num1.Length;
            int n = num2.Length;
            if (m < n)
                return true;
            else if (m > n)
                return false;
            else
            {
                for (int i = 0; i < m; ++i)
                {
                    int n1 = Convert.ToInt32(num1[i]);
                    int n2 = Convert.ToInt32(num2[i]);
                    if (n1 < n2)
                        return true;
                    else if (n1 > n2)
                        return false;
                }
            }
            return true;
        }


        public int NumSquares(int n)
        {
            int[] nums = new int[n + 1];
            nums[0] = 0;
            for (int i = 1; i <= n; ++i)
            {
                int min = int.MaxValue - 1;
                for (int j = 1; j * j <= i; ++j)
                {
                    min = Math.Min(min, nums[i - j * j]);
                }
                nums[i] = min + 1;
            }
            return nums[n];
        }
        public int HIndex(int[] citations)
        {
            int n = citations.Length, tot = 0;
            int[] counter = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                if (citations[i] >= n)
                {
                    counter[n]++;
                }
                else
                {
                    counter[citations[i]]++;
                }
            }
            for (int i = n; i >= 0; i--)
            {
                tot += counter[i];
                if (tot >= i)
                {
                    return i;
                }
            }
            return 0;
        }
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int sum = 0;
            int total = n * (n + 1) / 2;
            for (int i = 0; i < n; ++i)
            {
                sum += nums[i];
            }
            return total - sum;
        }
        public int NthUglyNumber(int n)
        {
            IList<long> list = new List<long>();
            HashSet<long> hash = new HashSet<long>();
            int count = 0;
            long target = 0;
            int cre = 1;
            list.Add(cre);
            hash.Add(cre);
            while (count < n)
            {
                //NthUglyNumberDown(list, list.Count, 0);
                target = list[0];
                list[0] = list[list.Count - 1];
                count++;
                list.RemoveAt(list.Count - 1);
                NthUglyNumberDown(list, list.Count, 0);
                if (2 * target < int.MaxValue && hash.Add(2 * target))
                {
                    list.Add(2 * target);
                    NthUglyNumberUP(list, list.Count, list.Count - 1);
                }
                if (3 * target < int.MaxValue && hash.Add(3 * target))
                {
                    list.Add(3 * target);
                    NthUglyNumberUP(list, list.Count, list.Count - 1);
                }
                if (5 * target < int.MaxValue && hash.Add(5 * target))
                {
                    list.Add(5 * target);
                    NthUglyNumberUP(list, list.Count, list.Count - 1);
                }
            }
            return (int)target;
        }
        public void NthUglyNumberDown(IList<long> list, int n, int cur)
        {
            int child = 2 * cur + 1;
            while (child < n)
            {
                if (child + 1 < n && list[child + 1] < list[child])
                    ++child;
                if (list[child] < list[cur])
                {
                    long temp = list[child];
                    list[child] = list[cur];
                    list[cur] = temp;
                    cur = child;
                    child = 2 * cur + 1;
                }
                else
                    break;
            }
        }
        public void NthUglyNumberUP(IList<long> list, int n, int cur)
        {
            int parent = (cur - 1) / 2;
            while (cur > 0)
            {
                if (list[parent] > list[cur])
                {
                    long temp = list[parent];
                    list[parent] = list[cur];
                    list[cur] = temp;
                    cur = parent;
                    parent = (cur - 1) / 2;
                }
                else
                    break;
            }
        }
        public void ShellSort(int[] nums, int n)
        {
            int gap = n;
            while (gap > 1)
            {
                gap = gap / 2;
                for (int i = 0; i < n - gap; ++i)
                {
                    int end = i;
                    int item = nums[end + gap];
                    while (end >= 0)
                    {
                        if (item < nums[end])
                        {
                            nums[end + gap] = nums[end];
                            end -= gap;
                        }
                        else
                            break;
                    }
                }
            }
        }
        public void QuickSort(int[] nums, int start, int end)
        {
            if (start == end)
                return;
            int num = nums[start];
            int i = start;
            int j = end;
            while (i < j)
            {
                while (i < j && num <= nums[j])
                    j--;
                while (i < j && num >= nums[i])
                    i++;
                if (i < j)
                {
                    int temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }
            int temp1 = nums[start];
            nums[start] = nums[i];
            nums[i] = temp1;
            QuickSort(nums, start, i - 1);
            QuickSort(nums, i + 1, end);
        }
        public void MergeSort(int[] nums, int start, int end)
        {
            if (start == end)
                return;
            int mid = start + (end - start) / 2;
            MergeSort(nums, start, mid);
            MergeSort(nums, mid + 1, end);
            MergeArray(nums, start, mid, end);
        }
        public void MergeArray(int[] nums, int start, int mid, int end)
        {
            int[] temp = new int[end - start + 1];
            int i = start;
            int j = mid + 1;
            int k = 0;
            while (i <= mid && j <= end)
            {
                if (nums[i] > nums[j])
                    temp[k++] = nums[j++];
                else
                    temp[k++] = nums[i++];
            }
            while (i <= mid)
                temp[k++] = nums[i++];
            while (j <= end)
                temp[k++] = nums[j++];
            for (i = 0; i < temp.Length; i++)
            {
                nums[start + i] = temp[i];
            }

        }
        public ListNode detectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {// 有环
                    ListNode index1 = fast;
                    ListNode index2 = head;
                    // 两个指针，从头结点和相遇结点，各走一步，直到相遇，相遇点即为环入口
                    while (index1 != index2)
                    {
                        index1 = index1.next;
                        index2 = index2.next;
                    }
                    return index1;
                }
            }
            return null;
        }

        public ListNode findpoint(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    ListNode index1 = fast;
                    ListNode index2 = head;
                    while (index1 != index2)
                    {
                        index1 = index1.next;
                        index2 = index2.next;
                    }
                    return index1;
                }
            }
            return null;
        }


        public IList<int> PreorderTraversal(TreeNode root)
        {
            return null;
            ////迭代中序遍历
            //IList<int> list = new List<int>();
            //if (root == null)
            //    return list;
            //Stack<TreeNode> stack = new Stack<TreeNode>();
            //TreeNode node = root;
            //while (node != null||stack.Count!=0)
            //{
            //    if(node!=null)
            //    {
            //        stack.Push(node);
            //        node = node.left;
            //    }
            //    else
            //    {
            //        node = stack.Pop();
            //        list.Add(node.val);
            //        node = node.right;
            //    }
            //}
            //return list;


            //迭代后序遍历
            IList<int> list = new List<int>();
            if (root == null)
                return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                list.Add(node.val);
                if (node.left != null) stack.Push(node.left);
                if (node.right != null) stack.Push(node.right);
            }
            int last = list.Count - 1;
            for (int i = 0; i < list.Count; i++, last--)
            {
                if (i >= last)
                    break;
                int temp = list[i];
                list[i] = list[last];
                list[last] = temp;
            }


            ////迭代前序遍历
            //IList<int> list = new List<int>();
            //if (root == null)
            //{
            //    return list;
            //}
            //Stack<TreeNode> stack = new Stack<TreeNode>();
            //stack.Push(root);
            //while (stack.Count != 0)
            //{
            //    TreeNode node = stack.Pop();
            //    list.Add(node.val);
            //    if (node.right != null) stack.Push(node.right);
            //    if (node.left != null) stack.Push(node.left);
            //}
            //return list;



        }
        public void PreorderTraversalRecursion(TreeNode root, IList<int> list)
        {
            if (root == null)
                return;
            list.Add(root.val);
            PreorderTraversalRecursion(root.left, list);
            PreorderTraversalRecursion(root.right, list);
        }


        public ListNode DetectCycle(ListNode head)
        {
            int index = -1;
            ListNode temp = head;
            Dictionary<ListNode, int> dic = new Dictionary<ListNode, int>();
            int num = 0;
            while (temp != null)
            {
                if (dic.ContainsKey(temp))
                {
                    index = dic[temp];
                    break;
                }
                else
                {
                    dic.Add(temp, num);
                    num++;
                    temp = temp.next;
                }
            }
            return temp;
        }

        public ListNode GetListNode(int[] nums)
        {
            ListNode head = new ListNode();
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
                    temp.next = new ListNode();
                    temp = temp.next;
                }
            }
            return head;
        }
        public TreeNode GetTreeNode()
        {
            return null;
        }

        public void FrontRearch(TreeNode root, List<int> list)
        {
            if (root == null)
                return;
            list.Add(root.val);
            FrontRearch(root.left, list);
            FrontRearch(root.right, list);
        }

    }
}
