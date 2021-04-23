using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Convertors
{
    public static class UsersConvertor
    {
        public static Users1 ConvertToDto(Users u)
        {
            return new Users1()
            {
                Id = u.Id,
                Email = u.Email,
                Password = u.Password,
                UserName = u.UserName,
                LastLocation = u.LastLocation,
            };
        }

        public static Users ConvertToDL(Users1 u)
        {
            return new Users()
            {
                Id = u.Id,
                Email = u.Email,
                Password = u.Password,
                UserName = u.UserName,
                LastLocation = u.LastLocation,
            };
        }
        public static List<Users1> ConvertToListDto(List<Users> lst)
        {
            return lst.Select(u => ConvertToDto(u)).ToList();
        }
    }
}
