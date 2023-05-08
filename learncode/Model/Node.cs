using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int val,IList<Node> children)
        {
            this.val = val;
            this.children = children;
        }
    }
}
