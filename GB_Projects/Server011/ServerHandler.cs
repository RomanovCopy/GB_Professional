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
        private string ip;
        private int port;
        private bool exit { get; set; }

        public ServerHandler ( string ip , int port )
        {
            this.ip = ip;
            this.port = port;
            while ( !exit )
            {
                AwaitMessage( );
            }
        }

        private Message? AwaitMessage ( )
        {
            Console.WriteLine("Сервер ожидает сообщения.");
            Message? message = null;
            using ( var server = new UdpClient( port ) )
            {
                var endPoint = new IPEndPoint( IPAddress.Any , 0 );
                if ( endPoint != null )
                {
                    var bytes = server.Receive( ref endPoint);
                    if ( bytes != null )
                    {
                        var stringMessage = Encoding.UTF8.GetString( bytes );
                        message = Message.DeserializeFromJsonToMessage( stringMessage );
                        message?.PrintMessage( );
                    }
                }
            }
            return message;
        }
    }
}
