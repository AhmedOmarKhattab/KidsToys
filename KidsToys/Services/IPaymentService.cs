using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KidsToys.Dtos;
using KidsToys.Enums;
using KidsToys.Models;

namespace KidsToys.Services
{
     public  interface IPaymentService
    {
        public Task<string> CreatePaymentSession(Order order);
        public Task<Order> UpdateOrderStatus(string sessionId, OrderStatus status);

    }
}
