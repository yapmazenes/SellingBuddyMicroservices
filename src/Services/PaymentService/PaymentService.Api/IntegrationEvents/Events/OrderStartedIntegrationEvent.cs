using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.IntegrationEvents.Events
{
    public class OrderStartedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; set; }

        public OrderStartedIntegrationEvent()
        {

        }

        public OrderStartedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
