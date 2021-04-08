using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Market_Core
{
    class Bases
    {
        //ModelBuilder modelBuilder = new ModelBuilder();

        [Key]
        public int id_bases { get; set; }
        public int id_product { get; set; }
        public decimal Wholesale_price { get; set; }
        public int Amount_product { get; set; }
        //[Key]
        //public int id_shop { get; set; }


        //public ICollection<Products> Product { get; set; }
        //public ICollection<Shop> Shops { get; set; }
    }
}
