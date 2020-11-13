using ContainerShip.Enums;

namespace ContainerShip.Interfaces
{
	public interface IContainer
	{
		FreightType Type { get; }
		int Weight { get; }
	}
}
