﻿using System.Text;

namespace Searching
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            try
            {
                if ( args.Length > 1 )
                {
                    //директория запуска приложения
                    var path = Directory.GetCurrentDirectory( );
                    //заданное расширение
                    var ext = args[ 0 ];
                    //коррекция введеного расширения
                    if ( !ext.StartsWith( '.' ) )
                        ext = $".{args[ 0 ]}";
                    //в тексте могут быть пробелы и следовательно он займет несколько
                    //ячеек в массиве args. Соединяем все последующие элементы в одну строку.
                    var text = String.Join( ' ' , args , 1 , args.Length - 1 );
                    Search( path , ext , text );
                }
                Console.WriteLine( "Программа успешно завершена." );

            } catch ( IOException e )
            {
                Console.WriteLine( $"Фатальная ошибка при работе с файлами/директориями : " +
                    $"\n{e.Message}\n\n Программа закрыта." );
            } catch ( Exception e )
            {
                Console.WriteLine( $"Фатальная ошибка. Программа закрыта. :\n{e.Message}" );
            }

        }

        private static void Search ( string path , string extension , string text )
        {
            text = text.Trim( ).ToLower( );
            //все файлы имеющие заданное расширение
            var files = Directory.GetFiles( path ).Where( x => new FileInfo( x ).Extension == extension );
            if ( files?.Count( ) > 0 )
            {//поиск искомого текста в файлах
                foreach ( var file in files )
                {
                    //если нет доступа к файлу, перейдем к следующему
                    try
                    {
                        using ( var read = new StreamReader( file ) )
                        {
                            while ( !read.EndOfStream )
                            {
                                string? line = read.ReadLine( )?.Trim( ).ToLower( );
                                if ( line != null && ( line.Contains( text ) || line.Equals( text ) ) )
                                {
                                    Console.WriteLine( file );
                                    break;
                                }
                            }
                        }
                    } catch ( UnauthorizedAccessException e )
                    {
                        Console.WriteLine( $"Не могу получить доступ к {file}" );
                    }
                }
            }
            if ( Directory.GetDirectories( path ).Length > 0 )
            {//перебор директорий
                foreach ( var dir in Directory.GetDirectories( path ) )
                {
                    //если нет доступа к директории, перейдем к следующей
                    try
                    {
                        Search( Path.Combine( path , dir ) , extension , text );

                    } catch ( UnauthorizedAccessException )
                    {
                        Console.WriteLine( $"Не могу получить доступ к {dir}" );
                    }
                }
            }

        }
    }
}
