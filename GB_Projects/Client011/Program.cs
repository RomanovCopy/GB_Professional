using System.Security.Claims;

using Data011;

namespace Client011
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            CreateClient( );
        }

        private static void CreateClient ( )
        {
            ClientHandler clientHandler = new ClientHandler( "127.0.0.1" , 1234 );
        }
    }
}
