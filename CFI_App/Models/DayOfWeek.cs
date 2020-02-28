using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFI_App.Models
{
    [Table("day_of_week")]
    public class DayOfWeek
    {
        [Key]
        public int? DayCode { get; set; }
        public string DayLongName { get; set; }
    }
}