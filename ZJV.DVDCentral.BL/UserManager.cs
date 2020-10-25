using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZJV.DVDCentral.BL.Models;
using ZJV.DVDCentral.PL;

namespace ZJV.DVDCentral.BL
{
    public class UserManager
    {
        private static string GetHash(string passcode)
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(passcode);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }
        public static void Insert(string userid, string firstname, string lastname, string userpass)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser newuser = new tblUser();
                    newuser.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(u => u.Id) + 1 : 1;
                    newuser.Password = GetHash(userpass);
                    newuser.FirstName = firstname;
                    newuser.LastName = lastname;
                    newuser.UserID = userid;


                    dc.tblUsers.Add(newuser);
                    dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Insert(User user)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser newuser = new tblUser();
                    newuser.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(u => u.Id) + 1 : 1;
                    newuser.Password = GetHash(user.PassCode);
                    newuser.UserID = user.UserId;
                    newuser.FirstName = user.FirstName;
                    newuser.LastName = user.LastName;
                    dc.tblUsers.Add(newuser);
                    dc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static void Seed()
        {
            //used to default some data
            User newuser = new User("zjvv", "zach", "vander velden", "birch");
            Insert(newuser);
        }
        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserId))
                {
                    if (!string.IsNullOrEmpty(user.PassCode))
                    {
                        using (DVDCentralEntities dc = new DVDCentralEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.UserID == user.UserId);
                            if (tblUser != null)
                            {
                                //Check password
                                if (tblUser.Password == GetHash(user.PassCode))
                                {
                                    //User could login
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    user.Id = tblUser.Id;
                                    return true;
                                }
                                else
                                {
                                    throw new Exception("Could not login with these credentials");
                                }
                            }
                            else
                            {
                                throw new Exception("UserId could not be found");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set");
                    }
                }
                else
                {
                    throw new Exception("UserId was not set");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
