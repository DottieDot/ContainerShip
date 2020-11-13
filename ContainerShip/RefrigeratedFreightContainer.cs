using ContainerShip.Enums;

namespace ContainerShip
{
	public class RefrigeratedFreightContainer : FreightContainer
	{
		public override FreightType Type => FreightType.Refrigerated;

		public RefrigeratedFreightContainer(uint weight) : base(weight) { }
	}
}
