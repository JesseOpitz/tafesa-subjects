using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_App.Models
{
    [Table("crn_session_timetable")]
    public class Subjects
    {
        [Key]
        public int? CRN { get; set; }
        public int? DayCode { get; set; }
        public string StartTime { get; set; }
        public string Room { get; set; }
        public string CampusCode { get; set; }

    }
}