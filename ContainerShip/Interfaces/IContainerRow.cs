
namespace ContainerShip.Interfaces
{
	public interface IContainerRow
	{
		IContainerColomn[] Colomns { get; }
		int TotalWeight { get; }
	}
}
