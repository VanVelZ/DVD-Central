using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJV.DVDCentral.BL.Models
{
    public class User
    {

        public int Id { get; set; }
        [DisplayName("User ID")]
        public string UserId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Password")]
        public string PassCode { get; set; }

        public User()
        {

        }
        public User(string userid, string passcode)
        {
            //Login
            UserId = userid;
            PassCode = passcode;
        }
        public User(int id, string userid, string firstname, string lastname, string passcode)
        {
            //Update
            Id = id;
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            PassCode = passcode;
        }
        public User(string userid, string firstname, string lastname, string passcode)
        {
            //Create
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            PassCode = passcode;
        }
    }
}
