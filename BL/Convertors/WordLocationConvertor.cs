using DL;
using Dto;
using System.Collections.Generic;
using System.Linq;

namespace BL.Convertors
{
    public static class WordLocationConvertor
    {
        public static WordLocation1 ConvertToDto(WordLocation w)
        {
            return new WordLocation1()
            {
                BookSenteceID = w.BookSenteceID,
                Counter = w.Counter,
                ID = w.ID,
                SearchId = w.SearchId,
                SubjectId = w.SubjectId,
                BookPage=w.BookPage,
                BookItemID=w.BookItemId
            };
        }
        public static WordLocation ConvertToDL(WordLocation1 w)
        {
            return new WordLocation()
            {
                BookSenteceID = w.BookSenteceID,
                Counter = w.Counter,
                ID = w.ID,
                SearchId = w.SearchId,
                SubjectId = w.SubjectId,
                BookPage = w.BookPage,
                BookItemId = w.BookItemID
            };
        }
        public static List<WordLocation1> ConvertToListDto(List<WordLocation> lst)
        {
            return lst.Select(k => ConvertToDto(k)).ToList();
        }
        public static List<WordLocation> ConvertToListDL(List<WordLocation1> lst)
        {
            return lst.Select(k => ConvertToDL(k)).ToList();
        }

    }
}
