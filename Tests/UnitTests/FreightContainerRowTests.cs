using System;
using ContainerShip;
using ContainerShip.Enums;
using ContainerShip.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests.UnitTests
{
	[TestClass]
	public class FreightContainerRowTests
	{
		[TestMethod]
		public void GetRequiredNormalContainers_1ValuableNoGaps_0()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(1);
			row.AddContainer(mockedValuable.Object);

			// Act
			int required = row.GetRequiredNormalContainers();

			// Assert
			Assert.AreEqual(0, required);
		}

		[TestMethod]
		public void GetRequiredNormalContainers_2ValuableNoGaps_0()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(2);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			int required = row.GetRequiredNormalContainers();

			// Assert
			Assert.AreEqual(0, required);
		}

		[TestMethod]
		public void GetRequiredNormalContainers_3ValuableNoGaps_1()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(3);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			int required = row.GetRequiredNormalContainers();

			// Assert
			Assert.AreEqual(1, required);
		}

		[TestMethod]
		public void GetRequiredNormalContainers_4ValuableNoGaps_2()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(4);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			int required = row.GetRequiredNormalContainers();

			// Assert
			Assert.AreEqual(2, required);
		}

		[TestMethod]
		public void GetRequiredNormalContainers_5ValuableNoGaps_4()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(5);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			int required = row.GetRequiredNormalContainers();

			// Assert
			Assert.AreEqual(4, required);
		}

		[TestMethod]
		public void AddGapsToValuableContainers_3Valuable2Gaps()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(5);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			row.AddGapsToValuableContainers();

			// Assert
			Assert.AreEqual(1, row.Columns[0].Containers.Length);
			Assert.AreEqual(0, row.Columns[1].Containers.Length);
			Assert.AreEqual(1, row.Columns[2].Containers.Length);
			Assert.AreEqual(0, row.Columns[3].Containers.Length);
			Assert.AreEqual(1, row.Columns[4].Containers.Length);
		}

		[TestMethod]
		public void AddGapsToValuableContainers_4Valuable1Gap()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(5);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			row.AddGapsToValuableContainers();

			// Assert
			Assert.AreEqual(1, row.Columns[0].Containers.Length);
			Assert.AreEqual(1, row.Columns[1].Containers.Length);
			Assert.AreEqual(0, row.Columns[2].Containers.Length);
			Assert.AreEqual(1, row.Columns[3].Containers.Length);
			Assert.AreEqual(1, row.Columns[4].Containers.Length);
		}

		[TestMethod]
		public void AddGapsToValuableContainers_9Valuable2Gap()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(11);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			row.AddGapsToValuableContainers();

			// Assert
			Assert.AreEqual(1, row.Columns[0].Containers.Length);
			Assert.AreEqual(1, row.Columns[1].Containers.Length);
			Assert.AreEqual(1, row.Columns[2].Containers.Length);
			Assert.AreEqual(0, row.Columns[3].Containers.Length);
			Assert.AreEqual(1, row.Columns[4].Containers.Length);
			Assert.AreEqual(1, row.Columns[5].Containers.Length);
			Assert.AreEqual(1, row.Columns[6].Containers.Length);
			Assert.AreEqual(0, row.Columns[7].Containers.Length);
			Assert.AreEqual(1, row.Columns[8].Containers.Length);
			Assert.AreEqual(1, row.Columns[9].Containers.Length);
			Assert.AreEqual(1, row.Columns[10].Containers.Length);
		}

		[TestMethod]
		public void AddGapsToValuableContainers_6Valuable3Gap()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);

			var row = new FreightContainerRow(9);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			// Act
			row.AddGapsToValuableContainers();

			// Assert
			Assert.AreEqual(1, row.Columns[0].Containers.Length);
			Assert.AreEqual(1, row.Columns[1].Containers.Length);
			Assert.AreEqual(0, row.Columns[2].Containers.Length);
			Assert.AreEqual(1, row.Columns[3].Containers.Length);
			Assert.AreEqual(0, row.Columns[4].Containers.Length);
			Assert.AreEqual(1, row.Columns[5].Containers.Length);
			Assert.AreEqual(0, row.Columns[6].Containers.Length);
			Assert.AreEqual(1, row.Columns[7].Containers.Length);
			Assert.AreEqual(1, row.Columns[8].Containers.Length);
		}

		[TestMethod]
		public void AddContainer_1NormalContainers3ValuableContainersNoGaps()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);
			var mockedNormal = new Mock<IFreightContainer>();
			mockedNormal.Setup(mock => mock.Type).Returns(FreightType.Normal);

			var row = new FreightContainerRow(3);

			// Act
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);

			row.AddContainer(mockedNormal.Object);

			// Assert
			Assert.AreEqual(1, row.Columns[0].Containers.Length);
			Assert.AreEqual(2, row.Columns[1].Containers.Length);
			Assert.AreEqual(1, row.Columns[2].Containers.Length);
		}

		[TestMethod]
		public void AddContainer_2NormalContainers6ValuableContainers1Gap()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);
			var mockedNormal = new Mock<IFreightContainer>();
			mockedNormal.Setup(mock => mock.Type).Returns(FreightType.Normal);

			var row = new FreightContainerRow(7);

			// Act
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddGapsToValuableContainers();

			row.AddContainer(mockedNormal.Object);
			row.AddContainer(mockedNormal.Object);

			// Assert
			Assert.AreEqual(1, row.Columns[0].Containers.Length);
			Assert.AreEqual(2, row.Columns[1].Containers.Length);
			Assert.AreEqual(1, row.Columns[2].Containers.Length);
			Assert.AreEqual(0, row.Columns[3].Containers.Length);
			Assert.AreEqual(1, row.Columns[4].Containers.Length);
			Assert.AreEqual(2, row.Columns[5].Containers.Length);
			Assert.AreEqual(1, row.Columns[6].Containers.Length);
		}

		[TestMethod]
		public void AddContainer_3NormalContainers9ValuableContainers2Gaps()
		{
			// Arrange
			var mockedValuable = new Mock<IFreightContainer>();
			mockedValuable.Setup(mock => mock.Type).Returns(FreightType.Valuable);
			var mockedNormal = new Mock<IFreightContainer>();
			mockedNormal.Setup(mock => mock.Type).Returns(FreightType.Normal);

			var row = new FreightContainerRow(11);

			// Act
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddContainer(mockedValuable.Object);
			row.AddGapsToValuableContainers();

			row.AddContainer(mockedNormal.Object);
			row.AddContainer(mockedNormal.Object);
			row.AddContainer(mockedNormal.Object);

			// Assert
			Assert.AreEqual(1, row.Columns[0].Containers.Length);
			Assert.AreEqual(2, row.Columns[1].Containers.Length);
			Assert.AreEqual(1, row.Columns[2].Containers.Length);

			Assert.AreEqual(0, row.Columns[3].Containers.Length);

			Assert.AreEqual(1, row.Columns[4].Containers.Length);
			Assert.AreEqual(2, row.Columns[5].Containers.Length);
			Assert.AreEqual(1, row.Columns[6].Containers.Length);

			Assert.AreEqual(0, row.Columns[7].Containers.Length);

			Assert.AreEqual(1, row.Columns[8].Containers.Length);
			Assert.AreEqual(2, row.Columns[9].Containers.Length);
			Assert.AreEqual(1, row.Columns[10].Containers.Length);
		}
	}
}
