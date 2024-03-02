using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_v02
{
    internal class Calculator
    {
        private readonly string Simbols = "0123456789+-*,. ";

        private delegate decimal Function ( decimal val1 , decimal val2 );

        private readonly Function Addition;
        private readonly Function Subtraction;
        private readonly Function Multiplication;
        private readonly Function Division;

        private string Line { get; set; } = "";
        private bool Negative { get; set; } = false;

        public Calculator ( )
        {
            Addition = ( v1 , v2 ) => v1 + v2;
            Subtraction = ( v1 , v2 ) => v1 - v2;
            Multiplication = ( v1 , v2 ) => v1 * v2;
            Division = ( v1 , v2 ) => ( v2 != 0 ) ? v1 / v2 : 0;
            KeyPressEventHandler handler = new( );
            handler.KeyPressed += Handler_KeyPressed;
            handler.WaitingForInput( );
        }

        private void Handler_KeyPressed ( object? sender , KeyPressEventArgs e )
        {
            char key = e.KeyInfo.KeyChar;
            if ( Simbols.Contains( key ) )
            {
                Line += key;
                Console.Write( key );
            } else if ( e.KeyInfo.Key == ConsoleKey.Backspace )
            {
                if ( Line.Length > 0 )
                {
                    Line = Line[ ..^1 ];
                    Console.Write( "\b \b" );
                }
            } else if ( key == '=' )
            {
                Output( );
                Line = "";
            }
        }

        private decimal Calculate ( string line )
        {
            line = line.Trim( ).TrimEnd( '=' ).Replace( '.' , ',' );
            string[ ] numb = line.Split( '+' , '-' , '*' , '/' );
            Negative = numb[ 0 ] == "" && numb[ 2 ] != "" || numb[ 0 ] != "" && numb[ 1 ] == "" || numb[ 0 ] == "" && numb[ 2 ] == "";
            string[ ] numbers = new string[ 2 ];
            int numCount = 0;
            for ( int i = 0 ; i < numb.Length && numCount<2; i++ )
            {
                if ( numb[i]!="" )
                {
                    numbers[ numCount ] = numb[ i ];
                    numCount++;
                }
            }
            if ( decimal.TryParse( numbers[ 0 ] , out decimal val1 ) && decimal.TryParse( numbers[ 1 ] , out decimal val2 ) )
            {
                line = line.Replace( val1.ToString( ) , "" ).Replace( val2.ToString( ) , "" ).Trim( );
                line = line.Length == 1 ? line : line[ 1 ].ToString( );
                if ( Negative )
                {
                    if ( val1 >= val2 )
                        val1 *= -1;
                    else
                        val2 *= -1;
                }
                switch ( line )
                {
                    case "+":
                    return Addition( val1 , val2 );
                    case "-":
                    return Subtraction( val1 , val2 );
                    case "*":
                    return Multiplication( val1 , val2 );
                    case "/":
                    return Division( val1 , val2 );
                }
            }
            return 0;
        }

        private void Output ( )
        {
            Console.Write( $" = {Calculate( Line )} " );
            Console.WriteLine( );
        }

    }
}
