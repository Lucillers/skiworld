using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkiWorld.Data.Models
{
    public partial class skiareareservation
    {
        [Key, Column(Order = 1)]
        public int id_skiArea { get; set; }
        [Key, Column(Order = 2)]
        public int id_user { get; set; }
        public System.DateTime reservationDate { get; set; }
        public virtual skiarea skiarea { get; set; }
        public virtual user user { get; set; }
    }
}
