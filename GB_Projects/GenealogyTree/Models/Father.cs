using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenealogyTree.Base;
using GenealogyTree.Interfaces;

namespace GenealogyTree.Models
{
    internal class Father : Person, IFather
    {
        public Father(Person mother, Person father, Gender gender, DateTime dateOfBirth, string name, string surname) : 
            base(mother, father, gender, dateOfBirth, name, surname)
        {

        }
    }
}
