using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.Model
{
    public class Heap
    {
        public int[] data;
        public int size;
        public int capacity;
        public Heap()
        {

        }
        public void shiftDown(int[] nums,int n,int cur)
        {
            int child = 2 * cur + 1;
            while(child<n)
            {
                if (child + 1 < n && nums[child + 1] < nums[child])
                    ++child;
                if (nums[child] < nums[cur])
                {
                    int temp = nums[child];
                    nums[child] = nums[cur];
                    nums[cur] = temp;
                    cur = child;
                    child = 2 * cur + 1;
                }
                else
                    break;
            }
        }
        public void shiftUP(int[] nums,int n,int cur)
        {
            int parent = (cur - 1) / 2;
            while(cur>0)
            {
                if (nums[cur] < nums[parent])
                {
                    int temp = nums[cur];
                    nums[cur] = nums[parent];
                    nums[parent] = temp;
                    cur = parent;
                    parent = (cur - 1) / 2;
                }
                else
                    break;
            }
        }
        public void headCreate(int[] nums,int n)
        {
            for(int i=(n-2)/2;i>=0;i--)
            {
                shiftDown(nums, n, i);
            }
        }
    }
}
