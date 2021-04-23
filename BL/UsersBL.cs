using BCrypt.Net;
using BL.Convertors;
using DL;
using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace BL
{
    public static class UsersBL
    {
        //Add
        public static void AddUser(Users1 user)
        {
            Users newUser = UsersConvertor.ConvertToDL(user);
           // string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
           // bool verified = BCrypt.Net.BCrypt.Verify("efrat1245", passwordHash);
            UsersDL.AddUser(newUser);
        }
        //Update
        public static void UpdateUser(Users1 user)
        {
            UsersDL.UpdateUser(UsersConvertor.ConvertToDL(user));
        }
        //Delete האם יש למחוק קודם מהטבלאות שהוא נמצא בהן בקשרי גומלין
        public static void DeleteUser(Users1 user)
        {
            Users newUser = UsersConvertor.ConvertToDL(user);
            UsersDL.DeleteUser(newUser);
        }
        //LogIn1
        //public static Users1 Login1(string userName, string password)
        //{
        //    return UsersConvertor.ConvertToDto(
        //        UsersDL.GetAllUsers().FirstOrDefault(u => u.UserName.Equals(userName) && u.Password.Equals(password)));
        //}
        //LogIn2
        public static Users1 Login(string email,string password)
        {
            return UsersConvertor.ConvertToDto(
                UsersDL.GetAllUsers().FirstOrDefault(u => u.Email.Equals(email) && BCrypt.Net.BCrypt.Verify(password, u.Password)));
        }
        //GetUserById
        public static Users1 GetUserById(int userId)
        {
            return UsersConvertor.ConvertToDto(UsersDL.GetUserById(userId));
        }
        //GeByUserName
        public static Users1 GeByUserName(string userName)
        {
            return UsersConvertor.ConvertToDto(UsersDL.GetAllUsers().FirstOrDefault(u => u.UserName.Equals(userName)));
        }
        //GetAllUsers
        public static List<Users1> GetAllUsers()
        {
            return UsersConvertor.ConvertToListDto(UsersDL.GetAllUsers());
        }    
        public static void SendAnEmail( string Name, string Phone, string Email, string MessageToSend)
        {         
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(Email);
            //change to ratzkatzi
            mail.To.Add("funcakee@gmail.com");
            //Test Mail - 1
            mail.Subject = "פניה מאתר רץ כצבי";
            mail.Body = Name + "\n" + Phone + "\n" + Email + "\n" + MessageToSend;

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("naturalway.m01@gmail.com", "124578nw");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

    }
}



