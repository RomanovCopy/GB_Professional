using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            MyClient( "127.0.0.1" , 12345 );
        }

        private static void MyClient ( string ip , int port )
        {
            using ( Socket client = new( AddressFamily.InterNetwork , SocketType.Stream , ProtocolType.Tcp ) )
            {
                var remoteEndPoint = new IPEndPoint( IPAddress.Parse( ip ) , port );
                Console.WriteLine("Подключение");
                client.Connect( remoteEndPoint );
                byte[ ] bytes = Encoding.UTF8.GetBytes( "Привет! Мир!" );
                Console.WriteLine("Подключено!!!");
                if(client.Send(bytes)==bytes.Length)
                    Console.WriteLine("Сообщение отправлено...");
                else
                    Console.WriteLine("Ошибка при попытке отправки сообщения.");
            }
        }

    }
}
