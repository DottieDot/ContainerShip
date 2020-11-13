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
		public void CreateNormalContainer()
		{
			IContainer container = ContainerFactory.Create(FreightType.Normal, 0);
			Assert.IsInstanceOfType(container, typeof(Container));
		}

		[TestMethod]
		public void CreateRefrigeratedContainer()
		{
			IContainer container = ContainerFactory.Create(FreightType.Refrigerated, 0);
			Assert.IsInstanceOfType(container, typeof(RefrigeratedContainer));
		}

		[TestMethod]
		public void CreateValuableContainer()
		{
			IContainer container = ContainerFactory.Create(FreightType.Valuable, 0);
			Assert.IsInstanceOfType(container, typeof(ValuableContainer));
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void CreateInvalidContainer()
		{
			IContainer container = ContainerFactory.Create((FreightType)1000, 0);
		}
	}
}
