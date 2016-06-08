using System;
using System.Collections.Generic;

using Autofac;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public class DomainEventPublisher2
	{
		[ThreadStatic]
		private static List<Delegate> actions;

		public static void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			if (actions == null)
				actions = new List<Delegate>();

			actions.Add(callback);
		}

		public static void ClearCallbacks()
		{
			actions = null;
		}

		private static readonly IContainer CONTAINER = Bootstrapper2.Container;

		public static void Publish<T>(T domainEvent) where T : IDomainEvent
		{
			// TODO: wire in IoC container for service layer calls
			if (CONTAINER != null)
				//	foreach (IDomainEventHandler<T> handler in CONTAINER.Resolve<IEnumerable<IDomainEventHandlerFactory<T>>>())
				//		handler.Handle(domainEvent);
				foreach (IDomainEventHandler<T> handler in CONTAINER.Resolve<IEnumerable<IDomainEventHandler<T>>>())
					handler.Handle(domainEvent);

			if (actions != null)
				foreach (var action in actions)
					if (action is Action<T>)
						((Action<T>)action)(domainEvent);
		}
	}
}