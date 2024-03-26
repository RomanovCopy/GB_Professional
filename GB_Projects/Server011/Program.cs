using Data011;

namespace Server011
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            Thread thread = new Thread( CreateServer );
            thread.Start( );
        }

        private static void CreateServer()
        {
            ServerHandler serverHandler = new ServerHandler( "127.0.0.1" , 1234 );
        }
    }
}
