using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public static class LastLocationConvertor
    {
        
        public static LastLocation1 ConvertToDto(LastLocation l)
        {
            return new LastLocation1()
                {
                Id=l.Id,
                UserId = l.UserId,
                LastLocation = l.LastLocation1,
                Date = l.Date
            };     
        }

        public static LastLocation ConvertToDL(LastLocation1 l)
        {
            return new LastLocation()
            {
                Id = l.Id,
                UserId = l.UserId,
                LastLocation1 = l.LastLocation,
                Date = l.Date
            };
        }

        public static List<LastLocation1> ConvertToListDto(List<LastLocation> lst)
        {
            return lst.Select(l => ConvertToDto(l)).ToList();
        }
    }
}
