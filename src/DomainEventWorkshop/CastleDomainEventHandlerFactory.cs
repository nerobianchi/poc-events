using System.Collections.Generic;

using Castle.MicroKernel;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public class CastleDomainEventHandlerFactory : IDomainEventHandlerFactory
	{
		private readonly IKernel container;

		public CastleDomainEventHandlerFactory(IKernel container)
		{
			this.container = container;
		}

		public IEnumerable<IDomainEventHandler<T>> GetDomainEventHandler<T>() where T : IDomainEvent
		{
			return this.container.ResolveAll<IDomainEventHandler<T>>();
		}
	}
}