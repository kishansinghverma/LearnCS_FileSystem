using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrialApp.Models
{
    public class UserDetail
    {
        [Key]
        public int User_ID { get; set; }

        [Required]
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string User_Emaild { get; set; }
        public string User_Password { get; set; }
    }
}