using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenealogyTree.Base;

namespace GenealogyTree.Views
{
    internal class GenealogyTree_View
    {
        public GenealogyTree_View()
        {
        }



        /// <summary>
        /// получение строки из консоли
        /// </summary>
        /// <param name="message">сообщение пользователю</param>
        /// <param name="newRow">ввод с новой строки</param>
        /// <returns>введенная строка</returns>
        public String Input(string message, bool newRow = false)
        {
            Console.Write(newRow ? message + "\n" : message);
            return Console.ReadLine();
        }

        /// <summary>
        /// ввывод сообщения без ожидания ввода
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="newRow">переход на новую строку</param>
        public void Display(string message, bool newRow = false)
        {
            Console.Write(newRow ? message + "\n" : message);
        }


        public void DisplayTab(Person[] persons, string message )
        {
            string[] headers = { "Surname", "Name", "Gender", "Date of birth" };
            Console.WriteLine(message);
            Console.WriteLine(string.Join(" \t! ", headers));
            Console.WriteLine(new string('-', 30));
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }




    }
}
