using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public static class KindsConvertor
    {
        public static Kinds1 ConvertToDto(Kinds k)
        {
            return new Kinds1()
            {
                IdKind = k.IdKind,
                Kind = k.Kind
            };
        }

        public static Kinds ConvertToDL(Kinds1 k)
        {
            return new Kinds()
            {
                IdKind = k.IdKind,
                Kind = k.Kind
            };
        }
        public static List<Kinds1> ConvertToListDto(List<Kinds> lst)
        {
            return lst.Select(k => ConvertToDto(k)).ToList();
        }
    }

}
