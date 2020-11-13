using System;
using System.Linq;
using ContainerShip.Interfaces;

namespace ContainerShip
{
	class ContainerShip : IContainerShip
	{
		public uint Width { get; }

		public uint Length { get; }

		public IFreightContainerRow[] ContainerRows { get; }

		public ContainerShip(uint width, uint length)
		{
			this.Width = width;
			this.Length = length;
			ContainerRows = new IFreightContainerRow[length];
			this.populateContainerRows();

			if (width == 0 || length == 0)
			{
				throw new ArgumentException();
			}
		}

		private void populateContainerRows()
		{
			for (int i = 0; i < Length; ++i)
			{
				ContainerRows[i] = new FreightContainerRow(Width);
			}
		}

		private double getLeftWeight() => ContainerRows.Take((int)Math.Floor(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		private double getRightWeight() => ContainerRows.Skip((int)Math.Ceiling(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		private double getWeightBalanceRatio()
		{
			double leftWeight = getLeftWeight();
			double rightWeight = getRightWeight();

			return (leftWeight / rightWeight) - 1;
		}

		public bool IsBalanced() => Math.Abs(getWeightBalanceRatio()) < .2;
	}
}
