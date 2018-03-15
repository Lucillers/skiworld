using System;
using System.Collections.Generic;

namespace SkiWorld.Data.Models
{
    public partial class shop
    {
        public shop()
        {
            this.categories = new List<category>();
        }
        [System.ComponentModel.DataAnnotations.Key]

        public int idShop { get; set; }
        public Nullable<System.DateTime> closeDate { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public Nullable<System.DateTime> openDate { get; set; }
        public int phone { get; set; }
        public virtual ICollection<category> categories { get; set; }
    }
}
