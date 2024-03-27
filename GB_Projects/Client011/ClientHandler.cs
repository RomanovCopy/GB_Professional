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
            new Thread( SendMessage ).Start();
        }

        private void SendMessage ( )
        {
            bool exit = false;
            using ( var client = new UdpClient( 6666 ) )
            {
                while ( !exit )
                {
                    Console.WriteLine( "Закрыть чат - \" Exit \"" );
                    string? text = Console.ReadLine( );
                    if ( !( exit = text?.Trim( ).ToLower( ) == "exit" ) )
                    {
                        Message message = new Message( )
                        {
                            DateTime = DateTime.Now ,
                            NickNameFrom = "Client" ,
                            NickNameTo = "Server" ,
                            Text = text
                        };
                        string json = message.SerializeMessageToJson( );
                        var bytes = Encoding.UTF8.GetBytes( json );
                        var ipEndPoint = new IPEndPoint( IPAddress.Parse( ip ) , port );
                        client.Connect( ipEndPoint );
                        int lengthMessage = client.Send( bytes , bytes.Length );
                        if ( lengthMessage == bytes.Length )
                        {
                            Console.WriteLine( "Сообщение отправлено.\nОжидаю подтверждения:\n" );
                            bool ready = false;
                            var thread = new Thread( ( ) => ReceiveMessage( client , ipEndPoint , out ready ) );
                            thread.Start( );
                            thread.Join( 6000 );
                            if ( !ready )
                            {
                                Console.WriteLine( "Время ожидания ответа от сервера истекло." );
                            }
                        }
                    }
                }

            }
        }

        private void ReceiveMessage ( UdpClient udpClient , IPEndPoint endPoint , out bool ready )
        {
            try
            {
                udpClient.Client.ReceiveTimeout = 5000;
                byte[ ] bytes = udpClient.Receive( ref endPoint );
                if ( bytes != null )
                {
                    string json = Encoding.UTF8.GetString( bytes );
                    var message = Message.DeserializeFromJsonToMessage( json );
                    message?.PrintMessage( );
                }
                ready = true;

            } catch
            {
                ready = false;
            }
        }
    }
}
