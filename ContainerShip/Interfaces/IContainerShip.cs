using System.Collections.Generic;

namespace ContainerShip.Interfaces
{
	public interface IContainerShip
	{
		uint Width { get; }
		uint Length { get; }
		IFreightContainerRow[] ContainerRows { get; }
		double GetWeightBalanceRatio();
		void LoadContainers(IEnumerable<IFreightContainer> containers);
	}
}
