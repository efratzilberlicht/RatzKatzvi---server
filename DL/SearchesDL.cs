using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DL
{
    public static class SearchesDL
    {
        public static List<BookPages> SearchInBooks(string text)
        {
            if (text.Length > 0)
            {
                string[] searchWords = text.Split(' ');
                string newRgxText = ".*";
                foreach (var word in searchWords)
                    newRgxText += word + "(.*)";
                var rgx = new Regex(newRgxText);

                List<Items> items = ItemsDL.GetAllItems().Where(item => true == item.EnableSearch).ToList();
                List<BookPages> bookPages = new List<BookPages>();
                List<BookPages> searchResultBookPages = new List<BookPages>();
                List<WordLocation> searchResultWordLocations = new List<WordLocation>();
                bool flag = false;
                PreSearches newPreSearch = new PreSearches();
                foreach (var item in items)
                {
                    bookPages = BookPagesDL.GetBookByItemId(item.ItemId);
                    bookPages = BookPagesDL.SearchText(bookPages, rgx);
                    if (!flag)
                    {
                        flag = true;
                        newPreSearch = PreSearchesDL.AddPreSerch(new PreSearches { PreSearch = text, SearchedCounter = 1 });
                    }
                    if (bookPages.Count > 0 && newPreSearch != default(PreSearches))
                    {
                        searchResultBookPages.AddRange(bookPages);
                        searchResultWordLocations.AddRange(WordLocationDL.Create_List_WordLocationFromBooPage(newPreSearch, bookPages, newPreSearch.Id));
                    }
                }
                if (searchResultWordLocations != default(List<WordLocation>))
                    WordLocationDL.AddList(searchResultWordLocations);
                return searchResultBookPages;
            }
            return new List<BookPages>();
        }

        public static void SearchOldPreSearchesInNewFile(List<BookPages> bookPages)
        {
            List<PreSearches> preSearches = PreSearchesDL.GetAllPreSerches();
            List<WordLocation> wordLocationsResult = new List<WordLocation>();
            foreach (var preSearch in preSearches)
            {
                string[] searchWords = preSearch.PreSearch.Split(' ');
                string newRgxText = ".*";
                foreach (var word in searchWords)
                    newRgxText += word + "(.*)";
                var rgx = new Regex(newRgxText);
                foreach (var page in bookPages)
                {
                    if (rgx.IsMatch(page.Text))
                    {
                        //TODO
                        //how to know if and which subjectID and searchID
                        wordLocationsResult.Add(new WordLocation { BookSenteceID = page.Sentence, PreSearches = preSearch, BookItemId = page.ItemId, BookPage = page.BookPage });
                    }
                }
            }
            WordLocationDL.AddList(wordLocationsResult);
        }
    }
}

