using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class Product_ProductTag : BaseModel
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int ProductTagId { get; set; }
        [ForeignKey("ProductTagId")]
        public ProductTag ProductTag { get; set; }
    }
}
