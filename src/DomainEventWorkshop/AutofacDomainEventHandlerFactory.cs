using System.Collections.Generic;

using Autofac;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public class AutofacDomainEventHandlerFactory : IDomainEventHandlerFactory
	{
		private readonly IContainer container;

		public AutofacDomainEventHandlerFactory(IContainer container)
		{
			this.container = container;
		}

		public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandler<T>() where T : IDomainEvent
		{
			return this.container.Resolve<IEnumerable<IDomainEventHandler<T>>>();
		}
	}
}