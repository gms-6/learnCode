using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.ReviewCode
{
    public class test
    {

        
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null)
                return list;
            Stack<IList<int>> list1 = new Stack<IList<int>>();

            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            while(que.Count!=0)
            {
                int len = que.Count;
                IList<int> temp = new List<int>();
                while(len-->0)
                {
                    TreeNode node = que.Dequeue();
                    temp.Add(node.val);
                    if (node.left != null)
                        que.Enqueue(node.left) ;
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
        public void levelOrderDFS(TreeNode node,int deep,IList<IList<int>> list)
        {
            if (node == null)
                return;
            deep++;
            if(list.Count<deep)
            {
                IList<int> item = new List<int>();
                list.Add(item);
            }
            list[deep - 1].Add(node.val);
            levelOrderDFS(node.left,deep,list);
            levelOrderDFS(node.right,deep,list);
        }
        public void levelOrderBFS(TreeNode node,IList<IList<int>> list)
        {
            if (node == null)
                return;
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(node);
            while(que.Count!=0)
            {
                IList<int> itemList = new List<int>();
                int len = que.Count;
                while(len>0)
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
                if(node.right!=null)
                {
                    stack.Push(node.right);
                }
            }
            int last = list.Count - 1;
            for(int i=0;i<last;++i,--last)
            {
                int temp = list[i];
                list[i] = list[last];
                list[last] = temp;
            }
            return list;
        }
    }
}
