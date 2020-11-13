
namespace ContainerShip.Interfaces
{
	public interface IContainerShip
	{
		int Width { get; }
		int Length { get; }
		IFreightContainerRow[] ContainerRows { get; }
	}
}
