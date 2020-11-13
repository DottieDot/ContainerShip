using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerShip;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace Tests
{
	[TestClass]
	public class ContainerFactoryTest
	{
		[TestMethod]
		public void Create_FreightTypeNormal_ContainerInstance()
		{
			IContainer container = ContainerFactory.Create(FreightType.Normal, 0);
			Assert.IsInstanceOfType(container, typeof(Container));
		}

		[TestMethod]
		public void Create_FreightTypeRefrigerated_RefrigeratedContainerInstance()
		{
			IContainer container = ContainerFactory.Create(FreightType.Refrigerated, 0);
			Assert.IsInstanceOfType(container, typeof(RefrigeratedContainer));
		}

		[TestMethod]
		public void Create_FreightTypeValuable_ValuableContainerInstance()
		{
			IContainer container = ContainerFactory.Create(FreightType.Valuable, 0);
			Assert.IsInstanceOfType(container, typeof(ValuableContainer));
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void Create_InvalidFreigthType_ThrowsNotImplementedException()
		{
			ContainerFactory.Create((FreightType)1000, 0);
		}
	}
}
