using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkiWorld.Data.Models
{
    public partial class roomreservation
    {
        public System.DateTime arrivalDate { get; set; }
        public System.DateTime departureDate { get; set; }
        [Key, Column(Order = 1)]
        public int id_room { get; set; }
        [Key, Column(Order = 2)]
        public int id_user { get; set; }
        public bool isCheck { get; set; }
        public float price { get; set; }
        public Nullable<int> roomReservationType { get; set; }
        public virtual room room { get; set; }
        public virtual user user { get; set; }
    }
}
