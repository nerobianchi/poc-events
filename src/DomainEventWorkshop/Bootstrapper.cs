using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public class Bootstrapper
	{
		private static IWindsorContainer container;

		//public static IWindsorContainer Container { get { return container; } }

		public static T Start<T>()
		{
			return container.Resolve<T>();
		}

		public static IWindsorContainer Initialize()
		{

			container = new WindsorContainer();

			container.Register(Component.For<IOrderApplicationService>().ImplementedBy<DefaultOrderApplicationService>().LifestyleTransient());
			container.Register(Component.For<IDomainEventPublisher>().ImplementedBy<DomainEventPublisher>().LifestyleTransient());
			container.Register(Component.For<IDomainEventHandlerFactory>().ImplementedBy<CastleDomainEventHandlerFactory>().LifestyleTransient());

			container.Register(Component.For<IDomainEventHandler<OrderLineAdded>>().ImplementedBy<OrderLineAddedHandler>().LifestyleTransient());
			container.Register(Component.For<IDomainEventHandler<OrderLineAdded>>().ImplementedBy<OrderLineAddedHandler2>().LifestyleTransient());


			container.AddFacility<TypedFactoryFacility>();
			container.Register(Component.For<IOrderFactory>().AsFactory().LifestyleSingleton());
			container.Register(Component.For<Order>());
			//container.Register(Component.For<Order>().DependsOn(Property.ForKey<IDomainEventPublisher>()));
			/*
			 base.Kernel.Register(Component.For<IScheduler>().UsingFactoryMethod(k => k.Resolve<IQuartzSchedulerFactory>().GetScheduler()).LifestyleTransient());
			 */


			return container;
		}
	}
}