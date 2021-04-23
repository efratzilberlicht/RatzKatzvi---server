using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Migrations;

namespace DL
{
    public static class ItemsDL
    {
        //Add
        public static void AddItem(Items item)
        {
            try
            {
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    try { 
                    if (item.CreationDate == default(DateTime))
                        item.CreationDate = DateTime.Now;
                    
                    db.Items.Add(item);
                    db.SaveChanges();
                    }catch(Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        //Update
        public static void UpdateItem(Items item)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    Items isExist = db.Items.FirstOrDefault(x => x.ItemId == item.ItemId);
                    if (isExist != null)
                    {
                        //db.Entry(item).State = EntityState.Modified;
                        db.Items.AddOrUpdate(item);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex) { }
            }
        }
        public static void DeleteItem(int id)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                Items item = GetItemById(id);
                db.Entry(item).State = EntityState.Modified;
                db.Items.Remove(item);
                db.SaveChanges();
            }
        }
        //Delete
        public static void DeleteItem(Items item)
        {
            if (item?.ItemId != null && item?.ItemId > 0)
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    try
                    {
                        db.Entry(item).State = EntityState.Deleted;
                        db.Items.Remove(item);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

        }
        //GetById
        public static Items GetItemById(int item)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    return db.Items.Where(i => i.ItemId == item).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return new Items();
                }
            }
        }
        //GetAll
        public static List<Items> GetAllItems()
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                try
                {
                    return db.Items.ToList();
                }
                catch (Exception ex)
                {
                    return new List<Items>();
                }
            }
        }

    }
}

