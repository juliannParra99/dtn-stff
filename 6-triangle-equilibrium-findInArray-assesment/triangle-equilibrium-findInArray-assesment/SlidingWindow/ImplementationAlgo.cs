using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    public class ImplementationAlgo : IMaxSubarraySum 
    {
        public int maxSum(int[] array, int k)
        {
            if(array == null || k == null || k > array.Length || k <= 0)
            {
                return -1;
            }
            int maxSum = 0;
            int totalLength = array.Length - k;
            for(int i = 0; i <= totalLength; i++ )
            {
                
                int tempSum = 0;
                for(int j = 0; j < k; j++)
                {
                    if (i == 0)
                    {
                        maxSum += array[i + j];
                    }
                    tempSum += array[i + j];
                }
                if(tempSum > maxSum)
                {
                    maxSum = tempSum;
                }
            }
            return maxSum;
        }
        public int MaxSumSlidingWindowOptimized(int[] array, int k)
        {
            if (array == null || k > array.Length || k <= 0)
                return -1;

            int windowSum = 0;
            for (int i = 0; i < k; i++)
            {
                windowSum += array[i]; 
            }

            int maxSum = windowSum;

            for (int i = k; i < array.Length; i++)
            {
                windowSum = windowSum - array[i - k] + array[i]; 
                if (windowSum > maxSum)
                {
                    maxSum = windowSum;
                }
            }

            return maxSum;
        }
    }
}
