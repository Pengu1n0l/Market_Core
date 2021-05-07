using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Market_Core
{
    class Shops
    {
    
        public int id_shop { get; set; }
        public int id_department { get; set; }
        public int id_product { get; set; }
        public int Amount_product { get; set; }
        public decimal Retail_price { get; set; }

        //public virtual ICollection<Departments> departments { get; set; }
        //public string Grade { get; set; }

        //public virtual ICollection<OtdelTupe> Otdels { get; set; }
        //public virtual ICollection<Base> Bases { get; set; }
        
    }


}
