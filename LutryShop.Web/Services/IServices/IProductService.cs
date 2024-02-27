﻿using LutryShop.Web.Models;

namespace LutryShop.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAll();
        Task<ProductModel> FindById(long id);
        Task<ProductModel> Create(ProductModel product);
        Task<ProductModel> Update(ProductModel product);
        Task<bool> Delete(long id);
    }
}
