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
            int row = startI;
            int column = startJ;
            if ( row >= 0 && row < rows && column >= 0 && column < columns && l[ row , column ] == 0 )
            {
                Validate( row , column , l );
            }
            return allPaths.Count;
        }

        private void Validate(int row, int column, int[ , ]l)
        {
            if ( l[row,column]==0 )
            {
                if(row!=rows-1 && column != columns - 1 && row >= 0 && column >= 0)
                {
                    l[ row , column ] = 1;
                    currentPath.Push( new Tuple<int , int>( row , column ) );
                    Validate( row + 1 , column , l );
                    if ( row > 0 )
                        Validate( row - 1 , column , l );
                    Validate( row , column + 1 , l );
                    if ( column > 0 )
                        Validate( row , column - 1 , l );
                    l[ row , column ] = 0;
                    currentPath.Pop( );
                } else
                {
                    currentPath.Push( new Tuple<int , int>( row , column ) );
                    allPaths.Add( new Stack<Tuple<int, int>>(currentPath) );
                }
            }
            return;
        }

    }
}
