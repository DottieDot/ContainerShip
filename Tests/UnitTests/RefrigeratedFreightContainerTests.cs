using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerShip;
using ContainerShip.Enums;

namespace Tests
{
	[TestClass]
	public class RefrigeratedFreightContainerTests
	{
		[TestMethod]
		public void Type_Refrigerated()
		{
			var container = new RefrigeratedFreightContainer(0);
			Assert.AreEqual(container.Type, FreightType.Refrigerated);
		}
	}
}
