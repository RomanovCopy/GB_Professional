using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Data011;

namespace Client011
{
    internal class ClientHandler
    {
        private string ip { get; set; }
        private int port { get; set; }
        public ClientHandler ( string ip , int port )
        {
            this.ip = ip;
            this.port = port;

            while ( true )
            {
                Console.WriteLine( "Закрыть чат - \" Exit \"" );
                string? text = "";
                if ( ( text = Console.ReadLine( )?.Trim( ).ToLower( ) ) == "exit" )
                {
                    break;
                }
                Message message = new Message( )
                {
                    DateTime = DateTime.Now ,
                    NickNameFrom = "Client" ,
                    NickNameTo = "Server" ,
                    Text = text
                };
                SendMessage( message );
            }


        }

        private void SendMessage ( Message message )
        {
            string json = message.SerializeMessageToJson( );
            var bytes = Encoding.UTF8.GetBytes( json );
            using ( var client = new UdpClient( ) )
            {
                var ipEndPoint = new IPEndPoint( IPAddress.Parse(ip), port );
                int lengthMessage = client.Send( bytes , bytes.Length, ipEndPoint );
                if( lengthMessage == bytes.Length )
                {
                    Console.WriteLine("Сообщение отправлено.\nОжидаю подтверждения:\n");
                }
            }
        }


    }
}
