using GloboTicket.TicketManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Application.Contracts.Persistance
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
