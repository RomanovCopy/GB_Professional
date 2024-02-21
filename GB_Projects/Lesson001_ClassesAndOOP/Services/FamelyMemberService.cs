using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lesson001_ClassesAndOOP.Models;

namespace Lesson001_ClassesAndOOP.Services
{
    internal class FamelyMemberService
    {
        public List<FamelyMember> Famely { get; private set; }


        public FamelyMemberService()
        {
            Famely = new List<FamelyMember>();
        }

        public void AddPerson( params  FamelyMember[] member)
        {
            if (member != null && member.Length>0)
            {
                Famely.AddRange(member);
            }
        }

        public List<FamelyMember> GetGrandFathers(FamelyMember member)
        {
            List<FamelyMember> grandFathers = new List<FamelyMember>();
            grandFathers.Add(member.Mother.Father);
            grandFathers.Add(member.Father.Father);

            return grandFathers;
        }

        public List<FamelyMember> GetGrandMothers(FamelyMember member)
        {
            List<FamelyMember> grandFathers = new List<FamelyMember>();
            grandFathers.Add(member.Mother.Mother);
            grandFathers.Add(member.Father.Mother);

            return grandFathers;
        }


        public FamelyMember OldFamelyMember()
        {
            var data = Famely.Min(x => x.DateOfBirth);
            return Famely.LastOrDefault(x=>x.DateOfBirth==data);
        }




    }
}
