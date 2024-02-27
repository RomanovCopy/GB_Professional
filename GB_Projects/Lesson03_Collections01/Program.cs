using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03_Collections01
{
    internal class Program
    {
        private static int[ , ] labirynth1 = new int[ , ]
        {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
        };


        static void Main ( string[ ] args )
        {
            new Labyrinth( labirynth1 , new Tuple<int , int>( 3 , 0 ) );
            //new Labyrinth( labirynth1 , new Tuple<int , int>( 6 , 3 ) );

        }
    }
}
