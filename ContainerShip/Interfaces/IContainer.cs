using ContainerShip.Enums;

namespace ContainerShip.Interfaces
{
	public interface IContainer
	{
		FreightType Type { get; }
		uint Weight { get; }
	}
}
