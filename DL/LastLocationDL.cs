using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace DL
{
    public static class LastLocationDL
    {
        //Add
        public static void AddLastLocation(LastLocation l)
        {
            try
            {
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    LastLocation isExist = db.LastLocation.FirstOrDefault(x => x.UserId == l.UserId);
                    if (isExist == null)
                    {
                        db.LastLocation.Add(l);
                        db.SaveChanges();
                    }
                    else
                        UpdateLastLocation(l);
                }
            }
            catch (Exception ex) { }
        }
        //Update
        public static void UpdateLastLocation(LastLocation l)
        {
            try
            {
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    try
                    {
                        LastLocation isExist = db.LastLocation.FirstOrDefault(x => x.UserId == l.UserId);
                        if (isExist != null)
                        {
                            db.LastLocation.AddOrUpdate(l);
                            //db.Entry(l).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //Delete
        public static void DeleteLastLocation(LastLocation l)
        {
            if ( l.Id != 0)
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    try
                    {
                        //LastLocation isExist = db.LastLocation.FirstOrDefault(x => x == l);
                        //db.LastLocation.Remove(isExist);
                        db.Entry(l).State = EntityState.Deleted;
                        db.LastLocation.Remove(l);
                        db.SaveChanges();
                    }
                    catch (Exception ex) { }
                }

        }
        //GetById
        public static LastLocation GetById(int id)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.LastLocation.Where(n => n.Id == id).FirstOrDefault();
            }
        }
        //GetAll
        public static List<LastLocation> GetAllLastLocations()
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                var j = db.LastLocation.ToList();
                return db.LastLocation.ToList();
            }
        }


    }
}

