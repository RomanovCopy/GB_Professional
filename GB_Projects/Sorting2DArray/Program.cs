using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting2DArray
{
    /*
     * Дан двумерный массив.

    732
    496
    185

    Отсортировать данные в нем по возрастанию.

    123
    456
    789

    Вывести результат на печать.

     */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[,] { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
            Sorting2DArray(array);
        }

        private static int[,] Sorting2DArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int coils = array.GetLength(1);
            int index = 0;
            int[] newArray = new int[rows * coils];
            for(int i=0; i < rows; i++)
            {
                for(int j=0; j < coils; j++)
                {
                    newArray[index] = array[i, j];
                    index++;
                }
            }
            Array.Sort(newArray);
            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < coils; j++)
                {
                    array[i, j] = newArray[index];
                    index++;
                }
            }
            return array;
        }
    }
}
