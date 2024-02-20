using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenealogyTree.Base
{
    internal class Person
    {
        protected string name;
        protected string surName;
        protected DateTime dateOfBirth;
        protected DateTime dateOfDeath;
        protected Gender personGender;
        protected Person father;
        protected Person mother;

        protected Person[] children;


        public string Name { get => name; private set => name = value; }
        public string SurName { get => surName; private set => surName = value; }
        public Gender PersonGender { get => personGender; private set => personGender = value; }
        public DateTime DateOfBirth { get => dateOfBirth; private set => dateOfBirth = value; }
        public DateTime DateOfDeath { get => dateOfDeath; set => dateOfDeath = value; }
        public Person Father { get => father; private set => father = value; }
        public Person Mother { get => mother; private set => mother = value; }
        public Person[] Children { get => children; set => children = value; }



        public Person(Person mother, Person father, Gender gender, DateTime dateOfBirth, string name, string surname  )
        {
            Mother = mother;
            Father = father;
            PersonGender = gender;
            DateOfBirth = dateOfBirth;
        }


    }
}
