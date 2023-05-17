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

            //int randomIndex = start + random.Next(end - start + 1);
            //Swap(nums, start, randomIndex);
            //int pivot = nums[start];
            //int low = start + 1, high = end;
            //while (low < high)
            //{
            //    while (low < high && nums[low] >= pivot)
            //    {
            //        low++;
            //    }
            //    while (low < high && nums[high] < pivot)
            //    {
            //        high--;
            //    }
            //    if (low < high)
            //    {
            //        Swap(nums, low, high);
            //    }
            //}
            //while (high > start && nums[high] < pivot)
            //{
            //    high--;
            //}
            //if (high > start)
            //{
            //    Swap(nums, start, high);
            //}
            //return high;
        }

        public void Swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }



        //public static int Select(int[] nums,int left,int right,int k)
        //{
        //    //k = k - 1;
        //    int p = left;
        //    for(int q=left;q<=right;q++)
        //    {
        //        if (nums[q] > nums[p])
        //        {
        //            int temp = nums[q];
        //            nums[q] = nums[p];
        //            nums[p] = temp;
        //            ++p;
        //        }
        //    }
        //    if (p == k)
        //        return p;
        //    else if (p < k)
        //        return Select(nums, p + 1, right, k);
        //    else
        //        return Select(nums,left,p-1,k);
        //}

    }
}
