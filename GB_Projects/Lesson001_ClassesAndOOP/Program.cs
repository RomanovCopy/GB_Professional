using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lesson001_ClassesAndOOP.Models;
using Lesson001_ClassesAndOOP.Services;

namespace Lesson001_ClassesAndOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FamelyMember famelyMember5 = new FamelyMember()
            { Name = "Екатерина", SurName = "Петрова", DateOfBirth = new DateTime(1952, 09, 20), Gender = Gender.Female };//бабушка
            FamelyMember famelyMember6 = new FamelyMember()
            { Name = "Владимир", SurName = "Петров", DateOfBirth = new DateTime(1950, 05, 17), Gender = Gender.Male };//дедушка

            FamelyMember famelyMember7 = new FamelyMember()
            { Name = "Валентина", SurName = "Иванова", DateOfBirth = new DateTime(1955, 04, 20), Gender = Gender.Female };//бабушка
            FamelyMember famelyMember8 = new FamelyMember()
            { Name = "Максим", SurName = "Иванов", DateOfBirth = new DateTime(1954, 03, 17), Gender = Gender.Male };//дедушка

            FamelyMember famelyMember1 = new FamelyMember() 
            { Name="Иван", SurName="Иванов", DateOfBirth=new DateTime(1989,12,25), Gender=Gender.Male, Mother=famelyMember7, Father=famelyMember8 };//отец
            FamelyMember famelyMember2 = new FamelyMember()
            { Name = "Мария", SurName = "Иванова", DateOfBirth = new DateTime(1992, 10, 15), Gender=Gender.Female, Mother=famelyMember5, Father=famelyMember6 };//мать

            var famelyMember3 = new FamelyMember()
            { Name = "Алексей", SurName = "Иванов", DateOfBirth = new DateTime(2020, 10, 15), Gender=Gender.Male, Mother=famelyMember2, Father=famelyMember1 };//сын
            var famelyMember4 = new FamelyMember()
            { Name = "Мария", SurName = "Иванова", DateOfBirth = new DateTime(1992, 10, 15),Gender=Gender.Female, Mother=famelyMember2, Father=famelyMember1 };//дочь



            var service = new FamelyMemberService();
            service.AddPerson(famelyMember8,famelyMember7,famelyMember6,famelyMember5,famelyMember4,famelyMember3,famelyMember2, famelyMember1);



            foreach(var member in service.GetGrandFathers(famelyMember3))
            {
                Console.Write(member);
            }
            Console.WriteLine();
            Console.WriteLine( service.OldFamelyMember());

        }



    }
}
