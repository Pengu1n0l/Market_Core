using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Market_Core.property_classes
{
    class Supplys
    {
        [Key]
        public int Number_supply { get; set; }
        public int id_bases { get; set; }
        public int id_shop { get; set; }
        public int id_department { get; set; }
        public int id_product { get; set; }
        public DateTime date_supply { get; set; }

    }
}
