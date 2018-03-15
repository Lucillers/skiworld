using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkiWorld.Data.Models
{
    public partial class restotablereservation
    {
        public System.DateTime endTime { get; set; }
      
        [Key, Column(Order = 1)]
        public int id_table { get; set; }
        [Key, Column(Order = 2)]
        public int id_user { get; set; }
        public System.DateTime startTime { get; set; }
        public virtual restotable restotable { get; set; }
        public virtual user user { get; set; }
    }
}
