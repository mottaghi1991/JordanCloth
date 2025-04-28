using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Store
{
    public interface IPProductTag
    {
        public bool Insert(int TagId, int ProductId);
        public bool Delete(Product_ProductTag productTag);
        public Product_ProductTag CheckExist(int ProductTagId, int ProductId);
    }
}
