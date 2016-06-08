using System;
using System.Collections.Generic;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public class DomainEventPublisher : IDomainEventPublisher
	{
		//private readonly IContainer container;
		//private DomainEventPublisher(IContainer container)
		//{
		//	this.container = container;
		//}
		private readonly IDomainEventHandlerFactory domainEventHandlerFactory;

		//[ThreadStatic]
		//private static DomainEventPublisher instance;
		//public static DomainEventPublisher Instance
		//{
		//	get
		//	{
		//		if (instance == null)
		//		{
		//			instance = new DomainEventPublisher();
		//			//instance = new DomainEventPublisher(Bootstrapper.Container);
		//		}

		//		return instance;
		//	}
		//}

		private List<Delegate> actions;

		public DomainEventPublisher(IDomainEventHandlerFactory domainEventHandlerFactory)
		{
			this.domainEventHandlerFactory = domainEventHandlerFactory;
		}

		public void Register<T>(Action<T> callback) where T : IDomainEvent
		{
			if (this.actions == null)
				this.actions = new List<Delegate>();

			this.actions.Add(callback);
		}

		public void Publish<T>(T domainEvent) where T : IDomainEvent
		{
			// TODO: wire in IoC container for service layer calls
			//if (this.container != null)
			//{
			//foreach (IDomainEventHandler<T> handler in this.container.Resolve<IEnumerable<IDomainEventHandler<T>>>())
			foreach (IDomainEventHandler<T> handler in this.domainEventHandlerFactory.GetDomainEventHandler<T>())
				handler.Handle(domainEvent);
			//}

			//	foreach (IDomainEventHandler<T> handler in CONTAINER.Resolve<IEnumerable<IDomainEventHandlerFactory<T>>>())
			//		handler.Handle(domainEvent);

			if (this.actions != null)
				foreach (var action in this.actions)
					if (action is Action<T>)
						((Action<T>)action)(domainEvent);
		}

		public void ClearCallbacks()
		{
			this.actions = null;
		}
	}
}