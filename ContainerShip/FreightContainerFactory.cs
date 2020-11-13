using System;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public static class FreightContainerFactory
	{
		static public IFreightContainer Create(FreightType freightType, uint weight)
		{
			switch (freightType)
			{
				case FreightType.Normal:
					return new FreightContainer(weight);
				case FreightType.Refrigerated:
					return new RefrigeratedFreightContainer(weight);
				case FreightType.Valuable:
					return new ValuableFreightContainer(weight);
				default:
					throw new NotImplementedException();
			}
		}
	}
}
