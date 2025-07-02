using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public  class MyArray : IFindArray
    {
        public int FindArray(int[] array, int[] SubArray)
        {
            //i should add validations in case array contains 0 elements
            //[1,2,3]
            int firstIndex = -1;
            int aux;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == SubArray[0])
                {
                    firstIndex = i;
                }
            }

            if (firstIndex != -1)
            {
                for(int f = 0; f< (SubArray.Length) - 1; f++)
                {
                    if (SubArray[f] == array[firstIndex +f])
                    {
                        firstIndex = firstIndex;
                    }
                    else
                    {
                        firstIndex = -1;
                        return firstIndex;
                    }
                }
          
            }
            return firstIndex;
        }
    }
}
