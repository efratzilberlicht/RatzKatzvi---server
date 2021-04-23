using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public static class BookPagesConvertor
    {
        public static BookPages1 ConvertToDto(BookPages b)
        {
            if (b != null)
            {
                try
                {
                    return new BookPages1()
                    {
                        BookPage = b.BookPage,
                        ItemId = b.ItemId,
                        Text = b.Text,
                        ID=b.ID,
                        Sentence=b.Sentence
                    };
                }
                catch
                {
                    return new BookPages1();
                }
            }
            else return new BookPages1();
        }

        public static BookPages ConvertToDL(BookPages1 b)
        {
            return new BookPages()
            {
                BookPage = b.BookPage,
                ItemId = b.ItemId,
                Text = b.Text,
                ID = b.ID,
                Sentence = b.Sentence
            };
        }
        public static List<BookPages1> ConvertToListDto(List<BookPages> lst)
        {
            return lst.Select(k => ConvertToDto(k)).ToList();
        }

        public static List<BookPages> ConvertToListDL(List<BookPages1> lst)
        {
            return lst.Select(k => ConvertToDL(k)).ToList();
        }
    }
}
