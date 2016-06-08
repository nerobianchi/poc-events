using Autofac;
using Autofac.Builder;

using ConsoleApplication2.Domain;

namespace ConsoleApplication2
{
	public class Bootstrapper2
	{
		private static IContainer container;

		public static IContainer Container { get { return container; } }

		public static T Start<T>()
		{
			return container.Resolve<T>();
		}

		public static IContainer Initialize()
		{
			Autofac.ContainerBuilder builder = new ContainerBuilder();

			builder.RegisterType<DefaultOrderApplicationService>().As<IOrderApplicationService>();
			builder.RegisterType<OrderLineAddedHandler>().As<IDomainEventHandler<OrderLineAdded>>();
			builder.RegisterType<OrderLineAddedHandler2>().As<IDomainEventHandler<OrderLineAdded>>();
			builder.RegisterGeneratedFactory(typeof(IOrderFactory));
			builder.RegisterType<Order>();
			/*
			 base.Kernel.Register(Component.For<IScheduler>().UsingFactoryMethod(k => k.Resolve<IQuartzSchedulerFactory>().GetScheduler()).LifestyleTransient());
			 */

			container = builder.Build();
			return container;
		}
	}
}