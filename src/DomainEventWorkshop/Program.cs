using Autofac;
using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	class Program
	{
		static void Main(string[] args)
		{
			Bootstrapper.Initialize();
			IOrderApplicationService orderApplicationService = Bootstrapper.Start<IOrderApplicationService>();

			Product product = new Product("product_01");
			int count = 5;

			orderApplicationService.AddOrderLine(product, count);
		}
	}
}