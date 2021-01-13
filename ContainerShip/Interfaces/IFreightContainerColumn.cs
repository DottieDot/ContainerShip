
namespace ContainerShip.Interfaces
{
	public interface IFreightContainerColumn
	{
		IFreightContainer[] Containers { get; }
		uint TotalWeight { get; }

		void AddContainer(IFreightContainer container);

		bool TryAddContainer(IFreightContainer container);

		bool HasValuableContainer();
	}
}
