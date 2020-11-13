
namespace ContainerShip.Interfaces
{
	public interface IContainerRow
	{
		IContainerColomn[] Colomns { get; }
		uint TotalWeight { get; }
	}
}
