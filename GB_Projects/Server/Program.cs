namespace Data
{
    internal class Program
    {
        static void Main (  )
        {
            Console.WriteLine( "Сервер ожидает сообщение от Client..." );

            ServerHandler serverHandler = new( 1234 );

            while ( true )
            {
                serverHandler.AwaitMessage( );
            }
        }
    }
}
