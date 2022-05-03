using SolarCofee.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCofee.Services.Inventory
{
    public interface IInventoryService
    {
        public List<ProductInventory> GetCurrenttInventory();
        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment);
        public ProductInventory GetByProductId(int productId);
        public List<ProductInventorySnapshot> GetSnapshotsHistory();
    }
}
