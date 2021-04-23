using DL;
using Dto;
using BL.Convertors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
     public static class LastLocationBL
    {
        //Add
        public static void AddLastLocation(LastLocation1 lastLocation)
        {
            LastLocation newlastLocation = LastLocationConvertor.ConvertToDL(lastLocation);
            LastLocationDL.AddLastLocation(newlastLocation);
        }

        //Update
        public static void UpdateLastLocation(LastLocation1 l)
        {
            LastLocationDL.UpdateLastLocation(LastLocationConvertor.ConvertToDL(l));
        }
        //Delete האם יש למחוק קודם מהטבלאות שהוא נמצא בהן בקשרי גומלין
        public static void DeleteLastLocation(LastLocation1 lastLocation)
        {
            LastLocation newlastLocation = LastLocationConvertor.ConvertToDL(lastLocation);
            LastLocationDL.DeleteLastLocation(newlastLocation);
        }

        //GetById
        public static LastLocation1 GetLastLocationById(int id)
        {
            return LastLocationConvertor.ConvertToDto(LastLocationDL.GetById(id));
        }
        //GetByUserId
        public static List<LastLocation1> GetByUserId(int userId)
        {
            List<LastLocation> lst = new List<LastLocation>(LastLocationDL.GetAllLastLocations());
            return LastLocationConvertor.ConvertToListDto(lst.Where(u=>u.UserId == userId).ToList());
        }
        //GetByFullDate
        public static List<LastLocation1> GetLastLocationByFullDate(DateTime date)
        {
            List<LastLocation> lst = new List<LastLocation>(LastLocationDL.GetAllLastLocations());
            return LastLocationConvertor.ConvertToListDto(lst.Where(d => d.Date.Equals(date)).ToList());

        }
        //GetByMonth
        public static List<LastLocation1> GetLastLocationByMonth(int m, int y)
        {
            List<LastLocation> lst = new List<LastLocation>(LastLocationDL.GetAllLastLocations());
            return LastLocationConvertor.ConvertToListDto(lst.Where(d => d.Date.Month == m && d.Date.Year == y).ToList());
        }
        //GetByYear
        public static List<LastLocation1> GetLastLocationByYear(int y)
        {
            List<LastLocation> lst = new List<LastLocation>(LastLocationDL.GetAllLastLocations());
            return LastLocationConvertor.ConvertToListDto(lst.Where(d => d.Date.Year == y).ToList());
        }
        //GetAll
        public static List<LastLocation1> GetAllLastLocations()
        {
            return LastLocationConvertor.ConvertToListDto(LastLocationDL.GetAllLastLocations());
        }
    }
}
