using ContainerShip.Enums;

namespace ContainerShip
{
	public class RefrigeratedContainer : Container
	{
		public override FreightType Type => FreightType.Refrigerated;

		public RefrigeratedContainer(uint weight) : base(weight) { }
	}
}
