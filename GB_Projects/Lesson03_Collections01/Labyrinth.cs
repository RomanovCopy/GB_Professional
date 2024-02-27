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
        private int steps = 0;

        public Labyrinth ( int[ , ] labirinth , Tuple<int , int> startPoint )
        {
            rows = labirinth.GetLength( 0 );
            columns = labirinth.GetLength( 1 );


            Console.WriteLine( $" Найдено {HasExit( startPoint.Item1 , startPoint.Item2 , labirinth )} выходов из лабиринта \n" );
            steps = 1;

            foreach ( var p in allPaths )
            {
                Console.Write( $"{steps}  " );
                while ( p.Count > 0 )
                {
                    var item = p.Pop( );
                    Console.Write( $"({item.Item1}, {item.Item2}) -> " );
                }
                Console.WriteLine( );
                steps++;
            }
        }


        private int HasExit ( int startI , int startJ , int[ , ] l )
        {
            //точка за пределами лабиринта или занята
            if ( startI < 0 || startJ < 0 || startI >= rows || startJ >= columns || l[ startI , startJ ] == 1 )
            {
                return allPaths.Count;
            }
            //окончание поиска
            if ( startI == rows - 1 || startJ == columns - 1 )
            {
                allPaths.Add( new Stack<Tuple<int, int>>( currentPath ) );
                return allPaths.Count;
            }
            //занимаем точку
            l[ startI , startJ ] = 1;
            //добавление точки в маршрут
            currentPath.Push( new Tuple<int , int>( startI , startJ ) );
            //перемещения
            steps++;
            //вправо
            HasExit( startI , startJ + 1 , l );
            steps++;
            //вниз
            HasExit( startI + 1 , startJ , l );
            steps++;
            //влево
            HasExit( startI , startJ - 1 , l );
            steps++;
            //вверх
            HasExit( startI - 1 , startJ , l );
            steps++;
            //удаление точки из маршрута
            currentPath.Pop( );
            //освобождение точки
            l[ startI , startJ ] = 0;
            return allPaths.Count;
        }



    }
}
