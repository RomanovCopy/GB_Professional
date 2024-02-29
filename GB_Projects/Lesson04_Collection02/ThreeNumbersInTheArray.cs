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
            12, 76, 71, 73, 61, 25, 43, 81, 1, 79,
            52, 86, 71, 22, 93, 64, 17, 5, 52, 34,
            56, 10, 89, 78, 72, 36, 57, 91, 85, 20,
            16, 1, 15, 80, 88, 80, 84, 27, 89, 75,
            21, 66, 48, 69, 26, 48, 23, 24, 19, 7
        };

        private int target = 171;

        public ThreeNumbersInTheArray ( )
        {
            var l = SearchForThreeTermsBasedOnTheirAmount( array , target );
            int count = 1;
            foreach ( var val in l )
            {
                Console.WriteLine( $"{count}   {val.Item1} + {val.Item2} + {val.Item3} = {val.Item1 + val.Item2 + val.Item3}" );
                count++;
            }
        }

        private List<Tuple<int , int , int>> SearchForThreeTermsBasedOnTheirAmount ( int[ ] array , int target )
        {
            List<Tuple<int , int , int>> list = new List<Tuple<int , int , int>>( array.Length / 3 );
            var val1 = new List<int>( array.Where( x => x < target ) );
            int v1, v2, v3, difference = 0;
            if ( val1.Count( ) > 2 )
            {
                for ( int i = 0 ; i < val1.Count ; i++ )
                {
                    v1 = val1[ i ];
                    difference = target - v1;
                    var val2 = val1.Where( x => x < difference && !x.Equals( v1 ) ).ToList<int>( );
                    if ( val2.Count( ) > 1 )
                    {
                        for ( int j = 0 ; j < val2.Count( ) ; j++ )
                        {
                            v2 = val2[ j ];
                            difference = target - v1 - v2;
                            var val3 = val2.Where( x => x <= difference && !x.Equals( v2 ) ).ToList<int>( );
                            v3 = val3.Where( x => x == difference ).FirstOrDefault( );
                            if ( v1 + v2 + v3 == target && !list.Any( x => x.Item1 == v1 && x.Item2 == v2 && 
                            x.Item3 == v3 ) )
                            {
                                list.Add( new Tuple<int , int , int>( v1 , v2 , v3 ) );
                                val1.Remove( v1 );
                                val1.Remove( v2 );
                                val1.Remove( v3 );
                            }
                        }
                    }
                }
            }
            return list;
        }





    }
}
