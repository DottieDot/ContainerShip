using System;
using ContainerShip;
using ContainerShip.Enums;
using ContainerShip.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.UnitTests
{
	[TestClass]
	public class FreightContainerColumnTests
	{
		[TestMethod]
		public void TotalWeight_Empty_0kg()
		{
			var column = new FreightContainerColumn();
			Assert.AreEqual(column.TotalWeight, 0u);
		}

		[TestMethod]
		public void TotalWeight_TwoEmptyContainers_8000kg()
		{
			var freightContainerMock = new Mock<IFreightContainer>();
			freightContainerMock.Setup(p => p.Weight).Returns(4_000);
			freightContainerMock.Setup(p => p.Type).Returns(FreightType.Normal);

			var column = new FreightContainerColumn();
			column.AddContainer(freightContainerMock.Object);
			column.AddContainer(freightContainerMock.Object);

			Assert.AreEqual(column.TotalWeight, 8_000u);
		}

		[TestMethod]
		public void AddContainer_Empty_15000kgContainer_NoThrow()
		{
			var freightContainerMock = new Mock<IFreightContainer>();
			freightContainerMock.Setup(p => p.Weight).Returns(15_000);
			freightContainerMock.Setup(p => p.Type).Returns(FreightType.Normal);

			var column = new FreightContainerColumn();
			column.AddContainer(freightContainerMock.Object);

			Assert.AreEqual(column.Containers.Length, 1);
			Assert.AreEqual(column.Containers[0], freightContainerMock.Object);
		}

		[TestMethod]
		public void AddContainer_Two7000kgContainers_8000kgContainer_ThrowInvalidOperationException()
		{
			// Arrange
			var container1Mock = new Mock<IFreightContainer>();
			container1Mock.Setup(p => p.Weight).Returns(70_000);
			container1Mock.Setup(p => p.Type).Returns(FreightType.Normal);
			var container2Mock = new Mock<IFreightContainer>();
			container2Mock.Setup(p => p.Weight).Returns(80_000);
			container2Mock.Setup(p => p.Type).Returns(FreightType.Normal);

			var column = new FreightContainerColumn();
			column.AddContainer(container1Mock.Object);
			column.AddContainer(container1Mock.Object);

			// Act
			Assert.ThrowsException<InvalidOperationException>(() =>
			{
				column.AddContainer(container2Mock.Object);
			});
		}

		[TestMethod]
		public void AddContainer_Two60000kgContainers_80000kgContainer_NoThrow()
		{
			// Arrange
			var container1Mock = new Mock<IFreightContainer>();
			container1Mock.Setup(p => p.Weight).Returns(60_000);
			container1Mock.Setup(p => p.Type).Returns(FreightType.Normal);
			var container2Mock = new Mock<IFreightContainer>();
			container2Mock.Setup(p => p.Weight).Returns(80_000);
			container2Mock.Setup(p => p.Type).Returns(FreightType.Normal);

			var column = new FreightContainerColumn();
			column.AddContainer(container1Mock.Object);
			column.AddContainer(container1Mock.Object);

			// Act
			column.AddContainer(container2Mock.Object);

			// Assert
			Assert.AreEqual(container2Mock.Object, column.Containers[0]);
			Assert.AreEqual(container1Mock.Object, column.Containers[1]);
			Assert.AreEqual(container1Mock.Object, column.Containers[2]);
		}

		[TestMethod]
		public void AddContainer_60000kgContainer80000kgContainer_60000kgContainer_NoThrow()
		{
			// Arrange
			var container1Mock = new Mock<IFreightContainer>();
			container1Mock.Setup(p => p.Weight).Returns(60_000);
			container1Mock.Setup(p => p.Type).Returns(FreightType.Normal);
			var container2Mock = new Mock<IFreightContainer>();
			container2Mock.Setup(p => p.Weight).Returns(80_000);
			container2Mock.Setup(p => p.Type).Returns(FreightType.Normal);

			var column = new FreightContainerColumn();
			column.AddContainer(container1Mock.Object);
			column.AddContainer(container2Mock.Object);

			// Act
			column.AddContainer(container1Mock.Object);

			// Assert
			Assert.AreEqual(container2Mock.Object, column.Containers[0]);
			Assert.AreEqual(container1Mock.Object, column.Containers[1]);
			Assert.AreEqual(container1Mock.Object, column.Containers[2]);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void AddContainer_Full_1kgContainer_ThrowInvalidOperationException()
		{
			var maxWeightFreightContainerMock = new Mock<IFreightContainer>();
			maxWeightFreightContainerMock.Setup(p => p.Weight).Returns(120_000);
			maxWeightFreightContainerMock.Setup(p => p.Type).Returns(FreightType.Normal);
			var oneKgFreightContainerMock = new Mock<IFreightContainer>();
			oneKgFreightContainerMock.Setup(p => p.Weight).Returns(1);
			oneKgFreightContainerMock.Setup(p => p.Type).Returns(FreightType.Normal);


			var column = new FreightContainerColumn();
			column.AddContainer(maxWeightFreightContainerMock.Object);
			column.AddContainer(maxWeightFreightContainerMock.Object);
			column.AddContainer(oneKgFreightContainerMock.Object);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void AddContainer_OneValuableContainer_ValuableContainer_ThrowInvalidOperationException()
		{
			var maxWeightFreightContainerMock = new Mock<IFreightContainer>();
			maxWeightFreightContainerMock.Setup(p => p.Weight).Returns(10_000);
			maxWeightFreightContainerMock.Setup(p => p.Type).Returns(FreightType.Valuable);
			var oneKgFreightContainerMock = new Mock<IFreightContainer>();
			oneKgFreightContainerMock.Setup(p => p.Weight).Returns(10_000);
			oneKgFreightContainerMock.Setup(p => p.Type).Returns(FreightType.Valuable);


			var column = new FreightContainerColumn();
			column.AddContainer(maxWeightFreightContainerMock.Object);
			column.AddContainer(oneKgFreightContainerMock.Object);
		}
	}
}
