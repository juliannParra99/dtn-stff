using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindow
{
    public  interface IMaxSubarraySum
    {
        int maxSum(int[] array, int k);
        int MaxSumSlidingWindowOptimized(int[] array, int k);
    }
}
