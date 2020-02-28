using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_App.Models
{
    [Table("subject")]
    public class Subject
    {
        [Key]
        public string SubjectCode { get; set; }
    }
}