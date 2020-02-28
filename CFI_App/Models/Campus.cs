using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_App.Models
{
    [Table("campus")]
    public class Campus
    {
        [Key]
        public string CampusCode { get; set; }
        public string CampusName { get; set; }
    }
}