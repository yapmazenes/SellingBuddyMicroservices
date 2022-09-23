using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PaymentService.Api.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.IntegrationEvents.EventHandlers
{
    public class OrderStartedIntegrationEventHandler : IIntegrationEventHandler<OrderStartedIntegrationEvent>
    {
        private readonly IConfiguration configuration;
        private readonly IEventBus eventBus;
        private readonly ILogger<OrderStartedIntegrationEventHandler> logger;

        public OrderStartedIntegrationEventHandler(IConfiguration configuration, IEventBus eventBus, ILogger<OrderStartedIntegrationEventHandler> logger)
        {
            this.configuration = configuration;
            this.eventBus = eventBus;
            this.logger = logger;
        }

        public Task Handle(OrderStartedIntegrationEvent @event)
        {
            //Fake payment processs

            string keyword = "PaymentSuccess";
            bool paymentSuccessFlag = configuration.GetValue<bool>(keyword);

            IntegrationEvent paymentEvent = paymentSuccessFlag
                                            ? new OrderPaymentSuccessIntegrationEvent(@event.OrderId)
                                            : new OrderPaymentFailedIntegrationEvent(@event.OrderId, "Fake error message");

            logger.LogInformation($"OrderStartedIntegrationEventHandler in PaymentService is fired with PaymentSuccess: {paymentSuccessFlag}, orderId: {@event.OrderId}");

            //paymentEvent.CorrelationId = @event.CorrelationId;

            eventBus.Publish(paymentEvent);

            return Task.CompletedTask;
        }
    }
}
