using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.classModel
{
    public  class SortMethod
    {


        public static void MergeSort(int[] nums,int first,int last,int[] temp)
        {
            if(first<last)
            {
                int mid = (first+last) / 2;
                MergeSort(nums,first,mid,temp);
                MergeSort(nums,mid+1,last,temp);
            }
        }
        private void mergearray(int[] nums,int first,int mid,int last,int[] temp)
        {
            int i = first, j = mid + 1;
            int m = mid, n = last;
            int k = 0;
            while(i<=m&&j<=n)
            {
                if (nums[i] > nums[j])
                    temp[k++] = nums[i++];
                else
                    temp[k++] = nums[j++];
            }
            while (i <= m)
                temp[k++] = nums[i++];
            while (j <= n)
                temp[k++] = nums[j++];
            for (i = 0; i < k; ++i)
                nums[first + i] = temp[i];
        }
    }
}
