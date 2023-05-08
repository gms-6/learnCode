using learncode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode
{
    public class MyLinkedList
    {
        public ListNode head;
        public int count;

        public MyLinkedList()
        {
            head =  null;
        }

        public int Get(int index)
        {
            count = GetCount(head);
            if (index > count - 1)
                return -1;
            int num = 0;
            ListNode temp = head;
            ListNode pre = new ListNode(-1);
            pre.next = temp;
            int result = -1;
            while(pre.next!=null)
            {
                ListNode list = pre.next;
                if (num == index)
                {
                    result = list.val;
                    break;
                }
                num++;
            }
            return result;
        }

        public void AddAtHead(int val)
        {
            ListNode temp = head;
            ListNode newHead = new ListNode(val);
            newHead.next = temp;
            head = newHead;
        }

        public void AddAtTail(int val)
        {
            ListNode temp = head;

            while(temp.next!=null)
            {
                temp = temp.next;
            }
            temp.next = new ListNode(val);
        }

        public void AddAtIndex(int index, int val)
        {
            int count = GetCount(head);
            if (index > count)
                return;
            ListNode temphead = head;
            ListNode virHead = new ListNode(-1);
            virHead.next = temphead;
            int num = 0;
            
            while (virHead.next!=null)
            {
                ListNode temp = virHead.next;
                if(num==index-1&&temp.next!=null)
                {
                    ListNode newIndex = new ListNode(val,temp);
                    virHead.next = newIndex;
                    return;
                }
                else if(num == index - 1 && temp.next == null)
                {
                    ListNode newIndex = new ListNode(val);
                    temp.next = newIndex;
                    return;
                }
                virHead = virHead.next;
                num++;
            }

        }

        public void DeleteAtIndex(int index)
        {
            int count = GetCount(head);
            if (index > count)
                return;
            ListNode temphead = head;
            ListNode virHead = new ListNode(-1);
            virHead.next = temphead;
            int num = 0;
            while(virHead.next!=null)
            {
                ListNode target = virHead.next;
                if(num==index)
                {
                    if(target.next!=null)
                    {
                        virHead.next = target.next;
                    }
                    else
                    {
                        virHead.next = null;
                    }
                }
                virHead = virHead.next;
                num++;

            }
        }
        private int GetCount(ListNode head)
        {
            if (head == null)
                return 0;
            ListNode temp = head;
            int count = 1;
            while(temp.next!=null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }
    }
}
