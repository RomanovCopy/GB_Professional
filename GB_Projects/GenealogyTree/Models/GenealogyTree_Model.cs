using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenealogyTree.Base;
using GenealogyTree.Views;

namespace GenealogyTree.Models
{

    internal class GenealogyTree_Model
    {
        GenealogyTree_View view = new GenealogyTree_View();

        public GenealogyTree_Model()
        {

        }

        internal Person CreatePerson()
        {

            view.Display("Добавление родственника.", true);
            string name = view.Input("Имя :\t");
            string surname = view.Input("Фамилия :\t");


            DateTime birthDay = new DateTime(view.Input("Дата рождения(ДД.ММ.ГГГГ) :\t"));


            string dateString = "2021-09-21";
            DateTime date;
            DateTime.TryParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

            Console.WriteLine(date.ToShortDateString());

        }
    }
}
