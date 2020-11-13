using System;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public class Container : IContainer
	{
		uint _weight;

		public virtual FreightType Type => FreightType.Normal;
		public uint Weight => 4000 + _weight;

		public Container(uint weight)
		{
			this._weight = weight;

			if (Weight > 30_000)
			{
				throw new ArgumentException();
			}
		}
	}
}
