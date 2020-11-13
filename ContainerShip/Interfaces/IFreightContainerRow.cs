
namespace ContainerShip.Interfaces
{
	public interface IFreightContainerRow
	{
		IFreightContainerColumn[] Columns { get; }
		uint TotalWeight { get; }
	}
}
