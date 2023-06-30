using learncode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.ReviewCode
{
    public class Review230601
    {
        public bool CanPartitionKSubsets1(int[] nums,int k)
        {
            int sum = 0;
            foreach(int num in nums)
                sum+= num;
            if (sum % k != 0)
                return false;
            int[] bucket=new int[k];
            int m = sum / k, n = nums.Length;
            for(int i=0;i<k;++i)
                bucket[i]=m;
            Array.Sort(bucket, (a, b) =>
            {
                if (a < b)
                    return 1;
                else
                    return -1;
            });

        }
        public bool CanPartitionKSubsets1BackTrack(int[] nums,int t,int k, int[] bucket)
        {
            if(t==nums.Length)
                return true;
            else
            {
                bool ret = false;
                for(int i=0;i<k;++i)
                {
                    if (i > 0 && bucket[i - 1] == bucket[i])
                        continue;
                    if (nums[t] <= bucket[i])
                    {
                        bucket[i] -= nums[t];
                        bool tmp = CanPartitionKSubsets1BackTrack(nums, t + 1, k, bucket);
                        if (tmp)
                            return true;
                        ret = ret || tmp;
                        bucket[i] += nums[t];
                    }
                }
                return ret;
            }
        }

        public double Rate(double price,double x, double y = 1)
        {
            double r0 = x / y;
            double r1 = 0.7 * x - y;
            double r2 = x - 0.7 * y;
            double r3 = price * r2 / r1;
            //Console.WriteLine("MAX:" + x);
            //Console.WriteLine("MIN:" + y);
            Console.WriteLine("x/y比例："+r0.ToString("0.00"));
            //Console.WriteLine("净得:" + r1);
            //Console.WriteLine("花费" + r2 + " 单价1.2，总花费：" + 1.2 * r2);
            Console.WriteLine("换算单价：" + r3.ToString("0.00"));
            Console.WriteLine("100w积分花费"+(price*100).ToString("0.00")+"\n实际到账积分"+(100*r1/r2).ToString("0.00"));
            return r3;
        }
        public double GetMaxRate(double r0)
        {
            double r = (r0 - 0.7) / (0.7 * r0 - 1);
            double res = 0;
            res = 1.2 * r;
            Console.WriteLine("x比y的比例为:" + r0);
            Console.WriteLine("换算单价：" + res);
            return res;
        }
        public int MinNum(int num)
        {
            //int m = (int)Math.Sqrt(num);
            //int[] v=new int[m];
            //for(int i=0;i < m; i++)
            //    v[i] = (i+1)*(i + 1);
            //int[][] dp = new int[m+1][];
            //for (int i = 0; i <= m; ++i)
            //    dp[i] = new int[num+1];
            //for(int i=1;i<m+1;++i)
            //{
            //    for(int j=1;j<num+1;++j)
            //    {
            //        dp[i][j] = int.MaxValue;
            //        if(j-i*i>=0)

            //    }
            //    Program.Show(dp);
            //}
            //return dp[m][num];
            ////int m = (int)Math.Sqrt(num);
            //int[] v = new int[num + 1];
            //for (int i = 0; i < m; ++i)
            //{
            //    v[i] = (i + 1) * (i + 1);
            //}
            int[] dp = new int[num + 1];
            dp[0] = 0;
            for (int i = 1; i < num + 1; ++i)
                dp[i] = int.MaxValue;
            for (int i = 0; i <= num; ++i)
            {
                for (int j = 1; j * j <= i; ++j)
                {
                    dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
                }
                Program.Show(dp);
            }
            return dp[num];
        }
        public int RemoveDuplicates(int[] nums)
        {
            int n = nums.Length;
            int slow = 0, fast = 0;
            while (fast < n)
            {
                if (nums[slow] != nums[fast])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
                fast++;
            }
            return slow + 1;
        }
        public void MoveZeroes(int[] nums)
        {
            int n = nums.Length;
            int slow = 0, fast = 0;
            while (fast < n)
            {
                if (nums[fast] != 0)
                {
                    nums[slow++] = nums[fast];
                }
                fast++;
            }
            while (slow < n)
            {
                nums[slow] = 0;
                slow++;
            }
        }
        public int[] SortedSquares(int[] nums)
        {
            int n = nums.Length;
            int[] target = new int[n];
            int start = 0, end = n - 1;
            int index = n - 1;
            while (start <= end)
            {
                int i = nums[start] * nums[start];
                int j = nums[end] * nums[end];
                if (i >= j)
                {
                    target[index] = i;
                    start++;
                }
                else
                {
                    target[index] = j;
                    end--;
                }
                index--;
            }
            return target;
        }
        public int MinSubArrayLen(int target, int[] nums)
        {
            int n = nums.Length;
            int l = 0, r = 0;
            int sum = 0, len = n + 1;
            while (l < n && r < n)
            {
                sum += nums[r];
                while (sum >= target)
                {
                    if (r - l + 1 < len)
                        len = r - l + 1;
                    sum -= nums[l];
                    l++;
                }
                r++;
            }
            if (len == n + 1)
                return 0;
            return len;
        }
        public int[][] GenerateMatrix(int n)
        {
            int[][] dir = new int[4][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            int indexX = 0, indexY = 0, dirIndex = 0, count = 1;
            int[][] target = new int[n][];
            for (int i = 0; i < n; i++)
                target[i] = new int[n];
            target[0][0] = 1;
            while (count < n * n)
            {
                int curX = indexX + dir[dirIndex][0];
                int curY = indexY + dir[dirIndex][1];
                if (curX >= n || curX < 0 || curY >= n || curY < 0 || target[curX][curY] != 0)
                {
                    dirIndex = (dirIndex + 1) % 4;
                    continue;
                }
                target[curX][curY] = ++count;
                indexX = curX;
                indexY = curY;
            }
            return target;
        }
        public ListNode ReverseList(ListNode head)
        {
            ListNode temp = new ListNode();
            ListNode cur = head;
            ListNode pre = null;
            while (cur != null)
            {
                temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = cur.next;
            }
            return pre;
        }
        public ListNode swapPairs(ListNode head)
        {
            if (head == null)
                return head;
            ListNode dummy = new ListNode();
            dummy.next = head;
            ListNode cur = dummy;
            ListNode fir;
            ListNode sec;
            ListNode temp;
            while (cur.next != null && cur.next.next != null)
            {
                temp = cur.next.next.next;
                fir = cur.next;
                sec = cur.next.next;
                cur.next = sec;
                sec.next = fir;
                fir.next = temp;
                cur = fir;
            }
            return dummy.next; ;
        }
        public TreeNode invertTree(TreeNode root)
        {
            //if(root==null)
            //    return null;
            //invertTree(root.left);
            //invertTree(root.right);
            //TreeNode temp = root.left;
            //root.left = root.right;
            //root.right= temp;
            //return root;

            if (root == null)
                return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                while (count-- > 0)
                {
                    TreeNode node = queue.Dequeue();
                    TreeNode temp = node.left;
                    node.left = node.right;
                    node.right = temp;
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
            }
            return root;
        }
        public bool isSymmetric1(TreeNode root)
        {
            return isSymmetric1compare(root.left, root.right);
        }

        private bool isSymmetric1compare(TreeNode left, TreeNode right)
        {
            if (left == null && right != null) return false;
            else if (left != null && right == null) return false;
            else if (left == null && right == null) return true;
            else if (left.val != right.val) return false;
            bool l = isSymmetric1compare(left.left, right.right);
            bool r = isSymmetric1compare(left.right, right.left);
            return l && r;
        }
    }
}
