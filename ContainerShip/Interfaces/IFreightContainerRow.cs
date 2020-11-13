
namespace ContainerShip.Interfaces
{
	public interface IFreightContainerRow
	{
		IFreightContainerColomn[] Colomns { get; }
		uint TotalWeight { get; }
	}
}
