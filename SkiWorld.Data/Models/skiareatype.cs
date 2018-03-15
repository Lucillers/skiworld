using System;
using System.Collections.Generic;

namespace SkiWorld.Data.Models
{
    public partial class skiareatype
    {
        public skiareatype()
        {
            this.skiareas = new List<skiarea>();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public int idType { get; set; }
        public Nullable<int> difficulty { get; set; }

        public string typeArea { get; set; }
        public virtual ICollection<skiarea> skiareas { get; set; }
    }
}
