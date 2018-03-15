using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkiWorld.Data.Models
{
    public partial class product
    {
        public product()
        {
            this.purchasedetails = new List<purchasedetail>();
        }
        [System.ComponentModel.DataAnnotations.Key]

        public int idProduct { get; set; }
        public bool isAvailable { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public Nullable<int> idCategory { get; set; }
        [ForeignKey("idCategory")]
        public virtual category category { get; set; }
        public virtual ICollection<purchasedetail> purchasedetails { get; set; }
    }
}
