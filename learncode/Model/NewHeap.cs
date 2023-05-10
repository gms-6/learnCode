using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.Model
{
    public class NewHeap
    {
        public void ShiftUP(int[] nums, int n, int cur)
        {
            int parent = (cur - 1) / 2;
            while (cur > 0)
            {
                if (nums[cur] < nums[parent])
                {
                    swap(nums, cur, parent);
                    cur = parent;
                    parent = (cur - 1) / 2;
                }
                else break;
            }
        }

        public void ShiftDown(int[] nums, int n, int cur)
        {
            int child = 2 * cur + 1;
            while (child < n)
            {
                if (child + 1 < n && nums[child + 1] < nums[child])
                    child++;
                if (nums[child] < nums[cur])
                {
                    swap(nums, child, cur);
                    cur = child;
                    child = 2 * cur + 1;
                }
                else { break; }
            }
        }
        private void Down(int[] nums, int n, int cur)
        {
            int child = 2 * cur + 1;
            while (child < n)
            {
                if (child + 1 < n && nums[child + 1] < nums[child])
                    child++;
                if (nums[child] < nums[cur])
                {
                    swap(nums, child, cur);
                    cur = child;
                    child = 2 * cur + 1;
                }
                else { break; }
            }
        }
        public int[] HeapSort(int[] nums)
        {
            int n = nums.Length - 1;
            int[] target = new int[n + 1];
            while (n > 0)
            {
                target[n] = nums[0];
                nums[0] = nums[n];
                Down(nums, --n, 0);
            }
            target[0] = nums[0];
            return target;
        }

        public void CreatSmallHeapDown(int[] nums)
        {
            int n = nums.Length;
            for (int i = (n - 2) / 2; i >= 0; --i)
            {
                ShiftDown(nums, n, i);
            }
        }
        public void CreatSmallHeapUp(int[] nums)
        {
            int n = nums.Length;
            for (int i = 1; i < n; i++)
            {
                ShiftUP(nums, n, i);
            }
        }



        private void swap(int[] nums, int a, int b)
        {
            int temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}
