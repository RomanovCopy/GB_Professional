using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator_v02
{
    internal partial class Calculator
    {
        private readonly string Simbols = "0123456789+-*/,. ";

        //делегаты для выполнения операций
        private delegate decimal Function ( decimal val1 , decimal val2 );
        private readonly Function Addition;
        private readonly Function Subtraction;
        private readonly Function Multiplication;
        private readonly Function Division;


        private string Line { get; set; } = "";
        public Calculator ( )
        {
            Addition = ( v1 , v2 ) => v1 + v2;
            Subtraction = ( v1 , v2 ) => v1 - v2;
            Multiplication = ( v1 , v2 ) => v1 * v2;
            Division = ( v1 , v2 ) =>
            {
                if ( v2 == 0 )
                {
                    Console.Write( "  Ошибка!!! Деление на " );
                    return 0;
                } else
                {
                    return v1 / v2;
                }
            };
            //создаем и подписываемся на событие ввода символа
            KeyPressEventHandler handler = new( );
            handler.KeyPressed += Handler_KeyPressed;
            handler.WaitingForInput( );
        }

        /// <summary>
        /// обработка события ввода символа и формирование строки
        /// </summary>
        /// <param name="sender">источник события</param>
        /// <param name="e">информация о вводе</param>
        private void Handler_KeyPressed ( object? sender , KeyPressEventArgs e )
        {
            char key = e.KeyInfo.KeyChar;
            if ( Simbols.Contains( key ) )
            {//ввод числа
                Line += key;
                Console.Write( key );
            } else if ( e.KeyInfo.Key == ConsoleKey.Backspace )
            {//выполнение Backspace
                if ( Line.Length > 0 )
                {
                    Line = Line[ ..^1 ];
                    Console.Write( "\b \b" );
                }
            } else if ( key == '=' )
            {//вычисление и вывод результата
                Output( );
                Line = "";
            }
        }

        /// <summary>
        /// обработка полученной строки
        /// </summary>
        /// <param name="line">введенная строка</param>
        /// <returns></returns>
        private decimal Calculate ( string line )
        {
            if ( ParseStringToDecimals(line, out decimal val1, out decimal val2, out string lastOperator) )
            {
                switch ( lastOperator )
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
            } else
            {
                Console.WriteLine( "Ошибка ввода. Повторите." );
            }
            return 0;
        }

        /// <summary>
        /// парсинг введенной строки
        /// </summary>
        /// <param name="line">введенная строка</param>
        /// <param name="val1">возврат выделенного первого числа</param>
        /// <param name="val2">возврат выделенного второго числа</param>
        /// <param name="lastOperator">возврат символа оператора</param>
        /// <returns>результат выполнения: True - выполнено без ошибок; False - выполнено с ошибкой</returns>
        private bool ParseStringToDecimals(string line, out decimal val1, out decimal val2, out string lastOperator )
        {
            val1 = val2 = 0;
            lastOperator = "+";
            bool firstValue = true;
            bool isNegative = false;
            string[]numbers = Regex.Split( line , @"([-+*/])" );
            foreach (var ch in numbers )
            {
                if ( ch == "-" || ch == "+" || ch=="")
                {
                    lastOperator = lastOperator != "*" && lastOperator != "/" ? ch : lastOperator;
                    if ( ch == "-" )
                    {
                        isNegative = true;
                    }
                    continue;
                }else if ( ch == "*" || ch == "/" )
                {
                    lastOperator = ch;
                    continue;
                }
                if ( firstValue )
                {
                    if ( decimal.TryParse( ch , out val1 ) )
                    {
                        val1 *= isNegative ? -1 : 1;
                        firstValue = isNegative = false;
                    } else
                        return false;
                } else
                {
                    if ( decimal.TryParse( ch , out val2 ) )
                    {
                        val2 *= isNegative ? -1 : 1;
                        firstValue = true;
                        isNegative = false;
                    } else
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// вывод в консоль
        /// </summary>
        private void Output ( )
        {
            Console.Write( $" = {Calculate( Line )} " );
            Console.WriteLine( );
        }

    }
}
