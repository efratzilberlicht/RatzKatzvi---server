using BL.Convertors;
using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ItemsSubjectBL
    {
        //Update
        public static void UpdateItemsSubject(ItemsSubject1 itemS)
        {
            ItemsSubjectDL.UpdateItemsSubject(ItemsSubjectConvertor.ConvertToDL(itemS));
        }

        //DeleteByItemId
        public static void DeleteItemsSubjectByItemId(int ItemId)
        {
            List<ItemsSubject> lst = new List<ItemsSubject>(ItemsSubjectDL.GetAllItemsSubject());
            if (lst.Count > 0)
                ItemsSubjectDL.DeleteById(lst.Where(it => it.ItemId.Equals(ItemId)).FirstOrDefault());
        }

        //DeleteBySubjectId
        public static void DeleteItemsSubjectBySubjectId(int subjectId)
        {
            List<ItemsSubject> lst = new List<ItemsSubject>(ItemsSubjectDL.GetAllItemsSubject());
            if (lst != null && lst.Count != 0)
                ItemsSubjectDL.DeleteById(lst.Where(it => it.SubjectId.Equals(subjectId)).FirstOrDefault());
        }
    }
}
