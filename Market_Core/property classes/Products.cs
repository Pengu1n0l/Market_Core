using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Market_Core
{
    class Products
    {
        [Key]
        public int id_product { get; set; }
        public string Name_product { get; set; }
        public string Sort { get; set; }
        //public Base Base { get; set; }
    }
}
