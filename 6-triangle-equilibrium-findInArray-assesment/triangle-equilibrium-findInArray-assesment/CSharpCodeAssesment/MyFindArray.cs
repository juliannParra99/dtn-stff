using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPI.Test;

namespace FindArrayAssessment
{
    public  class MyFindArray : IFindArray
    {
        public int FindArray(int[] array, int[] subArray)
        {
            if (array == null || subArray == null || subArray.Length == 0 || subArray.Length > array.Length)
                return -1;

            for (int i = 0; i <= array.Length - subArray.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < subArray.Length; j++)
                {
                    if (array[i + j] != subArray[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                    return i;
            }

            return -1;
        }
    }
}
