using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_App.Models
{
    [Table("lecturer")]
    public class Lecturer
    {
        [Key]
        public string LecturerID { get; set; }
        public string GivenName { get; set; }
        public string LastName { get; set; }
    }
}