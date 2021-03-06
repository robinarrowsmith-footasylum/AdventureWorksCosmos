﻿using System.Threading.Tasks;
using AdventureWorksCosmos.Core.Infrastructure;
using AdventureWorksCosmos.Core.Models.Fulfillments;

namespace AdventureWorksCosmos.Core.Models.Orders
{
    public class OrderFulfillmentSuccessfulHandler : IDocumentMessageHandler<OrderFulfillmentSuccessful>
    {
        private readonly IDocumentDbRepository<OrderRequest> _repository;

        public OrderFulfillmentSuccessfulHandler(IDocumentDbRepository<OrderRequest> repository)
            => _repository = repository;

        public async Task Handle(OrderFulfillmentSuccessful message)
        {
            var order = await _repository.GetItemAsync(message.OrderId);

            order.Handle(message);

            await _repository.UpdateItemAsync(order);
        }
    }
}