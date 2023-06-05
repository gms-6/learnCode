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
