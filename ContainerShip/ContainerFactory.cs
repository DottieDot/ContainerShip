using System;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public static class ContainerFactory
	{
		static public IContainer Create(FreightType freightType, uint weight)
		{
			switch (freightType)
			{
				case FreightType.Normal:
					return new Container(weight);
				case FreightType.Refrigerated:
					return new RefrigeratedContainer(weight);
				case FreightType.Valuable:
					return new ValuableContainer(weight);
				default:
					throw new NotImplementedException();
			}
		}
	}
}
