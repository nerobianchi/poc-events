namespace ConsoleApplication2.Domain
{
	public class Product
	{
		private readonly string name;

		public Product(string name)
		{
			this.name = name;
		}

		public string Name { get { return this.name; } }
	}
}