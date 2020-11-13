using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerShip;
using ContainerShip.Enums;

namespace Tests
{
	/// <summary>
	/// Summary description for ContainerTests
	/// </summary>
	[TestClass]
	public class ContainerTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Constructor_26001kg_ThrowsArgumentException()
		{
			new Container(26_001);
		}

		[TestMethod]
		public void Constructor_26001kg_NotThrows()
		{
			new Container(26_000);
		}

		[TestMethod]
		public void Type_FreightTypeNormal()
		{
			var container = new Container(0);
			Assert.AreEqual(container.Type, FreightType.Normal);
		}

		[TestMethod]
		public void Weight_Empty_4000kg()
		{
			var container = new Container(0);
			Assert.AreEqual(container.Weight, 4_000u);
		}

		[TestMethod]
		public void Weight_26000kg_30000kg()
		{
			var container = new Container(26_000);
			Assert.AreEqual(container.Weight, 30_000u);
		}
	}
}
