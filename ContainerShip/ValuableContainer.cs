using ContainerShip.Enums;

namespace ContainerShip
{
	public class ValuableContainer : Container
	{
		public override FreightType Type => FreightType.Valuable;

		public ValuableContainer(int weight) : base(weight) { }
	}
}
