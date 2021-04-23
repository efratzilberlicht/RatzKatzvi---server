using BL.Convertors;
using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class PreSerchesBL
    {
        //Add
        public static void AddPreSerch(PreSerches1 pre)
        {
            //קורא לפונקצית חיפוש אם מדובר בשיעור ספר או מאמר  כדי למצוא את המיקום של המילת מפתח

            PreSearches newPre = PreSearchesConvertor.ConvertToDL(pre);
            PreSearchesDL.AddPreSerch(newPre);
        }

        //Update
        public static void UpdatePreSerch(PreSerches1 pre)
        {
            PreSearches newPre = PreSearchesConvertor.ConvertToDL(pre);
            PreSearchesDL.UpdatePreSerches(newPre);
        }

        //Delete 
        public static void DeletePreSerch(PreSerches1 pre)
        {
            PreSearches newPre = PreSearchesConvertor.ConvertToDL(pre);
            PreSearchesDL.DeletePreSerch(newPre);
        }
        //GetById
        public static List<PreSerches1> GetById(int preSercheId)
        {
            List<PreSearches> lst = new List<PreSearches>(PreSearchesDL.GetAllPreSerches());
            return PreSearchesConvertor.ConvertToListDto(lst.Where(k => k.Id == preSercheId).ToList());
        }
        //GetAllPreSerches
        public static List<PreSerches1> GetAllPreSerches()
        {
            return PreSearchesConvertor.ConvertToListDto(PreSearchesDL.GetAllPreSerches());
        }
        //GetWordIdByName
        public static List<PreSerches1> GetWordIdByName(string preSearch)
        {

            List<PreSearches> lst = new List<PreSearches>(PreSearchesDL.GetAllPreSerches());
            return PreSearchesConvertor.ConvertToListDto(lst.Where(p => p.PreSearch.Equals(preSearch)).ToList());
        }
        //GetWordIdByName
        public static List<PreSerches1> GetWordIdContainsName(string preSearch)
        {

            List<PreSearches> lst = new List<PreSearches>(PreSearchesDL.GetAllPreSerches());
            return PreSearchesConvertor.ConvertToListDto(lst.Where(p => p.PreSearch.Contains(preSearch)).ToList());
        }
        //GetAllByItemId
        //public static List<PreSerches1> GetAllByItemId(int itemId)
        //{
        //    List<PreSearches> lst = new List<PreSearches>(PreSearchesDL.GetAllPreSerches());
        //    return PreSearchesConvertor.ConvertToListDto(lst.Where(k => k.ItemId == itemId).ToList());
        //}

    }
}
