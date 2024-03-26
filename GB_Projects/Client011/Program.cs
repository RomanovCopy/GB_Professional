using System.Security.Claims;

using Data011;

namespace Client011
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            Thread thread = new Thread( CreateClient );
            thread.Start( );
        }

        private static void CreateClient ( )
        {
            ClientHandler clientHandler = new ClientHandler( "127.0.0.1" , 1234 );
        }
    }
}
