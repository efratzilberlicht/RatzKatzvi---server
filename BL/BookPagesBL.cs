using BL.Convertors;
using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL
{
    public static class BookPagesBL
    {
        //Add
        public static void AddBook(List<BookPages1> book)
        {
            List<BookPages> newBook = BookPagesConvertor.ConvertToListDL(book);
            BookPagesDL.AddBook(newBook);
        }


        public static void AddPagesByItem(Items item)
        {
            string url;
            switch (item.ItemKind)
            {
                case (int)EnumItemsKinds.Book:
                    url = HttpContext.Current.Server.MapPath($"~\\Files\\{EnumItemsKinds.Book}\\" + item.ItemName);
                    break;
                case (int)EnumItemsKinds.Lesson:
                    url = HttpContext.Current.Server.MapPath($"~\\Files\\{EnumItemsKinds.Lesson}\\" + item.ItemName);
                    break;
                case (int)EnumItemsKinds.Bookmarks:
                    url = HttpContext.Current.Server.MapPath($"~\\Files\\{EnumItemsKinds.Bookmarks}\\" + item.ItemName);
                    break;
                case (int)EnumItemsKinds.LessonSummary:
                    url = HttpContext.Current.Server.MapPath($"~\\Files\\{EnumItemsKinds.LessonSummary}\\" + item.ItemName);
                    break;
                default: return;
            }
            if (!string.IsNullOrEmpty(url))
            {
                url = url.Replace("\\", "/");
                BookPagesDL.AddPagesByItem(item, url);
            }
        }
        //DeleteBook
        public static void DeleteBook(List<BookPages1> book)
        {

            List<BookPages> newBook = BookPagesConvertor.ConvertToListDL(book);
            BookPagesDL.DeleteBook(newBook);
        }
        public static void DeleteBookByItemId(int ItemId)
        {
            BookPagesDL.DeleteBookByItemId(ItemId);
        }
        //Update
        public static void UpdateBooks(List<BookPages1> book)
        {
            List<BookPages> newBook = BookPagesConvertor.ConvertToListDL(book);
            BookPagesDL.UpdateBook(newBook);
        }
        //GetById
        public static List<BookPages1> GetBookById(int itemId)
        {
            return BookPagesConvertor.ConvertToListDto(BookPagesDL.GetBookByItemId(itemId));
        }
        //TODO
        //GetById
        //public static List<BookPages1> GetBookBySubjectId(List< int> subjectIds)
        //{
        //    return BookPagesConvertor.ConvertToListDto(BookPagesDL.GetBookByItemId(itemId));
        //}
        //GetAll
        public static List<BookPages1> GetAllBooks()
        {
            return BookPagesConvertor.ConvertToListDto(BookPagesDL.GetAllBooks());
        }
        //GetPage
        public static BookPages1 GetPage(int itemId, int page)
        {
            return BookPagesConvertor.ConvertToDto(BookPagesDL.GetPage(itemId, page));
        }

        //GetPage
        public static BookPages1 GetSentencesByBookIDPageIDSentencesID(int bookID, int pageNumber, int sentenceNumber)
        {
            return BookPagesConvertor.ConvertToDto(BookPagesDL.GetSentencesByBookIDPageIDSentencesID(bookID,pageNumber,sentenceNumber));
        }
    }
}
