using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkiWorld.Data.Models
{
    public partial class purchasedetail
    {
        
        [Key, Column(Order = 1)]
        public int id_product { get; set; }
        [Key, Column(Order = 2)]
        public int id_user { get; set; }
        public System.DateTime purchaseDate { get; set; }
        public int quantity { get; set; }
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
