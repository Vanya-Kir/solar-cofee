using SolarCofee.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolarCofee.Services.Order
{
    public interface IOrderService
    {
        List<SalesOrder> GetAllOrders();
        ServiceResponse<bool> GenerateOpenOrder(SalesOrder order);
        ServiceResponse<bool> MarkFulfilled(int id);

    }
}
