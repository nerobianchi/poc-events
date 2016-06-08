namespace ConsoleApplication2.Domain
{
	public class OrderLine
	{
		private int count;
		private Product product;

		public OrderLine(Product product, int count)
		{
			this.product = product;
			this.count = count;
		}
	}
}