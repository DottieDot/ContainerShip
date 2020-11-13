using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerShip;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace Tests
{
	[TestClass]
	public class FreightContainerFactoryTests
	{
		[TestMethod]
		public void Create_FreightTypeNormal_ContainerInstance()
		{
			IFreightContainer container = FreightContainerFactory.Create(FreightType.Normal, 0);
			Assert.IsInstanceOfType(container, typeof(FreightContainer));
		}

		[TestMethod]
		public void Create_FreightTypeRefrigerated_RefrigeratedContainerInstance()
		{
			IFreightContainer container = FreightContainerFactory.Create(FreightType.Refrigerated, 0);
			Assert.IsInstanceOfType(container, typeof(RefrigeratedFreightContainer));
		}

		[TestMethod]
		public void Create_FreightTypeValuable_ValuableContainerInstance()
		{
			IFreightContainer container = FreightContainerFactory.Create(FreightType.Valuable, 0);
			Assert.IsInstanceOfType(container, typeof(ValuableFreightContainer));
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void Create_InvalidFreigthType_ThrowsNotImplementedException()
		{
			FreightContainerFactory.Create((FreightType)1000, 0);
		}
	}
}
