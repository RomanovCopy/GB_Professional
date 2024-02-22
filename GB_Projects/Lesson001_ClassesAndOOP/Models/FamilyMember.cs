using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson001_ClassesAndOOP.Models
{
    internal class FamilyMember
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public Gender Gender { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOgDeath { get; set; }


        public override string ToString()
        {
            return $"Имя - {Name}\n Фамилия - {SurName}\n Дата рождения - {DateOfBirth.ToShortDateString()}\n ";
        }
    }
}
