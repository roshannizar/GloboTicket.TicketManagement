﻿using GloboTicket.TicketManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GloboTicket.TicketManagement.Domain.Entity
{
    public class Order : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool OrderPaid { get; set; }
    }
}
