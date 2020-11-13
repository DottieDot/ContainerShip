using ContainerShip.Enums;

namespace ContainerShip.Interfaces
{
	public interface IFreightContainer
	{
		FreightType Type { get; }
		uint Weight { get; }
	}
}
