using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lesson001_ClassesAndOOP.Models;

namespace Lesson001_ClassesAndOOP.Services
{
    internal class FamilyMemberService
    {
        private List<FamilyMember> Family { get; set; }


        public FamilyMemberService()
        {
            Family = new List<FamilyMember>();
        }

        public void AddPerson( params  FamilyMember[] member)
        {
            if (member != null && member.Length>0)
            {
                Family.AddRange(member);
            }
        }

        public List<FamilyMember> GetGrandFathers(FamilyMember member)
        {
            List<FamilyMember> grandFathers = new List<FamilyMember>();
            grandFathers.Add(member.Mother.Father);
            grandFathers.Add(member.Father.Father);

            return grandFathers;
        }

        public List<FamilyMember> GetGrandMothers(FamilyMember member)
        {
            List<FamilyMember> grandFathers = new List<FamilyMember>();
            grandFathers.Add(member.Mother.Mother);
            grandFathers.Add(member.Father.Mother);

            return grandFathers;
        }


        public FamilyMember OldFamilyMember()
        {
            var data = Family.Min(x => x.DateOfBirth);
            return Family.LastOrDefault(x => x.DateOfBirth == data);
        }


        public FamilyMember GetSpouse(FamilyMember member) => member.Spouse;



    }
}
