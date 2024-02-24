using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02_InterfacesAndGeneralizations
{
    internal class Bits : IBits
    {
        public long Value { get; private set; } = 0;
        private int size = 0;

        public Bits ( long value )
        {
            Value = value;
            size = sizeof( long ) * 8; //определяем количество бит в переданном числе
        }

        // Получение бита по индексу
        public bool GetBits ( int index )
        {
            return this[ index ];
        }

        // Установка бита по индексу
        public void SetBits ( bool value , int index )
        {
            this[ index ] = value;
        }

        // Индексатор способный работать с любым количеством бит( < 65 )
        public bool this[ int index ]
        {
            get
            {
                if ( index < size && index >= 0 )
                {
                    return ( Value & ( 1L << index ) ) != 0;
                }
                return false;
            }
            set
            {
                if ( index < size && index >= 0 )
                {
                    if ( value )
                    {
                        Value |= ( 1L << index );
                    } else
                    {
                        Value &= ~( 1L << index );
                    }
                } else
                    return; 
            }
        }

         // Явное приведение long к Bits
       public static explicit operator Bits ( long value ) => new Bits( value );
        // Явное приведение int к Bits
        public static explicit operator Bits ( int value ) => new Bits( value );
        // Явное приведение byte к Bits
        public static explicit operator Bits ( byte value ) => new Bits( value );
        // Неявное приведение Bits к long
        public static implicit operator long ( Bits bits ) => bits.Value;
        // Неявное приведение Bits к int
        public static implicit operator int ( Bits bits ) => ( int )bits.Value;
        // Неявное приведение Bits к byte
        public static implicit operator byte ( Bits bits ) => ( byte )bits.Value;

        //переопределенный метод для вывода значений
        //с удалением незначащих нулей
        public override string ToString ( ) => Convert.ToString( Value , 2 );
    }
}
