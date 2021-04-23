using DL;
using Dto;
using System.Collections.Generic;
using System.Linq;

namespace BL.Convertors
{
    public static class SubjectsConvertor
    {
        public static Subjects1 ConvertToDto(Subjects s)
        {
            return new Subjects1()
            {
                SubjectId = s.SubjectId,
                Subject = s.Subject,
                SearchedCounter = s.SearchedCounter,
                Parent=s.Parent
            };
        }

        public static Subjects ConvertToDL(Subjects1 s)
        {
            return new Subjects()
            {
                SubjectId = s.SubjectId,
                Subject = s.Subject,
                SearchedCounter = s.SearchedCounter,
                Parent = s.Parent
            };
        }
        
        public static List<Subjects1> ConvertToListDto(List<Subjects> lst)
        {
            return lst.Select(k => ConvertToDto(k)).ToList();
        }

    }
}
