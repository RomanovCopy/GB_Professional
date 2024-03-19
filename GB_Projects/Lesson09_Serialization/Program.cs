using System.Text.Json;

namespace Lesson09_Serialization
{
    /*
     * С сайта о погоде была получена информация о текущей и прошлой (за три дня) погоде в виде JSON. 
     * Напишите класс способный хранить представленную информацию.
     * {"Current":{"Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},"History":[{"Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}]}


     */

    /*
     Напишите метод для поиска значений в JSON. В качестве JSON можно использовать JSON из предыдущего примера. 
    Метод должен принимать строку-название ключа и возвращать список найденных значений. 
    Используйте например JsonDocument.Parse
     */
    internal class Program
    {


        static string json = """{"Current":{"Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},"History":[{"Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}]}""";


        static void Main ( string[ ] args )
        {
            var res = ( new JsonParser( ) ).ParseJson( json , "Temperature" );
            foreach(var line in res )
            {
                Console.WriteLine(line);
            }
        }


    }


    public class JsonParser
    {
        private string? _value;

        private List<string> _results = new List<string>( );

        public List<string>ParseJson(string json, string value )
        {
            _value = value;
            var jsonDocument = JsonDocument.Parse( json );
            var root = jsonDocument.RootElement;
            parseElement( root );
            return _results;
        }

        private void parseElement ( JsonElement element , bool save = false)
        {

            switch ( element.ValueKind )
            {
                case JsonValueKind.Object:
                parseObject( element );
                break;
                case JsonValueKind.Array:
                parseArray( element );
                break;
                case JsonValueKind.String:
                parseString( element , save );
                break;
                case JsonValueKind.Number:
                parseNumber( element , save );
                break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                ParseBoolean( element );
                break;
                case JsonValueKind.Null:
                ParseNull( );
                break;
                default:
                throw new NotSupportedException( "Unsupported JSON value kind: " + element.ValueKind );
            }
        }

        private void parseObject(JsonElement element )
        {
            foreach(var el in element.EnumerateObject() )
            {
                Console.WriteLine( $"Property = {el.Name}" );
                bool save = el.Name == _value;
                parseElement( el.Value, save );
            }
        }

        private void parseArray(JsonElement element )
        {
            foreach(var el in element.EnumerateArray( ) )
            {
                parseElement( el );
            }
        }

        private void parseString(JsonElement element, bool save=false )
        {
            if ( save )
            {
                _results.Add( element.GetString( ) );
            }
            Console.WriteLine( $"String = {element.GetString()}");
        }

        private void parseNumber ( JsonElement element , bool save = false )
        {
            if ( save )
            {
                _results.Add( element.GetRawText( ) );
            }
            Console.WriteLine( $"Number = {element.GetRawText( )}" );
        }

        private void ParseBoolean ( JsonElement element )
        {
            Console.WriteLine( "Boolean value: " + element.GetBoolean( ) );
        }

        private void ParseNull ( )
        {
            Console.WriteLine( "Null value" );
        }



    }

    public class WeatherInfo
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public int Weathercode { get; set; }
        public double Windspeed { get; set; }
        public int Winddirection { get; set; }
    }

    public class WeatherData
    {
        public WeatherInfo Current { get; set; }
        public List<WeatherInfo> History { get; set; }
    }




}
