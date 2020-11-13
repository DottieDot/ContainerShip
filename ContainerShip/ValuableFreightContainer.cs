using ContainerShip.Enums;

namespace ContainerShip
{
	public class ValuableFreightContainer : FreightContainer
	{
		public override FreightType Type => FreightType.Valuable;

		public ValuableFreightContainer(uint weight) : base(weight) { }
	}
}
