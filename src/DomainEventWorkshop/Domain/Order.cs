using System.Collections.Generic;

namespace ConsoleApplication2.Domain
{
	public class Order : Entity
	{
		private readonly IList<OrderLine> orderLines;

		public Order()
		{
			this.orderLines = new List<OrderLine>();
		}

		public long Id { get; private set; }

		public void AddOrderLine(Product product, int count)
		{
			this.orderLines.Add(new OrderLine(product, count));

			this.Publisher.Publish(new OrderLineAdded(this.Id, product.Name, count));
			//DomainEventPublisher.Instance.Publish(new OrderLineAdded(this.Id, product.Name, count));
		}
	}
}