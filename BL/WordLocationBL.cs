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
    public static class WordLocationBL
    {
        //AddList
        public static void AddList(List<WordLocation1> wordLocations)
        {
            WordLocationDL.AddList(WordLocationConvertor.ConvertToListDL(wordLocations));
        }
        //DeleteList
        public static void DeleteList(List<WordLocation1> wordLocations)
        {
            WordLocationDL.DeleteList(WordLocationConvertor.ConvertToListDL(wordLocations));
        }
        ////GetAll
        public static List<WordLocation1>GetAll()
        {
            return WordLocationConvertor.ConvertToListDto(WordLocationDL.GetAll());
        }






        //public static void DeleteBookByItemId(int ItemId)
        //{
        //    BookPagesDL.DeleteBookByItemId(ItemId);
        //}





        //public static void AddBookByItem(Items item)
        //{
        //    BookPagesDL.AddBookByItem(item);
        //}

        //Update

        //GetById
        //public static List<BookPages1> GetBookById(int itemId)
        //{
        //    return BookPagesConvertor.ConvertToListDto(BookPagesDL.GetBookByItemId(itemId));
        //}
        //GetById
        //public static List<BookPages1> GetBookBySubjectId(List<int> subjectIds)
        //{
        //    return BookPagesConvertor.ConvertToListDto(BookPagesDL.GetBookByItemId(itemId));
        //}

        //GetPage
        //public static BookPages1 GetPage(int itemId, int page)
        //{
        //    return BookPagesConvertor.ConvertToDto(BookPagesDL.GetPage(itemId, page));
        //}
    }
}
