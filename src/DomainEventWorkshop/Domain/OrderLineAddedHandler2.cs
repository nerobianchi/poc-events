using System;

namespace ConsoleApplication2.Domain
{
	public class OrderLineAddedHandler2 : IDomainEventHandler<OrderLineAdded>
	{
		public void Handle(OrderLineAdded domainEvent)
		{
			Console.WriteLine(" -----------------------------------------{2} items of {1} , OrderLine is added for orderId:{0} -----------------------------------------", domainEvent.OrderId, domainEvent.ProductName, domainEvent.Count);
		}
	}
}