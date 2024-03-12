namespace Lection07_Reflection
{
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            var obj = new MyClass( ) { I = 123 };
            //преобразование в строку
            string serialized = MySerializer.ObjectToString( obj );
            Console.WriteLine( serialized ); 
            //обратное преобразование для получения значения
            var deserialized = MySerializer.StringToObject<MyClass>( serialized );
            Console.WriteLine( deserialized.I ); 
        }
    }
}
