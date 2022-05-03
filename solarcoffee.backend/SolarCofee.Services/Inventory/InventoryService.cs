using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SolarCofee.Data;
using SolarCofee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolarCofee.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly SolarDbContext _db;
        private readonly ILogger<InventoryService> _logger;
         
        public InventoryService(SolarDbContext db, ILogger<InventoryService> logger) 
        {
            _db = db;
            _logger = logger;
        }
        private void CreateSnapshot(ProductInventory inventory)
        {
            var snapshot = new ProductInventorySnapshot
            {
                SnapshotTime = DateTime.Now,
                Product = inventory.Product,
                QuantityOnHand = inventory.QuantityOnHand
            };

            _db.Add(snapshot);
            _db.SaveChanges();
        }

        public ProductInventory GetByProductId(int productId)
        {
            return _db.ProductInventories.Include(pi => pi.Product).FirstOrDefault(pi => pi.Product.Id == productId);
        }

        public List<ProductInventory> GetCurrenttInventory()
        {
            return _db.ProductInventories.
                Include(pi => pi.Product).
                Where(pi => !pi.Product.IsArchived).
                ToList();
        }

        public List<ProductInventorySnapshot> GetSnapshotsHistory()
        {
            var earliset = DateTime.Now - TimeSpan.FromHours(6);
            return _db.ProductInventorySnapshots
                .Include(snap => snap.Product)
                .Where(snap => snap.SnapshotTime > earliset && !snap.Product.IsArchived)
                .ToList();
        }

        public ServiceResponse<ProductInventory> UpdateUnitsAvailable(int id, int adjustment)
        {
            try
            {
                var inventory = _db.ProductInventories
                    .Include(inv => inv.Product)
                    .First(inv => inv.Product.Id == id);
                inventory.QuantityOnHand += adjustment;

                try
                {
                    CreateSnapshot(inventory);
                }
                catch (Exception e)
                {
                    _logger.LogError("Error creating inentory snapshot");
                    _logger.LogError(e.StackTrace);
                }

                _db.SaveChanges();
                return new ServiceResponse<ProductInventory>
                {
                    IsSuccess = true,
                    Data = inventory,
                    Message = $"Product {id} inventory adjusted",
                    Time = DateTime.Now
                };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<ProductInventory>
                {
                    IsSuccess = false,
                    Data = null, 
                    Message = ex.StackTrace,
                    Time = DateTime.Now
                };
            }
        }
    }
}
