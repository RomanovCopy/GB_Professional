using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Calculate(args));
        }


        private static double Calculate(string[] rows)
        {
            string[] operations = { "+", "-", "*", "/" };
            double param1 = 0;
            double param2 = 0;
            double result = 0;
            if (rows.Length == 3)
            {
                if (double.TryParse(rows[0], out param1) && double.TryParse(rows[2], out param2) &&
                    operations.Contains(rows[1]))
                {
                    switch (rows[1])
                    {
                        case "+":
                            {
                                result = param1 + param2;
                                break;
                            }
                        case "-":
                            {
                                result = param1 - param2;
                                break;
                            }
                        case "*":
                            {
                                result = param1 * param2;
                                break;
                            }
                        case "/":
                            {
                                if (param2 != 0)
                                {
                                    result = param1 / param2;
                                }
                                else
                                {
                                    Console.WriteLine("Делить на ноль нельзя.");
                                    result = 0;
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Операция не определена.");
                                result = 0;
                                break;
                            }
                    }
                }
            }
            return result;
        }
    }
}
