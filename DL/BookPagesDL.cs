//using iTextSharp.text.pdf.parser;
//using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using BitMiracle.Docotic.Pdf;
using GemBox.Document;

namespace DL
{
    public static class BookPagesDL
    {
        //Add
        public static void AddBook(List<BookPages> book)
        {
            List<BookPages> isExistBook = GetBookByItemId(book[0].ItemId);
            if (isExistBook == null || isExistBook.Count() == 0)
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    try
                    {
                        db.BookPages.AddRange(book);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    db.SaveChanges();
                }
        }
        public static void AddPagesByItem(Items item, string url)
        {
            List<BookPages> book = new List<BookPages>();
            if (Path.GetExtension(url).ToLower() == ".pdf")
                book = ConvertPDFToObject(url, item.ItemId);
            else
            {
                if (Path.GetExtension(url).ToLower() == ".docx"|| Path.GetExtension(url).ToLower() == ".doc")
                {
                    book = ConvertDOCXToObject(url, item.ItemId);
                }
            }
            AddBook(book);
            SearchesDL.SearchOldPreSearchesInNewFile(book);
        }
        //Update
        public static void UpdateBook(List<BookPages> book)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    List<BookPages> isExistBook = GetBookByItemId(book.First().ItemId);
                    if (isExistBook != null)
                    {
                        foreach (var page in isExistBook)
                        {
                            try
                            {
                                db.BookPages.AddOrUpdate(page);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                throw;
                            }
                        }
                        db.SaveChanges();
                    }
                }
                catch (Exception ex) { }
            }
        }
        //DeleteByItemId
        public static void DeleteBookByItemId(int ItemId)
        {
            List<BookPages> book = GetBookByItemId(ItemId);
            DeleteBook(book);
        }
        //DeleteBook
        public static void DeleteBook(List<BookPages> book)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                foreach (var page in book)
                {
                    try
                    {
                        db.Entry(page).State = EntityState.Modified;
                        db.BookPages.Remove(page);

                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
                db.SaveChanges();
            }
        }
        //GetById  
        //public static List<BookPages> GetBookBySubjectIdOrPresearchId(List<int> subjectIds, List<int> presearchIds)
        //{
        //    using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
        //    {
        //        return db.BookPages.Where(i => subjectIds.Contains(i. ?? 0) || presearchIds.Contains(i.SearchId ?? 0)).OrderBy(book=>book.SubjectId).ThenBy(book=>book.SearchId).ToList();
        //    }
        //}
        //GetById    
        public static List<BookPages> GetBookByItemId(int itemId)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.BookPages.Where(i => i.ItemId == itemId).ToList();
            }
        }
        //GetAll
        public static List<BookPages> GetAllBooks()
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.BookPages.ToList();
            }
        }
        //GetPage
        public static BookPages GetPage(int itemId, int page)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    return db.BookPages.Find(itemId, page);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
        }
        //GetSentencesByBookIDPageIDSentencesID
        public static BookPages GetSentencesByBookIDPageIDSentencesID(int bookID, int pageNumber, int sentenceNumber)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    var item= db.BookPages.FirstOrDefault(sentence=>sentence.BookPage==pageNumber&&sentence.ID==sentenceNumber&&sentence.ItemId==bookID);
                    return item;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
        }
        //ConvertDocxToStringArray  
        private static List<BookPages> ConvertDOCXToObject(string url, int itemId)
        {
            List<BookPages> book = new List<BookPages>();
            try
            {
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                DocumentModel document=new DocumentModel();
                // Load a document from a Stream contained in FileUpload control.
                if (Path.GetExtension(url) == ".docx")
                {
                    document = DocumentModel.Load(new MemoryStream(File.ReadAllBytes(url)), LoadOptions.DocxDefault);

                }
                else if (Path.GetExtension(url) == ".doc")
                {
                    document = DocumentModel.Load(new MemoryStream(File.ReadAllBytes(url)), LoadOptions.DocDefault);
                }

                // Initialize new StringBuilder.
                var sb = new StringBuilder();

                // Iterate over all paragraphs in the document and append new line to StringBuilder.
                foreach (Paragraph paragraph in document.GetChildElements(true, ElementType.Paragraph))
                {
                    // Iterate over all text elements in the parent paragraph and append its text to StringBuilder.
                    foreach (Run run in paragraph.GetChildElements(true, ElementType.Run))
                        sb.Append(run.Text);
                    sb.AppendLine();
                }
                string[] senteces = sb.ToString().Split('.');
                foreach (var item in senteces.Select((value, i) => new { i, value }))
                {
                    if (!string.IsNullOrEmpty(item.value))
                    {
                        book.Add(new BookPages { BookPage = 0, ItemId = itemId, Sentence = item.i, Text = item.value });
                    }
                }
            }
            catch (Exception ex)
            {
                // return ex.ToString();
            }
            return book;
        }
        //ConvertPdftoStringArray  
        private static List<BookPages> ConvertPDFToObject(string url, int itemId)
        {
            List<BookPages> book = new List<BookPages>();
            using (var pdf = new PdfDocument(url))
            {
                for (int i = 0; i < pdf.PageCount; ++i)
                {
                    string pageText = pdf.Pages[i].GetTextWithFormatting();
                    var reversed = Reverse(pageText, i, itemId);
                    book.AddRange(reversed);
                }
            }
            return book;
        }
        private static List<BookPages> Reverse(string s, int page, int itemId)
        {
            List<BookPages> pageSenteces = new List<BookPages>();
            if (s != "")
            {
                string[] st = s.Split('.');
                for (int i = 0; i < st.Length; i++)
                {
                    char[] charArray = st[i].ToCharArray();
                    Array.Reverse(charArray);
                    string correctLine = new string(charArray);
                    int charCode = 175;
                    bool containChar = false;
                    while (charCode < 238 && !containChar)
                    {
                        if (correctLine.Contains((char)charCode))
                        {
                            containChar = true;
                        }
                        charCode++;
                    }
                    if (containChar)
                    {

                        Encoding latinEncoding = Encoding.GetEncoding("Windows-1252");
                        Encoding hebrewEncoding = Encoding.GetEncoding("Windows-1255");
                        byte[] latinBytes = latinEncoding.GetBytes(correctLine);
                        string hebrewString = hebrewEncoding.GetString(latinBytes);
                        correctLine = hebrewString;
                    }
                    if (!string.IsNullOrEmpty(correctLine) || correctLine.Trim() != string.Empty)
                    {
                        BookPages obj = new BookPages
                        {
                            BookPage = page,
                            Sentence = i,
                            Text = correctLine,
                            ItemId = itemId
                        };
                        pageSenteces.Add(obj);
                    }
                }
            }
            return pageSenteces;
        }

        public static List<BookPages> SearchText(List<BookPages> book, Regex regex)
        {
            List<BookPages> resultBookPages = new List<BookPages>();
            foreach (BookPages page in book)
            {
                if (regex.IsMatch(page.Text))
                    resultBookPages.Add(page);
            }
            return resultBookPages;

        }
    }
}