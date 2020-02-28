using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_App.Models
{
    [Table("crn_detail")]
    public class CRNDetail
    {
        [Key]
        public int? CRN { get; set; }
        public string SubjectCode { get; set; }
        public string LecturerID { get; set; }
    }
}