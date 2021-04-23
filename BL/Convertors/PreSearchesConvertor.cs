using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public static class PreSearchesConvertor
    {
        public static PreSerches1 ConvertToDto(PreSearches p)
        {
            if (p != null)
                return new PreSerches1()
                {
                    PreSearch = p.PreSearch,
                    SearchedCounter = p.SearchedCounter,
                    Id = p.Id
                    //ItemId = p.ItemId,
                    //Counter = p.Counter
                };
            return new PreSerches1();
        }

        public static PreSearches ConvertToDL(PreSerches1 p)
        {
            if (p != null)
                return new PreSearches()
                {
                    PreSearch = p.PreSearch,
                    SearchedCounter = p.SearchedCounter,
                    Id = p.Id
                };
            return new PreSearches();
        }
        public static List<PreSerches1> ConvertToListDto(List<PreSearches> lst)
        {
            return lst.Select(p => ConvertToDto(p)).ToList();
        }


    }
}
