using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.Model
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode()
        {
            val = 0;
        }

        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
