#region licence

// <copyright file="Class1.cs" company="nerobianchi">
// </copyright>
// <summary>
// 	Project Name:	ConsoleApplication2
// 	Created By: 	erdem.ozdemir
// 	Create Date:	29.04.2016 17:45
// 	Last Changed By:	erdem.ozdemir
// 	Last Change Date:	29.04.2016 17:45
// </summary>

#endregion licence

using System;

namespace ConsoleApplication2.Domain
{
	public class OrderLineAddedHandler : IDomainEventHandler<OrderLineAdded>
	{
		public void Handle(OrderLineAdded domainEvent)
		{
			Console.WriteLine("{2} items of {1} , OrderLine is added for orderId:{0} ", domainEvent.OrderId, domainEvent.ProductName, domainEvent.Count);
		}
	}
}