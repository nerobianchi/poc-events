namespace ConsoleApplication2.Domain
{
	public class OrderLineAdded : IDomainEvent
	{
		private readonly long orderId;

		private readonly string productName;

		private readonly int count;

		public OrderLineAdded(long orderId, string productName, int count)
		{
			this.orderId = orderId;
			this.productName = productName;
			this.count = count;
		}

		public long OrderId
		{
			get { return this.orderId; }
		}

		public string ProductName
		{
			get { return this.productName; }
		}

		public int Count
		{
			get { return this.count; }
		}
	}
}