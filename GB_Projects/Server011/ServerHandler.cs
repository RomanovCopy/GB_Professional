using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Data011;

namespace Server011
{
    internal class ServerHandler
    {
        private readonly string ip;
        private readonly int port;
        private readonly IPEndPoint endPoint;
        private bool exit { get; set; }

        public ServerHandler ( string ip , int port )
        {
            this.ip = ip;
            this.port = port;
            endPoint = new( IPAddress.Parse( ip ) , port );
            while ( !exit )
            {
                AwaitMessage( );

            }
        }

        private Message? AwaitMessage ( )
        {
            Message? message = null;



            return message;
        }
    }
}
