using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Data011;

namespace Server011
{
    internal class ServerHandler
    {
        private int port;
        private bool exit { get; set; }

        public ServerHandler (  int port )
        {
            this.port = port;
            while ( !exit )
            {
                AwaitMessage( );
            }
        }

        private Message? AwaitMessage ( )
        {
            Console.WriteLine( "Сервер ожидает сообщения." );
            Message? message = null;
            using ( var server = new UdpClient( port ) )
            {
                var endPoint = new IPEndPoint( IPAddress.Any , 0 );
                if ( endPoint != null )
                {
                    var bytes = server.Receive( ref endPoint );
                    if ( bytes != null )
                    {
                        var stringMessage = Encoding.UTF8.GetString( bytes );
                        message = Message.DeserializeFromJsonToMessage( stringMessage );
                        message?.PrintMessage( );
                        SendMessage( message , server , endPoint );
                    }
                }
            }
            return message;
        }

        private void SendMessage ( Message? message , UdpClient client , IPEndPoint endPoint )
        {
            if ( message != null )
            {
                Message newMessage = new Message( )
                {
                    DateTime = DateTime.Now ,
                    NickNameFrom = message.NickNameTo ,
                    NickNameTo = message.NickNameFrom ,
                    Text = $"Сообщение от {message.NickNameFrom} получено. "
                };
                string json = newMessage.SerializeMessageToJson( );
                var bytes = Encoding.UTF8.GetBytes( json );
                client.Send( bytes , bytes.Length, endPoint );

            }

        }
    }
}
