using System;
using System.CodeDom;
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
            12, 76, 71, 73, 61, 25, 43, 81, 15, 79,
            52, 86, 71, 22, 93, 64, 17, 5, 52, 34,
            56, 10, 89, 78, 72, 36, 57, 91, 85, 20,
            16, 1, 15, 80, 88, 80, 76, 27, 89, 75,
            21, 66, 48, 69, 26, 48, 23, 24, 76, 7
        };

        private int target = 95;

        public ThreeNumbersInTheArray ( )
        {
            List<Tuple<int , int , int>> l = null;
            int count = 1;
            l = SearchForThreeTermsBasedOnTheirAmount( array , target );
            if ( l.Count == 0 )
                Console.WriteLine( "Подходящих чисел не найдено" );
            foreach ( var val in l )
            {
                Console.WriteLine( $"{count}   {val.Item1} + {val.Item2} + {val.Item3} = {val.Item1 + val.Item2 + val.Item3}" );
                count++;
            }
        }


        private List<Tuple<int , int , int>> SearchForThreeTermsBasedOnTheirAmount ( int[ ] array , int target )
        {
            List<Tuple<int , int , int>> list = new List<Tuple<int , int , int>>( );
            var val1 = new List<int>( array );
            val1.Sort( );
            bool isLeft = true;
            int v1, v2, v3, left, right = 0;
            if ( val1.Count( ) > 2 )
            {
                left = 0;
                right = val1.Count( ) - 1;
                while ( left < right )
                {
                    v1 = val1[ left ];
                    v2 = val1[ right ];
                    v3 = target - v1 - v2;
                    bool isTargetInRegion = val1.Skip( left ).Take( right - left ).Contains( v3 ) && !(v1.Equals(v2) || v1.Equals(v3) || v2.Equals(v3));
                    if ( isTargetInRegion && !list.Any( x => x.Item1 == v1 && x.Item2 == v2 && x.Item3 == v3 ) )
                    {
                        list.Add( new Tuple<int , int , int>( v1 , v2 , v3 ) );
                    }
                    if ( isLeft )
                    {
                        left++;
                        //isLeft = false;
                    } else
                    {
                        right--;
                        isLeft = true;
                    }
                }
            }
            return list;
        }






    }
}
