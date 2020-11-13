
namespace ContainerShip.Interfaces
{
	public interface IFreightContainerColumn
	{
		IFreightContainer[] Containers { get; }
		uint TotalWeight { get; }

		bool CanAddContainer(IFreightContainer container);

		void AddContainer(IFreightContainer container);

		bool TryAddContainer(IFreightContainer container);
	}
}
