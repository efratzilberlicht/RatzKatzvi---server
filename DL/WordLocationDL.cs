using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RatzKatzvi.Models;
namespace DL
{
    public static class WordLocationDL
    {
        //Add
        public static void Add(WordLocation wordLocation)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    WordLocation oldWordLocation = db.WordLocation.Where(w => (w.SearchId == wordLocation.SearchId || w.SubjectId == wordLocation.SubjectId) && w.BookSenteceID == wordLocation.BookSenteceID).FirstOrDefault();
                    if (oldWordLocation == null)
                    {
                        db.WordLocation.Add(wordLocation);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
        //Add List
        public static void AddList(List<WordLocation> wordLocations)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                foreach (var wordLocation in wordLocations)
                {
                    WordLocation isExist = db.WordLocation.FirstOrDefault(w => (w.SearchId == wordLocation.SearchId || w.SubjectId == wordLocation.SubjectId) && w.BookSenteceID == wordLocation.BookSenteceID);
                    if (isExist == null)
                    {
                        try
                        {
                           // db.Entry(wordLocation).GetDatabaseValues();
                            var x=  db.WordLocation.Add(wordLocation);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }

            }

        }
        //Create WordLocation from BookPage
        public static WordLocation CreateWordLocationFromBooPage(BookPages bookPages, int? searchID = null, int? subjectID = null)
        {
            return new WordLocation { BookSenteceID = bookPages.ID, SubjectId = subjectID, SearchId = searchID };
        }
        //Create list of WordLocation from BookPage
        public static List<WordLocation> Create_List_WordLocationFromBooPage(PreSearches preSearch, List<BookPages> bookPages, int? searchID = null, int? subjectID = null)
        {
            List<WordLocation> wordLocations = new List<WordLocation>();
            foreach (var page in bookPages)
            {
                wordLocations.Add(new WordLocation { SubjectId = subjectID, SearchId = searchID, BookItemId = page.ItemId, BookPage = page.BookPage, BookSenteceID = page.ID, PreSearches = preSearch });
            }
            return wordLocations;
        }
        //Update
        public static void Update(WordLocation wordLocation)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    WordLocation oldWordLocation = db.WordLocation.Where(w => (w.SearchId == wordLocation.SearchId || w.SubjectId == wordLocation.SubjectId) && w.BookSenteceID == wordLocation.BookSenteceID).FirstOrDefault();
                    if (oldWordLocation != null)
                    {
                        db.Entry(wordLocation).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        //Delete
        public static void Delete(WordLocation wordLocation)
        {
            if (wordLocation.ID != 0)
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    try
                    {
                        WordLocation isExist = db.WordLocation.Single(x => x.ID == wordLocation.ID);
                        if (isExist != null)
                        {
                            try
                            {
                                db.WordLocation.Remove(isExist);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex); }
                }
        }
        //Delete list
        public static void DeleteList(List<WordLocation> wordLocations)
        {
            if (wordLocations.Count > 0)
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    List<WordLocation> oldWordLocations = new List<WordLocation>();
                    foreach (var wordLocation in wordLocations)
                    {
                        var isExist = db.WordLocation.FirstOrDefault(w => (w.SearchId == wordLocation.SearchId || w.SubjectId == wordLocation.SubjectId) && w.BookSenteceID == wordLocation.BookSenteceID);
                        if (isExist != null)
                        {
                            oldWordLocations.Add(wordLocation);
                        }
                    }
                    try
                    {
                        db.WordLocation.RemoveRange(oldWordLocations);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
        }
        //GetById
        public static WordLocation GetById(int wordLocationID)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.WordLocation.Where(w => w.ID == wordLocationID).FirstOrDefault();
            }
        }
        //GetAll
        public static List<WordLocation> GetAll()
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.WordLocation.ToList();
            }
        }
    }
}
