using System;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public class FreightContainer : IFreightContainer
	{
		readonly uint _weight;

		public FreightType Type { get; }
		public uint Weight => 4000 + _weight;

		public FreightContainer(FreightType type, uint weight)
		{
			Type = type;
			this._weight = weight;

			if (Weight > 30_000)
			{
				throw new ArgumentException();
			}
		}
	}
}
