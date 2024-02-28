using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson03_Collections01
{
    internal class Labyrinth
    {
        private Stack<Tuple<int , int>> currentPath = new Stack<Tuple<int , int>>( );
        private List<Stack<Tuple<int , int>>> allPaths = new List<Stack<Tuple<int , int>>>( );
        private readonly int columns;
        private readonly int rows;

        public Labyrinth ( int[ , ] labirinth , Tuple<int , int> startPoint )
        {
            rows = labirinth.GetLength( 0 );
            columns = labirinth.GetLength( 1 );


            Console.WriteLine( $" Найдено {HasExit( startPoint.Item1 , startPoint.Item2 , labirinth )} выходов из лабиринта \n" );
            int steps = 1;

            foreach ( var p in allPaths )
            {
                Console.Write( $"{steps}  " );
                while ( p.Count > 0 )
                {
                    var item = p.Pop( );
                    Console.Write( $"({item.Item1}, {item.Item2})" + (p.Count>=1?"->":"") );
                }
                Console.WriteLine( );
                steps++;
            }
        }


        private int HasExit ( int startI , int startJ , int[ , ] l )
        {
            //точка за пределами лабиринта или занята
            if ( startI < 0 || startJ < 0 || startI >= rows || startJ >= columns || l[ startI , startJ ] == 1 )
                return allPaths.Count;
            //занимаем точку
            l[ startI , startJ ] = l[ startI , startJ ] == 0 ? 1 : l[ startI , startJ ];
            //добавление точки в маршрут
            currentPath.Push( new Tuple<int , int>( startI , startJ ) );
            //окончание поиска
            if ( l[startI, startJ]==2 )
            {
                //отсеиваем другие маршруты приходящие в эту точку
                if ( ! allPaths.Any( path => path.Last( ).Item1 == startI && path.Last( ).Item2 == startJ ) )
                    allPaths.Add( new Stack<Tuple<int , int>>( currentPath ) );
                return allPaths.Count;
            }
            //перемещения
            //вверх
            HasExit( startI - 1 , startJ , l );
            //вправо
            HasExit( startI , startJ + 1 , l );
            //вниз
            HasExit( startI + 1 , startJ , l );
            //влево
            HasExit( startI , startJ - 1 , l );
            //удаление точки из маршрута
            currentPath.Pop( );
            //освобождение точки
            l[ startI , startJ ] = 0;
            return allPaths.Count;
        }


    }
}
