using BL.Convertors;
using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BL
{
    public static class ItemsBL
    {
        //Add
        public static void AddItem(Items1 item)
        {
            Items newItem = ItemsConvertor.ConvertToDL(item);
            try
            {
                ItemsDL.AddItem(newItem);
                if (newItem.EnableSearch)
                {
                    BookPagesBL.AddPagesByItem(newItem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //Delete 
        public static void DeleteItem(Items1 item)
        {

            Items newItem = ItemsConvertor.ConvertToDL(item);
            ItemsSubjectBL.DeleteItemsSubjectByItemId(newItem.ItemId);
            //TODO
            //WordsLocationsBL.DeleteWordsLocationsByItemId(newItem.ItemId);
            BookPagesBL.DeleteBookByItemId(newItem.ItemId);

            ItemsDL.DeleteItem(newItem);
        }
        //Update
        public static void UpdateItem(Items1 item)
        {
            Items newItem = ItemsConvertor.ConvertToDL(item);
            ItemsDL.UpdateItem(newItem);
        }
        //GetById
        public static Items1 GetItemById(int item)
        {
            Items1 resItem = ItemsConvertor.ConvertToDto(ItemsDL.GetItemById(item) ?? new Items());
            if (resItem == null || resItem == default(Items1))
                return new Items1();
            EnumItemsKinds kindName = (EnumItemsKinds)Enum.ToObject(typeof(EnumItemsKinds), resItem.ItemKind);
            var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{kindName}";
            if (Directory.Exists(folderpath))
            {
                string[] files = Directory.GetFiles(folderpath);
                var file = files.FirstOrDefault(fl => Path.GetFileName(fl) == resItem.ItemName);
                if (!string.IsNullOrEmpty(file))
                {
                    resItem.ContextUrl = file;
                }
                else
                {
                    resItem.ContextUrl = "";
                }
            }
            if (resItem.ItemKind == (int)EnumItemsKinds.Book || resItem.ItemKind == (int)EnumItemsKinds.Lesson)
            {
                //Image For Item
                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Image}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == resItem.ItemName.Split('.')[0]);
                    if (!string.IsNullOrEmpty(file))
                    {
                        resItem.ImgUrl = file;
                    }
                    else
                    {
                        resItem.ImgUrl = "";
                    }
                }
                if (resItem.ItemKind == (int)EnumItemsKinds.Lesson)
                {
                    //Video For Lesson
                    var Videofolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Video}";
                    if (Directory.Exists(folderpath))
                    {
                        string[] files = Directory.GetFiles(Videofolderpath);
                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == resItem.ItemName.Split('.')[0]);
                        if (!string.IsNullOrEmpty(file))
                        {
                            resItem.Video = file;
                        }
                        else
                        {
                            resItem.Video = "";
                        }
                    }
                    //Summary For Lesson
                    var Summaryfolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.LessonSummary}";
                    if (Directory.Exists(folderpath))
                    {
                        string[] files = Directory.GetFiles(Summaryfolderpath);
                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == resItem.ItemName.Split('.')[0]);
                        if (!string.IsNullOrEmpty(file))
                        {
                            resItem.Summery = FilesBL.GetTextFromFile(EnumItemsKinds.LessonSummary.ToString(), Path.GetFileName(file));
                        }
                        else
                        {
                            resItem.Summery = "";
                        }
                    }
                }
            }
            return resItem;
        }
        //GetByName
        public static Items1 GetItemByName(string item)
        {

            List<Items> lst = new List<Items>(ItemsDL.GetAllItems());
            Items1 resItem = ItemsConvertor.ConvertToDto(lst.Where(i => i.ItemName.Equals(item)).FirstOrDefault() ?? new Items());
            EnumItemsKinds kindName = (EnumItemsKinds)Enum.ToObject(typeof(EnumItemsKinds), resItem.ItemKind);
            var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{kindName}";
            if (Directory.Exists(folderpath))
            {
                string[] files = Directory.GetFiles(folderpath);
                var file = files.FirstOrDefault(fl => Path.GetFileName(fl) == resItem.ItemName);
                if (!string.IsNullOrEmpty(file))
                {
                    resItem.ContextUrl = file;
                }
                else
                {
                    resItem.ContextUrl = "";
                }
            }
            if (resItem.ItemKind == (int)EnumItemsKinds.Book || resItem.ItemKind == (int)EnumItemsKinds.Lesson)
            {
                //Image For Item
                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Image}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == resItem.ItemName.Split('.')[0]);
                    if (!string.IsNullOrEmpty(file))
                    {
                        resItem.ImgUrl = file;
                    }
                    else
                    {
                        resItem.ImgUrl = "";
                    }
                }
                if (resItem.ItemKind == (int)EnumItemsKinds.Lesson)
                {
                    //Video For Lesson
                    var Videofolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Video}";
                    if (Directory.Exists(folderpath))
                    {
                        string[] files = Directory.GetFiles(Videofolderpath);
                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == resItem.ItemName.Split('.')[0]);
                        if (!string.IsNullOrEmpty(file))
                        {
                            resItem.Video = file;
                        }
                        else
                        {
                            resItem.Video = "";
                        }
                    }
                    //Summary For Lesson
                    var Summaryfolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.LessonSummary}";
                    if (Directory.Exists(folderpath))
                    {
                        string[] files = Directory.GetFiles(Summaryfolderpath);
                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == resItem.ItemName.Split('.')[0]);
                        if (!string.IsNullOrEmpty(file))
                        {
                            resItem.Summery = file;
                        }
                        else
                        {
                            resItem.Summery = "";
                        }
                    }
                }
            }
            return resItem;
        }
        //GetAll
        public static List<Items1> GetAllItems()
        {//FIX open summery
            List<Items1> resItems = ItemsConvertor.ConvertToListDto(ItemsDL.GetAllItems());
            foreach (var item in resItems)
            {
                EnumItemsKinds kindName = (EnumItemsKinds)Enum.ToObject(typeof(EnumItemsKinds), item.ItemKind);
                var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{kindName}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileName(fl) == item.ItemName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        item.ContextUrl = file;
                    }
                    else
                    {
                        item.ContextUrl = "";
                    }
                }
                if (item.ItemKind == (int)EnumItemsKinds.Book || item.ItemKind == (int)EnumItemsKinds.Lesson)
                {
                    folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Image}";
                    if (Directory.Exists(folderpath))
                    {
                        string[] files = Directory.GetFiles(folderpath);
                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item.ItemName.Split('.')[0]);
                        if (!string.IsNullOrEmpty(file))
                        {
                            item.ImgUrl = file;
                        }
                        else
                        {
                            item.ImgUrl = "";
                        }
                    }
                    if (item.ItemKind == (int)EnumItemsKinds.Lesson)
                    {
                        //Video For Lesson
                        var Videofolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Video}";
                        if (Directory.Exists(folderpath))
                        {
                            string[] files = Directory.GetFiles(Videofolderpath);
                            var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item.ItemName.Split('.')[0]);
                            if (!string.IsNullOrEmpty(file))
                            {
                                item.Video = file;
                            }
                            else
                            {
                                item.Video = "";
                            }
                        }
                        //Summary For Lesson
                        var Summaryfolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.LessonSummary}";
                        if (Directory.Exists(folderpath))
                        {
                            string[] files = Directory.GetFiles(Summaryfolderpath);
                            var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item.ItemName.Split('.')[0]);
                            if (!string.IsNullOrEmpty(file))
                            {
                                item.Summery = file;
                            }
                            else
                            {
                                item.Summery = "";
                            }
                        }
                    }
                }
            }
            return resItems;
        }
        public static string ConvertItemsToBookPages()
        {
            List<Items> items = ItemsConvertor.ConvertToListDL(GetAllItems().Where(itm => itm.ItemKind == (int)EnumItemsKinds.Book || itm.ItemKind == (int)EnumItemsKinds.Lesson).ToList());
            foreach (var item in items)
            {
                BookPagesBL.AddPagesByItem(item);
            }
            return "ok";
        }

        //GetAllByKind
        public static List<Items1> GetAllVideos(int kindId, int pageNum)
        {
            const int numVideoInPage = 10;
            List<Items> lst = new List<Items>(ItemsDL.GetAllItems());
            lst = lst.Where(i => i.ItemKind == kindId).Skip(numVideoInPage * pageNum).Take(numVideoInPage).ToList();
            foreach (var video in lst)
            {
                EnumItemsKinds kindName = (EnumItemsKinds)Enum.ToObject(typeof(EnumItemsKinds), video.ItemKind);
                var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{kindName}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileName(fl) == video.ItemName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        video.ContextUrl = file;
                    }
                    else
                    {
                        video.ContextUrl = "";
                    }
                }
            }
            return ItemsConvertor.ConvertToListDto(lst);
        }
        //TODO
        public static List<Items1> GetAllByKind(int kindId)
        {//check the order
            List<Items1> lst = ItemsConvertor.ConvertToListDto(ItemsDL.GetAllItems().Where(i => i.ItemKind == kindId).ToList());
            foreach (var item in lst)
            {
                EnumItemsKinds kindName = (EnumItemsKinds)Enum.ToObject(typeof(EnumItemsKinds), item.ItemKind);
                var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{kindName}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileName(fl) == item.ItemName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        item.ContextUrl = file;
                    }
                    else
                    {
                        item.ContextUrl = "";
                    }
                }
                if (item.ItemKind == (int)EnumItemsKinds.Book || item.ItemKind == (int)EnumItemsKinds.Lesson)
                {
                    folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Image}";
                    if (Directory.Exists(folderpath))
                    {
                        string[] files = Directory.GetFiles(folderpath);
                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item.ItemName.Split('.')[0]);
                        if (!string.IsNullOrEmpty(file))
                        {
                            item.ImgUrl = file;
                        }
                        else
                        {
                            item.ImgUrl = "";
                        }
                    }
                    if (item.ItemKind == (int)EnumItemsKinds.Lesson)
                    {
                        //Video For Lesson
                        var Videofolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Video}";
                        if (Directory.Exists(folderpath))
                        {
                            string[] files = Directory.GetFiles(Videofolderpath);
                            var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item.ItemName.Split('.')[0]);
                            if (!string.IsNullOrEmpty(file))
                            {
                                item.Video = file;
                            }
                            else
                            {
                                item.Video = "";
                            }
                        }
                        //Summary For Lesson
                        var Summaryfolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.LessonSummary}";
                        if (Directory.Exists(folderpath))
                        {
                            string[] files = Directory.GetFiles(Summaryfolderpath);
                            var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item.ItemName.Split('.')[0]);
                            if (!string.IsNullOrEmpty(file))
                            {
                                item.Summery = FilesBL.GetTextFromFile(EnumItemsKinds.LessonSummary.ToString(), Path.GetFileName(file));
                            }
                            else
                            {
                                item.Summery = "";
                            }
                        }
                    }
                }
            }
            return lst;
        }
        // GetAllBySubjectId
        public static List<Items1> GetAllBySubjectId(int subjectId)
        {
            List<Items1> lst_result = new List<Items1>();
            try
            {
                List<Items> lst = new List<Items>(ItemsDL.GetAllItems());
                List<ItemsSubject> itemsSubject = ItemsSubjectDL.GetAllItemsSubject();
                foreach (var item in lst)
                {
                    if (itemsSubject.Where(subj => subj.ItemId == item.ItemId && subj.SubjectId == subjectId).Count() > 0)
                    {
                        Items1 item_new = ItemsConvertor.ConvertToDto(item);
                        EnumItemsKinds kindName = (EnumItemsKinds)Enum.ToObject(typeof(EnumItemsKinds), item_new.ItemKind);
                        var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{kindName}";
                        if (Directory.Exists(folderpath))
                        {
                            string[] files = Directory.GetFiles(folderpath);
                            var file = files.FirstOrDefault(fl => Path.GetFileName(fl) == item_new.ItemName);
                            if (!string.IsNullOrEmpty(file))
                            {
                                item_new.ContextUrl = file;
                            }
                            else
                            {
                                item_new.ContextUrl = "";
                            }
                        }
                        if (item_new.ItemKind == (int)EnumItemsKinds.Book || item_new.ItemKind == (int)EnumItemsKinds.Lesson)
                        {
                            //Image For Item
                            folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Image}";
                            if (Directory.Exists(folderpath))
                            {
                                string[] files = Directory.GetFiles(folderpath);
                                var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item_new.ItemName.Split('.')[0]);
                                if (!string.IsNullOrEmpty(file))
                                {
                                    item_new.ImgUrl = file;
                                }
                                else
                                {
                                    item_new.ImgUrl = "";
                                }
                            }
                            if (item_new.ItemKind == (int)EnumItemsKinds.Lesson)
                            {
                                //Video For Lesson
                                var Videofolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Video}";
                                if (Directory.Exists(folderpath))
                                {
                                    string[] files = Directory.GetFiles(Videofolderpath);
                                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item_new.ItemName.Split('.')[0]);
                                    if (!string.IsNullOrEmpty(file))
                                    {
                                        item_new.Video = file;
                                    }
                                    else
                                    {
                                        item_new.Video = "";
                                    }
                                }
                                //Summary For Lesson
                                var Summaryfolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.LessonSummary}";
                                if (Directory.Exists(folderpath))
                                {
                                    string[] files = Directory.GetFiles(Summaryfolderpath);
                                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item_new.ItemName.Split('.')[0]);
                                    if (!string.IsNullOrEmpty(file))
                                    {
                                        item_new.Summery = file;
                                    }
                                    else
                                    {
                                        item_new.Summery = "";
                                    }
                                }
                            }
                            lst_result.Add(item_new);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lst_result;
        }
        //GetItemsForAllSubjects
        public static List<ItemsForSubject> GetItemsForAllSubjects()
        {
            List<Subjects> subjects = SubjectsDL.GetAllSubjects();
            List<ItemsForSubject> itemsForSubjects = new List<ItemsForSubject>();
            foreach (var subject in subjects)
            {
                var result = GetItemsBySubjectId(subject.SubjectId);
                if (!string.IsNullOrEmpty(result.bookmarksPath) || !string.IsNullOrEmpty(result.bookPath) || !string.IsNullOrEmpty(result.imagePath) ||
                    !string.IsNullOrEmpty(result.lessonPath) || !string.IsNullOrEmpty(result.lessonSummary) || !string.IsNullOrEmpty(result.videoPath))
                    itemsForSubjects.Add(result);
            }
            return itemsForSubjects;
        }
        //GetItemsBySubjectId
        public static ItemsForSubject GetItemsBySubjectId(int subjectId)
        {
            try
            {
                ItemsForSubject itemsForSubject = new ItemsForSubject();
                var subjectName = SubjectsDL.GeSubjectById(subjectId).Subject;
                var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Bookmarks}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == subjectName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        itemsForSubject.bookmarksPath = file;
                    }
                }

                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Book}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == subjectName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        itemsForSubject.bookPath = file;
                    }
                }

                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}Image";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == subjectName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        itemsForSubject.imagePath = file;
                    }
                }
                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Lesson}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == subjectName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        itemsForSubject.lessonPath = file;
                    }
                }
                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Video}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == subjectName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        itemsForSubject.videoPath = file;
                    }
                }
                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.LessonSummary}";
                if (Directory.Exists(folderpath))
                {
                    string[] files = Directory.GetFiles(folderpath);
                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == subjectName);
                    if (!string.IsNullOrEmpty(file))
                    {
                        itemsForSubject.lessonSummary = FilesBL.GetTextFromFile(EnumItemsKinds.LessonSummary.ToString(), Path.GetFileName(file));
                    }
                }
                return itemsForSubject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static List<Items1> GetItemsBySubjectIdAndKind(int subjectId, int kindId)
        {//FIX open summery
            List<Items> lst = new List<Items>(ItemsDL.GetAllItems());
            List<Items1> s = new List<Items1>();
            try
            {
                List<ItemsSubject> itemsSubjectList = new List<ItemsSubject>() { new ItemsSubject { code = 1, SubjectId = 1, ItemId = 17 }, new ItemsSubject { code = 2, SubjectId = 51, ItemId = 26 } }; //ItemsSubjectDL.GetAllItemsSubject();
                List<Items1> lst_new = new List<Items1>();
                foreach (var item in lst)
                {
                    if (item.ItemKind == kindId)
                    {
                        List<ItemsSubject> subjectsForItem = new List<ItemsSubject>();
                        int i = 0;
                        while (subjectsForItem.Count() == 0 && i < itemsSubjectList.Count())
                        {
                            if (itemsSubjectList[i].SubjectId == subjectId && itemsSubjectList[i].ItemId == item.ItemId)
                            {
                                subjectsForItem.Add(itemsSubjectList[i]);
                            }
                            i++;
                        }
                        if (subjectsForItem.Count() > 0)
                        {
                            Items1 item_new = ItemsConvertor.ConvertToDto(item);
                            EnumItemsKinds kindName = (EnumItemsKinds)Enum.ToObject(typeof(EnumItemsKinds), item_new.ItemKind);
                            var folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{kindName}";
                            if (Directory.Exists(folderpath))
                            {
                                string[] files = Directory.GetFiles(folderpath);
                                var file = files.FirstOrDefault(fl => Path.GetFileName(fl) == item_new.ItemName);
                                if (!string.IsNullOrEmpty(file))
                                {
                                    item_new.ContextUrl = file;
                                }
                                else
                                {
                                    item_new.ContextUrl = "";
                                }
                            }
                            if (item_new.ItemKind == (int)EnumItemsKinds.Book || item_new.ItemKind == (int)EnumItemsKinds.Lesson)
                            {
                                //Image For Item
                                folderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Image}";
                                if (Directory.Exists(folderpath))
                                {
                                    string[] files = Directory.GetFiles(folderpath);
                                    var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item_new.ItemName.Split('.')[0]);
                                    if (!string.IsNullOrEmpty(file))
                                    {
                                        item_new.ImgUrl = file;
                                    }
                                    else
                                    {
                                        item_new.ImgUrl = "";
                                    }
                                }
                                if (item_new.ItemKind == (int)EnumItemsKinds.Lesson)
                                {//FIX check return video
                                    //Video For Lesson
                                    var Videofolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.Video}";
                                    if (Directory.Exists(folderpath))
                                    {
                                        string[] files = Directory.GetFiles(Videofolderpath);
                                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item_new.ItemName.Split('.')[0]);
                                        if (!string.IsNullOrEmpty(file))
                                        {
                                            item_new.Video = file;
                                        }
                                        else
                                        {
                                            item_new.Video = "";
                                        }
                                    }
                                    //Summary For Lesson
                                    var Summaryfolderpath = $"{HttpContext.Current.Server.MapPath("~/Files/")}{EnumItemsKinds.LessonSummary}";
                                    if (Directory.Exists(folderpath))
                                    {
                                        string[] files = Directory.GetFiles(Summaryfolderpath);
                                        var file = files.FirstOrDefault(fl => Path.GetFileNameWithoutExtension(fl) == item_new.ItemName.Split('.')[0]);
                                        if (!string.IsNullOrEmpty(file))
                                        {
                                            item_new.Summery = file;
                                        }
                                        else
                                        {
                                            item_new.Summery = "";
                                        }
                                    }
                                }
                                lst_new.Add(item_new);
                            }
                        }
                    }
                    s = lst_new;
                }
            }
            catch (Exception ex)
            {

            }
            return s;
        }

    }
}


