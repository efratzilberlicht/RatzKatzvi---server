using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RatzKatzvi.Models;
namespace DL
{
    public static class KindsDL
    {
        //Add
        public static void AddKind(Kinds kind)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    Kinds oldKind = db.Kinds.Where(k => k.Kind == kind.Kind).FirstOrDefault();
                    if (oldKind == null)
                    {
                        db.Kinds.Add(kind);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
        //Update
        public static void UpdateKind(Kinds kind)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    Kinds oldKind = db.Kinds.Where(k => k.Kind == kind.Kind).FirstOrDefault();
                    if (oldKind != null)
                    {
                        db.Entry(kind).State = EntityState.Modified;
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
        public static void DeleteKind(Kinds kind)
        {
            if (kind?.IdKind != null && kind?.IdKind > 0)
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    try
                    {
                        Kinds isExist = db.Kinds.Single(x => x.IdKind == kind.IdKind);
                        if (isExist != null)
                        {
                            try
                            {
                                db.Kinds.Remove(isExist);
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
        //GetById
        public static Kinds GetKindById(int kind)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.Kinds.Where(k => k.IdKind == kind).FirstOrDefault();
            }
        }
        //GetAll
        public static List<Kinds> GetAllKinds()
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.Kinds.ToList();
            }
        }
    }
}
