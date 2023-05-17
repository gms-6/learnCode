using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel
{
    public class QuickSelectModel
    {
        Random random = new Random();

        public int FindKthLargest(int[] nums, int k)
        {
            return QuickSelect(nums, k - 1, 0, nums.Length - 1);
        }

        public int QuickSelect(int[] nums, int index, int start, int end)
        {
            int pivotIndex = Partition(nums, start, end);
            if (pivotIndex == index)
            {
                return nums[pivotIndex];
            }
            else if (pivotIndex > index)
            {
                return QuickSelect(nums, index, start, pivotIndex - 1);
            }
            else
            {
                return QuickSelect(nums, index, pivotIndex + 1, end);
            }
        }

        public int Partition(int[] nums, int start, int end)
        {
            int randomIndex = start + random.Next(end - start + 1);
            Swap(nums, start, randomIndex);
            int pivot = nums[start];
            int low = start, high = end;
            while (low < high)
            {
                while (low < high && nums[high] <= pivot)
                {
                    high--;
                }
                while (low < high && nums[low] >= pivot)
                {
                    low++;
                }
                if (low < high)
                {
                    Swap(nums, low, high);
                }
            }
            Swap(nums,low,start);
            return low;
        }

        public void Swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
    }
}
