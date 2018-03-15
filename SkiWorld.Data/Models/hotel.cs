using System;
using System.Collections.Generic;

namespace SkiWorld.Data.Models
{
    public partial class hotel
    {
        public hotel()
        {
            this.rooms = new List<room>();
        }
        [System.ComponentModel.DataAnnotations.Key]
        public int idHotel { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public int phone { get; set; }
        public float rating { get; set; }
        public int stars { get; set; }
        public virtual ICollection<room> rooms { get; set; }
    }
}
