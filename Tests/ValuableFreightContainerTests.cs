using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerShip;
using ContainerShip.Enums;

namespace Tests
{
	[TestClass]
	public class ValuableFreightContainerTests
	{
		[TestMethod]
		public void Type_Valuable()
		{
			var container = new ValuableFreightContainer(0);
			Assert.AreEqual(container.Type, FreightType.Valuable);
		}
	}
}
