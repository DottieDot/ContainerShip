using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerShip;
using ContainerShip.Enums;

namespace Tests.UnitTests
{
	/// <summary>
	/// Summary description for ContainerTests
	/// </summary>
	[TestClass]
	public class FreightContainerTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_26001kg_ThrowsArgumentException()
		{
			new FreightContainer(FreightType.Normal, 26_001);
		}

		[TestMethod]
		public void Constructor_26001kg_NotThrows()
		{
			new FreightContainer(FreightType.Normal, 26_000);
		}

		[TestMethod]
		public void Type_FreightTypeNormal()
		{
			var container = new FreightContainer(FreightType.Normal, 0);
			Assert.AreEqual(container.Type, FreightType.Normal);
		}

		[TestMethod]
		public void Weight_Empty_4000kg()
		{
			var container = new FreightContainer(FreightType.Normal, 0);
			Assert.AreEqual(container.Weight, 4_000u);
		}

		[TestMethod]
		public void Weight_26000kg_30000kg()
		{
			var container = new FreightContainer(FreightType.Normal, 26_000);
			Assert.AreEqual(container.Weight, 30_000u);
		}
	}
}
