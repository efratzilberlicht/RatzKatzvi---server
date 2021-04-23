using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public static class ItemsConvertor
    {
       
        public static Items1 ConvertToDto(Items i)
        {
            if (i != null)
            {
                try
                {
                    return new Items1()
                    {
                        ItemId = i.ItemId,
                        ItemKind = i.ItemKind,
                        ItemName = i.ItemName,
                        CreationDate = i.CreationDate,
                        VisitedCounter = i.VisitedCounter,
                        EnableSearch = i.EnableSearch,
                        ContextUrl = i.ContextUrl,
                        ImgUrl = i.ImgUrl
                    };
                }
                catch
                {
                    return new Items1();
                }
            }
            else return new Items1();
        }

        public static Items ConvertToDL(Items1 i)
        {
            return new Items()
            {
                ItemId = i.ItemId,
                ItemKind = i.ItemKind,
                ItemName = i.ItemName,
                CreationDate = i.CreationDate,
                VisitedCounter = i.VisitedCounter,
                EnableSearch = i.EnableSearch,
                ContextUrl=i.ContextUrl,
                ImgUrl=i.ImgUrl
            };
        }
        public static List<Items1> ConvertToListDto(List<Items> lst)
        {
            return lst.Select(k => ConvertToDto(k)).ToList();
        }
        public static List<Items> ConvertToListDL(List<Items1> lst)
        {
            return lst.Select(k => ConvertToDL(k)).ToList();
        }
    }  
}
