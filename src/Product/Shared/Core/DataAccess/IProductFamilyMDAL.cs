﻿using SyncSoft.Olliix.Product.Command.ProductFamily;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.DataAccess
{
    public interface IProductFamilyMDAL
    {
        Task<string> InsertAsync(CreateProductFamilyCommand cmd);
    }
}
