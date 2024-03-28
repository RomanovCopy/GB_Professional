using Data011;

namespace Server011
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            CreateServer( );
        }

        private static void CreateServer()
        {
            ServerHandler serverHandler = new ServerHandler( 1234 );
        }
    }
}
