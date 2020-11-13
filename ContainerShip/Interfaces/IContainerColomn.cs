
namespace ContainerShip.Interfaces
{
	public interface IContainerColomn
	{
		IContainer[] Containers { get; }
		int TotalWeight { get; }

		bool CanAddContainer(IContainer container);

		void AddContainer(IContainer container);

		bool TryAddContainer(IContainer container);
	}
}
