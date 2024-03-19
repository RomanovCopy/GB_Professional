using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_NetworkClientAndServerApplications
{
    internal class Lesson
    {
        public Lesson ( )
        {

            Server( "127.0.0.1" , 12345 );
        }



        private void Server(string ip, int port )
        {
            using ( Socket listiner = new( AddressFamily.InterNetwork , SocketType.Stream , ProtocolType.Tcp ) )
            {
                var localEndPoint = new IPEndPoint( IPAddress.Parse( ip ) , port );
                listiner.Blocking = true;
                listiner.Bind( localEndPoint );
                listiner.Listen( 100 );
                Console.WriteLine( "Ожидаю подключения." );
                var socket = listiner.Accept( );
                Console.WriteLine( "Подключен" );
                byte[ ] bytes = new byte[255];
                int count = socket.Receive( bytes );
                if ( count > 0 )
                {
                    Console.WriteLine(Encoding.UTF8.GetString(bytes));
                } else
                {
                    Console.WriteLine("Ошибка при приеме сообщения");
                }
                listiner.Close( );
            }
        }
    }
}
