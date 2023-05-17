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

        public int FindK(int[] nums,int k)
        {
            return QuickSelectKBig(nums,0,nums.Length-1,k-1);
        }
        public int QuickSelectKBig(int[] nums,int start,int end,int k)
        {
            int pivot = partition(nums,start,end);
            if (pivot == k)
                return nums[k];
            else if (pivot > k)
                return QuickSelectKBig(nums, start, pivot - 1, k);
            else
                return QuickSelectKBig(nums, pivot, end, k);
        }
        public int partition(int[] nums,int start,int end)
        {
            int ranIndex = start + random.Next(end-start+1);
            int pivot = nums[ranIndex];
            Swap(nums,ranIndex,start);
            int l = start, r = end;
            while(l<r)
            {
                while (l < r && nums[r] <= pivot)
                    r--;
                nums[l] = nums[r];
                while (l < r && nums[l] >= pivot)
                    l++;
                nums[r] = nums[l];
            }
            nums[l] = pivot;
            return l;


        }














        //public int FindKthLargest(int[] nums, int k)
        //{
        //    return QuickSelect(nums, k - 1, 0, nums.Length - 1);
        //}

        //public int QuickSelect(int[] nums, int index, int start, int end)
        //{
        //    int pivotIndex = Partition(nums, start, end);
        //    if (pivotIndex == index)
        //    {
        //        return nums[pivotIndex];
        //    }
        //    else if (pivotIndex > index)
        //    {
        //        return QuickSelect(nums, index, start, pivotIndex - 1);
        //    }
        //    else
        //    {
        //        return QuickSelect(nums, index, pivotIndex + 1, end);
        //    }
        //}

        //public int Partition(int[] nums, int start, int end)
        //{
        //    int randomIndex = start + random.Next(end - start + 1);
        //    Swap(nums, start, randomIndex);
        //    int pivot = nums[start];
        //    int low = start, high = end;
        //    while (low < high)
        //    {
        //        while (low < high && nums[high] <= pivot)
        //        {
        //            high--;
        //        }
        //        while (low < high && nums[low] >= pivot)
        //        {
        //            low++;
        //        }
        //        if (low < high)
        //        {
        //            Swap(nums, low, high);
        //        }
        //    }
        //    Swap(nums,low,start);
        //    return low;
        //}

        public void Swap(int[] nums, int index1, int index2)
        {
            int temp = nums[index1];
            nums[index1] = nums[index2];
            nums[index2] = temp;
        }
    }
}
