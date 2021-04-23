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
    public static class KindsBL
    {
        //Add 
        public static void AddKind(Kinds1 kind)
        {
            KindsDL.AddKind(KindsConvertor.ConvertToDL(kind));
        }
        //Update
        public static void UpdateKind(Kinds1 k)
        {
            KindsDL.UpdateKind(KindsConvertor.ConvertToDL(k));
        }
        //Delete
        public static void DeleteKind(Kinds1 kind)
        {
            //TODO
            //List<Items1> items = ItemsBL.GetAllByKind(kind.IdKind);
            //items.ForEach(x=>ItemsBL.DeleteItem(x));
            KindsDL.DeleteKind(KindsConvertor.ConvertToDL(kind));  
        }
        //GetById
        public static Kinds1 GetKindById(int kind)
        {
            return KindsConvertor.ConvertToDto(KindsDL.GetKindById(kind));
        }
        //GetByName
        public static Kinds1 GetKindByName(string kind)
        {
            List<Kinds> lst= new List<Kinds>(KindsDL.GetAllKinds());
            return KindsConvertor.ConvertToDto(lst.Where(k => k.Kind.Equals(kind)).FirstOrDefault());
        }
        //GetAll
        public static List<Kinds1> GetAllKinds()
        {
            return KindsConvertor.ConvertToListDto(KindsDL.GetAllKinds());
        }

        
  
    }
}
