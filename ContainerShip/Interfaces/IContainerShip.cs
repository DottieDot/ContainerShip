
namespace ContainerShip.Interfaces
{
	public interface IContainerShip
	{
		uint Width { get; }
		uint Length { get; }
		IFreightContainerRow[] ContainerRows { get; }
	}
}
