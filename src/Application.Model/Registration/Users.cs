using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Model.Registration
{

    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int DOB { get; set; }
        [Required]
        public string IDNumber { get; set; }
    }
}
