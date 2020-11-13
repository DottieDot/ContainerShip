using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public class Container : IContainer
	{
		int _weight;

		public virtual FreightType Type => FreightType.Normal;
		public int Weight => 4000 + _weight;

		public Container(int weight)
		{
			this._weight = weight;
		}
	}
}
