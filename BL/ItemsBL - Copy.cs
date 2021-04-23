
        //public static List<Items1> GetItemsBySubjectIdAndKind(int subjectId, int kindId)
        //{
        //    List<Items> lst = new List<Items>(ItemsDL.GetAllItems());
        //    List<Items1> s = new List<Items1>();
        //    try
        //    {
        //        List<ItemsSubject> itemsSubjectList = new List<ItemsSubject>() { new ItemsSubject { code=1, SubjectId=1, ItemId=17}, new ItemsSubject {code=2, SubjectId=51, ItemId=26 } }; //ItemsSubjectDL.GetAllItemsSubject();
        //        List<Items> lst_new = new List<Items>();
        //        foreach (var item in lst)
        //        {
        //            if (item.ItemKind == kindId)
        //            {
        //                List<ItemsSubject> subjectsForItem = new List<ItemsSubject>();
        //                int i = 0;
        //                while (subjectsForItem.Count() == 0 && i < itemsSubjectList.Count())
        //                {
        //                    if (itemsSubjectList[i].SubjectId == subjectId&& itemsSubjectList[i].ItemId==item.ItemId)
        //                    {
        //                        subjectsForItem.Add(itemsSubjectList[i]);
        //                    }
        //                    i++;
        //                }
        //                if (subjectsForItem.Count() > 0)
        //                {
        //                    lst_new.Add(item);
        //                }
        //            }
        //        }
        //        s = ItemsConvertor.ConvertToListDto(lst_new);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return s;
        //}
       
    


