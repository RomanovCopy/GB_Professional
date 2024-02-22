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
            FamilyMember familyMember5 = new FamilyMember()
            { Name = "Екатерина", SurName = "Петрова", DateOfBirth = new DateTime(1952, 09, 20), 
                Gender = Gender.Female };//бабушка

            FamilyMember familyMember6 = new FamilyMember()
            { Name = "Владимир", SurName = "Петров", DateOfBirth = new DateTime(1950, 05, 17), 
                Gender = Gender.Male };//дедушка

            FamilyMember familyMember7 = new FamilyMember()
            { Name = "Валентина", SurName = "Иванова", DateOfBirth = new DateTime(1955, 04, 20), 
                Gender = Gender.Female };//бабушка

            FamilyMember familyMember8 = new FamilyMember()
            { Name = "Максим", SurName = "Иванов", DateOfBirth = new DateTime(1954, 03, 17), 
                Gender = Gender.Male };//дедушка

            FamilyMember familyMember1 = new FamilyMember() 
            { Name="Иван", SurName="Иванов", DateOfBirth=new DateTime(1989,12,25), 
                Gender=Gender.Male, Mother=familyMember7, Father=familyMember8 };//отец

            FamilyMember familyMember2 = new FamilyMember()
            { Name = "Мария", SurName = "Иванова", DateOfBirth = new DateTime(1992, 10, 15), 
                Gender=Gender.Female, Mother=familyMember5, Father=familyMember6 };//мать

            var familyMember3 = new FamilyMember()
            { Name = "Алексей", SurName = "Иванов", DateOfBirth = new DateTime(2020, 10, 15), 
                Gender=Gender.Male, Mother=familyMember2, Father=familyMember1 };//сын

            var familyMember4 = new FamilyMember()
            { Name = "Мария", SurName = "Иванова", DateOfBirth = new DateTime(1992, 10, 15),
                Gender=Gender.Female, Mother=familyMember2, Father=familyMember1 };//дочь



            var service = new FamilyMemberService();
            service.AddPerson(familyMember8,familyMember7,familyMember6,familyMember5,familyMember4,familyMember3,familyMember2, familyMember1);



            foreach(var member in service.GetGrandFathers(familyMember3))
            {
                Console.Write(member);
            }
            Console.WriteLine();
            Console.WriteLine( service.OldFamelyMember());

        }



    }
}
