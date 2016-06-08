namespace ConsoleApplication2.Domain
{
	public interface IOrderApplicationService
	{
		void AddOrderLine(Product product, int count);
	}
}