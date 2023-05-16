using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.ReviewCode
{
    public class test
    {
        public bool Find132Pattern(int[] nums)
        {
            int n=nums.Length;
            if(n<3)
                return false;
            Array.Sort(nums);

        }
        public int FindContentChildren(int[] g, int[] s)
        {
            int m = g.Length;
            int n = s.Length;
            Array.Sort(g);
            Array.Sort(s);
            int GIndex = 0, SIndex = 0;
            int count = 0;
            while(GIndex<m&&SIndex<n)
            {
                if (s[SIndex] >= g[GIndex])
                {
                    count++;
                    SIndex++;
                    GIndex++;
                }
                else
                {
                    SIndex++;
                }
            }
            return count;
        }
        /// <summary>
        /// AAABBABABAABBB
        /// 使字符串严格递增的最小修改次数，收藏
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int minModeTimes(string str)
        {
            int n = str.Length;
            int FirB = str.IndexOf('B');
            if (FirB < 0)
                return 0;
            int LastA = str.LastIndexOf('A');
            if (LastA < FirB)
                return 0;
            int r = 1;
            for(int i=FirB+1;i<LastA;i++)
            {
                if (str[i] == 'A')
                    r++;
            }
            int l = 0, min = r;
            for(int i=FirB;i<=LastA;++i)
            {
                if (str[i] == 'B')
                    l++;
                else
                    r--;
                min = Math.Min(min,l+r);
            }
            return min;
        }
        public int FourSumCount(int[] nums1,int nums2, int[] nums3, int[] nums4)
        {
            return 0;
        }
        public int minMoves(int[] nums)
        {
            int n=nums.Length;
            int sum = 0;
            int min = int.MaxValue;
            for(int i=0;i<n;++i)
            {
                if (nums[i] < min)
                    min = nums[i];
            }
            for(int i=0;i<n;++i)
            {
                sum+= nums[i]-min;
            }
            return sum;
        }
        public int FindMinArrowShots(int[][] points)
        {
            int n = points.Length;
            Array.Sort(points, (a, b) =>
            {
                if (a[0] != b[0])
                    return a[0] > b[0] ? 1 : -1;
                else
                    return a[1] > b[1] ? 1 : -1; ;
            });
            int count = 1, min = points[0][1], pre = points[0][0];
            for (int i = 1; i < n; ++i)
            {
                int num1 = points[i][0];
                int num2 = points[i][1];
                if (num1 == pre)
                    continue;
                if (num1 <= min)
                {
                    if (num2 < min)
                    {
                        min = num2;
                        pre = num1;
                    }
                    continue;
                }
                count++;
                min = num2;
                pre = num1;
            }
            return count;
        }
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null)
                return list;
            Stack<IList<int>> list1 = new Stack<IList<int>>();

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            while (que.Count != 0)
            {
                int len = que.Count;
                IList<int> temp = new List<int>();
                while (len-- > 0)
                {
                    TreeNode node = que.Dequeue();
                    temp.Add(node.val);
                    if (node.left != null)
                        que.Enqueue(node.left);
                    if (node.right != null)
                        que.Enqueue(node.right);
                }
                list1.Push(temp);
            }
            while (list1.Count != 0)
                list.Add(list1.Pop());
            return list;
        }


        public IList<int> levelOrder(TreeNode root)
        {
            IList<int> list = new List<int>();

            return list;
        }
        public void levelOrderDFS(TreeNode node, int deep, IList<IList<int>> list)
        {
            if (node == null)
                return;
            deep++;
            if (list.Count < deep)
            {
                IList<int> item = new List<int>();
                list.Add(item);
            }
            list[deep - 1].Add(node.val);
            levelOrderDFS(node.left, deep, list);
            levelOrderDFS(node.right, deep, list);
        }
        public void levelOrderBFS(TreeNode node, IList<IList<int>> list)
        {
            if (node == null)
                return;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(node);
            while (que.Count != 0)
            {
                IList<int> itemList = new List<int>();
                int len = que.Count;
                while (len > 0)
                {
                    TreeNode tmpNode = que.Dequeue();
                    itemList.Add(tmpNode.val);
                    if (tmpNode.left != null) que.Enqueue(tmpNode.left);
                    if (tmpNode.right != null) que.Enqueue(tmpNode.right);
                }
                list.Add(itemList);
            }
        }


        public IList<int> preorder(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null)
                return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode tree = stack.Pop();
                list.Add(tree.val);
                if (tree.right != null)
                {
                    stack.Push(tree.right);
                }
                if (tree.left != null)
                {
                    stack.Push(tree.left);
                }
            }
            return list;
        }
        public IList<int> Inorder(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null)
                return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while (cur != null || stack.Count != 0)
            {
                if (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                else
                {
                    cur = stack.Pop();
                    list.Add(cur.val);
                    cur = cur.right;
                }
            }
            return list;
        }
        public IList<int> PostOrder(TreeNode root)
        {
            IList<int> list = new List<int>();
            if (root == null)
                return list;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode node = stack.Pop();
                list.Add(node.val);
                if (node.left != null)
                    stack.Push(node.left);
                if (node.right != null)
                {
                    stack.Push(node.right);
                }
            }
            int last = list.Count - 1;
            for (int i = 0; i < last; ++i, --last)
            {
                int temp = list[i];
                list[i] = list[last];
                list[last] = temp;
            }
            return list;
        }
    }
}
