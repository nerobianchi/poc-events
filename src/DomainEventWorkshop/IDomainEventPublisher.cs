using System;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public interface IDomainEventPublisher
	{
		void Register<T>(Action<T> callback) where T : IDomainEvent;

		void Publish<T>(T domainEvent) where T : IDomainEvent;

		void ClearCallbacks();
	}
}