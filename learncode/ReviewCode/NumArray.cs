using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.ReviewCode
{
    public class NumArray
    {

        private int[] sum;
        public NumArray(int[] nums)
        {
            sum = nums;
            int n = nums.Length;
            int temp = nums[0];
            for (int i = 1; i < n; ++i)
            {
                sum[i] = temp + sum[i];
                temp = sum[i];
            }
        }

        public void Update(int index, int val)
        {
            int num = 0;
            if (index==0)
            {
                num = val - sum[index];
            }
            else
            {
                num = val - sum[index] + sum[index - 1];
            }
            
            for (int i = index; i < sum.Length; ++i)
            {
                sum[i] += num;
            }
        }

        public int SumRange(int left, int right)
        {
            if (left == 0)
                return sum[right];
            else
            {
                return sum[right] - sum[left - 1];
            }
        }
    }
}
