using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02_InterfacesAndGeneralizations
{

    /* Реализуйте операторы неявного приведения из long, int, byt в Bits. */
    internal class Program
    {
        static void Main ( string[ ] args )
        {
            // Создание объекта Bits из long
            Bits bitsFromLong = ( Bits )1234567890123456789L;
            Console.WriteLine( $"Bits from long: {bitsFromLong}" );

            // Преобразование Bits в long
            long valueFromBitsLong = bitsFromLong;
            Console.WriteLine( $"Long value from Bits: {valueFromBitsLong}" );

            // Создание объекта Bits из int
            Bits bitsFromInt = ( Bits )12345;
            Console.WriteLine( $"Bits from int: {bitsFromInt}" );

            // Преобразование Bits в int
            int valueFromBitsInt = bitsFromInt;
            Console.WriteLine( $"Int value from Bits: {valueFromBitsInt}" );

            // Создание объекта Bits из byte
            Bits bitsFromByte = ( Bits )127;
            Console.WriteLine( $"Bits from byte: {bitsFromByte}" );

            // Преобразование Bits в byte
            byte valueFromBitsByte = bitsFromByte;
            Console.WriteLine( $"Byte value from Bits: {valueFromBitsByte}" );

        }
    }
}
