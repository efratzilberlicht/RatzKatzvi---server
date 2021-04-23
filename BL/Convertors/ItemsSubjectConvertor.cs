using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Dto;

namespace BL.Convertors
{
    public static class ItemsSubjectConvertor
    {
        public static ItemsSubject ConvertToDL(ItemsSubject1 itS)
        {
            return new ItemsSubject()
            {
               code = itS.code,
                ItemId = itS.ItemId,
               SubjectId = itS.SubjectId
            };
        }
    }
}
