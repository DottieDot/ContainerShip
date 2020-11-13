
namespace ContainerShip.Interfaces
{
	public interface IContainerShip
	{
		int Width { get; }
		int Length { get; }
		IContainerRow[] ContainerRows { get; }
	}
}
