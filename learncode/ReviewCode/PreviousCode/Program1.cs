using learncode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learncode.ReviewCode.PreviousCode
{
    class Program1
    {
        static int M = 0;
        static int min = int.MaxValue;

        //static void Main(string[] args)
        //{
            #region 人数最多的站点
            //int count = Convert.ToInt32(Console.ReadLine());
            //int[,] platform = new int[count, 2];
            //int far = 0;
            //int max = 0;
            //int num = -1;
            //for(int i=0;i< count;++i)
            //{
            //    string[] pla = Console.ReadLine().Split(' ');
            //    int a = Convert.ToInt32(pla[0]);
            //    int b = Convert.ToInt32(pla[1]);
            //    if(a>b)
            //    {
            //        platform[i, 0] = b;
            //        platform[i, 1] = a+4;
            //        if(a+4>far)
            //            far = a+4;
            //    }
            //    else
            //    {
            //        platform[i, 0] = a;
            //        platform[i, 1] = b;
            //        if (b > far)
            //            far = b;
            //    }
            //}
            //for(int i=1;i<=far;++i)
            //{
            //    int sum = 0;
            //    for(int j=0;j<count;++j)
            //    {
            //        if (i >= platform[j, 0] && i < platform[j,1])
            //            sum++;
            //    }
            //    if (sum > max)
            //    {
            //        max = sum;
            //        num = i;
            //    }
            //}
            //if (num > 4)
            //    Console.WriteLine(num - 4);
            //else
            //    Console.WriteLine(num);
            #endregion

            #region 
            //string[] str=Console.ReadLine().Split(' ');
            //M = Convert.ToInt32(Console.ReadLine());
            //int[] nums= new int[str.Length];
            //for(int i=0;i< str.Length; ++i)
            //{
            //    nums[i] = Convert.ToInt32(str[i]);
            //    if (nums[i] < min)
            //        min = nums[i];
            //}
            //int count=newArray(nums, 0, 0, 0);
            //Console.WriteLine(count);
            #endregion
            //Heap heap = new Heap();
            //int[] nums = { 4, 26, 7, 1, 3, 9, 5, 2, 7, 5 };
            //heap.CreatSmallHeapDown(nums);   //O(n)
            //var a = heap.HeapSort(nums);       //O(N)
            //Show(a);
            //Array.Sort(nums);
            //Show(nums);

           // Console.ReadKey();
        //}

        //public static void Show(int[] nums)
        //{
        //    int n= nums.Length; 
        //    for(int i=0;i<n;i++)
        //        Console.WriteLine(nums[i]);
        //}
        public static int newArray(int[] nums, int index, int sum, int count)
        {
            if (sum > M)
            {
                return count;
            }
            if (sum < M && M - sum < min)
                return count + 1;
            for (int i = index; i < nums.Length; ++i)
            {
                count = newArray(nums, i, sum + nums[i], count);
            }
            return count;
        }


        public void SelectionSort(int[] nums)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                int min = int.MaxValue;
                int index = -1;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] < min)
                    {
                        min = nums[j];
                        index = j;
                    }
                }
                Swap(nums, i, index);
            }
        }
        public void MergeSort(int[] nums, int start, int end)
        {
            if (start == end)
                return;
            int mid = start + (end - start) / 2;
            MergeSort(nums, start, mid);
            MergeSort(nums, mid + 1, end);
            MergeArray(nums, start, mid, end);

        }
        public void MergeArray(int[] nums, int start, int mid, int end)
        {
            int[] temp = new int[end - start + 1];
            int i = start;
            int j = mid + 1;
            int k = 0;
            while (i <= mid && j <= end)
            {
                if (nums[i] > nums[j])
                    temp[k++] = nums[j++];
                else
                    temp[k++] = nums[i++];
            }
            while (i <= mid)
                temp[k++] = nums[i++];
            while (j <= end)
                temp[k++] = nums[j++];
            for (i = 0; i < temp.Length; ++i)
            {
                nums[start + i] = temp[i];
            }
        }

        #region 归并排序
        //public void MergeSort(int[] nums,int left,int right)
        //{
        //    if (left == right)
        //        return;
        //    int mid = left + (right - left) / 2;
        //    MergeSort(nums, left, mid);
        //    MergeSort(nums, mid+1, right);
        //    merge(nums,left,mid+1,right);

        //}
        //public void merge(int[] arr,int leftPtr, int rightPtr,int rightBound)
        //{
        //    int mid = rightPtr - 1;
        //    int[] temp = new int[rightBound - leftPtr + 1];

        //    int i = leftPtr;
        //    int j = rightPtr;
        //    int k = 0;

        //    while (i <= mid && j <= rightBound)
        //    {
        //        if (arr[i] <= arr[j])
        //        {
        //            temp[k] = arr[i];
        //            i++;
        //            k++;
        //        }
        //        else
        //        {
        //            temp[k] = arr[j];
        //            j++;
        //            k++;
        //        }
        //    }

        //    // 将右边剩余的归并
        //    while (i <= mid)
        //    {
        //        temp[k++] = arr[i++];
        //    }
        //    //将左边剩余的归并
        //    while (j <= rightBound)
        //    {
        //        temp[k++] = arr[j++];

        //    }

        //    for (int m = 0; m < temp.Length; m++) arr[leftPtr + m] = temp[m];
        //}
        #endregion

        public void QuickSort(int[] nums, int start, int end)
        {
            if (start > end)
                return;
            int i = start, j = end;
            int index = nums[start];
            while (i < j)
            {
                while (i < j && nums[j] >= index) j--;
                while (i < j && nums[i] <= index) i++;
                if (i < j)
                {
                    Swap(nums, i, j);
                }
            }
            Swap(nums, start, i);
            QuickSort(nums, start, i - 1);
            QuickSort(nums, i + 1, end);
        }
        public void Swap(int[] nums, int fir, int sec)
        {
            int temp = nums[fir];
            nums[fir] = nums[sec];
            nums[sec] = temp;
        }
        public void InsertionSort(int[] nums)
        {
            for (int i = 1; i < nums.Length; ++i)
            {
                int num = nums[i];
                int j = i;
                while (j > 0 && num < nums[j - 1])
                {
                    nums[j] = nums[j - 1];
                    j--;
                }
                nums[j] = num;
            }
        }
        public void BubbleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                for (int j = nums.Length - 1; j > i; --j)
                {
                    if (nums[j] > nums[j - 1])
                    {
                        nums[j] = nums[j] ^ nums[j - 1];
                        nums[j - 1] = nums[j] ^ nums[j - 1];
                        nums[j] = nums[j] ^ nums[j - 1];
                    }
                }
            }
        }
        public static void Show(int[] nums)
        {
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }
        }
        public void Show(IList<int> nums)
        {
            foreach (int num in nums)
            {
                Console.Write(num + " ");
            }
        }
    }
}
