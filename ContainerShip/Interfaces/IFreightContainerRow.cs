
namespace ContainerShip.Interfaces
{
	public interface IFreightContainerRow
	{
		IFreightContainerColumn[] Columns { get; }
		uint TotalWeight { get; }
		void AddContainer(IFreightContainer container);
		bool TryAddContainer(IFreightContainer container);
		int GetRequiredNormalContainers();
		void AddGapsToValuableContainers();
		void ReverseColumns();
	}
}
