using System;
using System.Collections.Generic;

namespace SkiWorld.Data.Models
{
    public partial class category
    {
        public category()
        {
            this.products = new List<product>();
        }
        [System.ComponentModel.DataAnnotations.Key]
        public int idCategory { get; set; }
        public string name { get; set; }
        public Nullable<int> fk_Shop { get; set; }
        public virtual shop shop { get; set; }
        public virtual ICollection<product> products { get; set; }
    }
}
