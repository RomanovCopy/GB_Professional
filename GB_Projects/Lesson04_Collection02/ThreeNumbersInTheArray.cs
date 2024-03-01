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

        private int target = 99;

        public ThreeNumbersInTheArray ( )
        {
            int count = 1;
            var l = SearchForThreeTermsBasedOnTheirAmount( array , target );
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
            Array.Sort( array );

            for ( int i = 0 ; i < array.Length - 2 ; i++ )
            {
                int left = i + 1;
                int right = array.Length - 1;

                while ( left < right )
                {
                    int sum = array[ i ] + array[ left ] + array[ right ];
                    if ( sum == target )
                    {
                        list.Add( new Tuple<int , int , int>( array[ i ] , array[ left ] , array[ right ] ) );

                        // Последующие элементы не должны быть равны array[ left ]
                        while ( left < right && array[ left ] == array[ left + 1 ] )
                            left++;
                        // Последующие элементы не должны быть равны array[ right ]
                        while ( left < right && array[ right ] == array[ right - 1 ] )
                            right--;

                        left++;
                        right--;
                    } else if ( sum < target )
                    {//пропускаем минимальные значения
                        left++;
                    } else
                    {//пропускаем максимальные значения
                        right--;
                    }
                }

                // Пропускаем повторяющиеся значения
                while ( i < array.Length - 2 && array[ i ] == array[ i + 1 ] )
                    i++;
            }

            return list;
        }







    }
}
