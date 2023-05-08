using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode() { }
        public TreeNode(int val)
        {
            this.val = val;
        }
        public TreeNode(int val,TreeNode left=null,TreeNode right=null)
        {
            this.val = val;
            this.right = right;
            this.left = left;
        }
        public static void Copy(TreeNode treeNode,TreeNode target)
        {
            //TreeNode temp = new TreeNode();
            if (treeNode == null)
                return;
            target.val = treeNode.val;
            if (treeNode.left != null)
            {
                target.left = new TreeNode();
                Copy(treeNode.left,target.left);
            }
            if(treeNode.right!=null)
            {
                target.right = new TreeNode();
                Copy(treeNode.right, target.right);
            }
        }
        public static TreeNode GenerateTreeNode(int[] nums,int nullNum)
        {
            return GenerateTreeNodeDFS(nums,0, nullNum);
        }
        private static TreeNode GenerateTreeNodeDFS(int[] nums,int index, int nullNum)
        {
            TreeNode root = new TreeNode(nums[index]);
            if (2 * index >= nums.Length||(2 * index < nums.Length && nums[2 * index] == nullNum))
                root.left = null;
            else
            {
                root.left = GenerateTreeNodeDFS(nums, 2 * index, nullNum);
            }
            if (2 * index+1 >= nums.Length||(2 * index + 1 < nums.Length && nums[2 * index + 1] == nullNum))
                root.right= null;
            else
            {
                root.right = GenerateTreeNodeDFS(nums, 2 * index+1, nullNum);
            }
            return root;
        }
        public void ShowTreeNode(TreeNode root)
        {

        }
    }
}
