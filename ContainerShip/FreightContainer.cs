using System;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public class FreightContainer : IFreightContainer
	{
		uint _weight;

		public virtual FreightType Type => FreightType.Refrigerated;
		public uint Weight => 4000 + _weight;

		public FreightContainer(uint weight)
		{
			this._weight = weight;

			if (Weight > 30_000)
			{
				throw new ArgumentException();
			}
		}
	}
}
