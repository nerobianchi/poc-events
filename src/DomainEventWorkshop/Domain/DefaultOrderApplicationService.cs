namespace ConsoleApplication2.Domain
{
	public class DefaultOrderApplicationService : IOrderApplicationService
	{
		private readonly IOrderFactory orderFactory;

		public DefaultOrderApplicationService(IOrderFactory orderFactory)
		{
			this.orderFactory = orderFactory;
		}

		public void AddOrderLine(Product product, int count)
		{
			Order order = this.orderFactory.Create();
			order.AddOrderLine(product, count);
		}
	}
}