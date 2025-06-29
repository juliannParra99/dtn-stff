using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquilibriumIndexAssessment
{
    public class Solution
    {
        public int solution(int[] A)
        {
            long totalSum = 0;
            foreach (int num in A)
                totalSum += num;

            long leftSum = 0;

            for (int i = 0; i < A.Length; i++)
            {
                long rightSum = totalSum - leftSum - A[i];

                if (leftSum == rightSum)
                    return i;

                leftSum += A[i];
            }

            return -1;
        }
    }
}
