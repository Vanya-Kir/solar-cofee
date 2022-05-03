using SolarCofee.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarCofee.Web.Serialization
{
    public class ProductMapper
    {
        public static ProductModel SerializeProductModel(Data.Models.Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                CreateOn = product.CreateOn,
                UpdateOn = product.UpdateOn,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }

        public static Data.Models.Product SerializeProductModel(ProductModel product)
        {
            return new Data.Models.Product
            {
                Id = product.Id,
                CreateOn = product.CreateOn,
                UpdateOn = product.UpdateOn,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived
            };
        }
    }
}
