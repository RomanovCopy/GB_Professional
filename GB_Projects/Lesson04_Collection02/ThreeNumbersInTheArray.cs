using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson04_Collection02
{
    /*
     Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.

    Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два
    числа равных по сумме первому.
     */

    internal class ThreeNumbersInTheArray
    {
        private int[ ] array =
        {
            12, 76, 71, 73, 61, 25, 43, 81, 1, 79,
            52, 86, 71, 22, 93, 64, 17, 5, 52, 34,
            56, 10, 89, 78, 72, 36, 57, 91, 85, 20,
            16, 1, 15, 80, 88, 80, 84, 27, 89, 75,
            21, 66, 48, 69, 26, 48, 23, 24, 19, 7
        };

        private int target=100;

        public ThreeNumbersInTheArray ( )
        {
            SearchForThreeTermsBasedOnTheirAmount( array , target );
        }

        private List<Tuple<int , int , int>> SearchForThreeTermsBasedOnTheirAmount ( int[ ] array , int target )
        {
            List<Tuple<int , int , int>> list = new List<Tuple<int , int , int>>( array.Length / 3 );
            //SortedSet<int> set = new SortedSet<int>( array.Where( x => x < target ) );
            var val1 = new List<int>( array.Where( x => x < target ) );
            int v1, v2, v3 = 0;
            if ( val1.Count() > 2 )
            {
                for(int i=0 ; i < val1.Count ; i++ )
                {
                    v1 = val1[ i ];
                    var val2 = val1.Where( x => x < target - v1 );
                    if ( val2.Count() > 2 )
                    {

                    }
                }
            }

            return list;
        }





    }
}
