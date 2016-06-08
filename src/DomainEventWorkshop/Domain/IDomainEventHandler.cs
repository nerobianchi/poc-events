namespace ConsoleApplication2.Domain
{
	public interface IDomainEventHandler<T> where T : IDomainEvent
	{
		void Handle(T domainEvent);
	}
}