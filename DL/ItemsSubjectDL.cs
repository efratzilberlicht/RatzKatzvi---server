using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DL
{
    public class ItemsSubjectDL
    {
        public static void UpdateItemsSubject(ItemsSubject itemsSubject)
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                db.Entry(itemsSubject).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //GetAll
        public static List<ItemsSubject> GetAllItemsSubject()
        {
            using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
            {
                return db.ItemsSubject.ToList();
            }
        }

        //Delete
        public static void DeleteById(ItemsSubject it)
        {
            if (it != null)
            {
                using (RatzhKatzviEntities1 db = new RatzhKatzviEntities1())
                {
                    db.Entry(it).State = EntityState.Deleted;

                    //db.ItemsSubject.Remove(it);
                    db.SaveChanges();
                }
            }
        }


    }
}
