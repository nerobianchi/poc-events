using System.Collections.Generic;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public interface IDomainEventHandlerFactory//<T>
		//where T : IDomainEvent
	{
		IEnumerable<IDomainEventHandler<T>> GetDomainEventHandler<T>() where T : IDomainEvent;
	}
}