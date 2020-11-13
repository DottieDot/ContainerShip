using System;
using System.Linq;
using ContainerShip.Interfaces;

namespace ContainerShip
{
	public class ContainerShip : IContainerShip
	{
		public uint Width { get; }

		public uint Length { get; }

		public IFreightContainerRow[] ContainerRows { get; }

		public ContainerShip(uint width, uint length)
		{
			this.Width = width;
			this.Length = length;
			ContainerRows = new IFreightContainerRow[length];
			initializeContainerRows();

			if (width == 0 || length == 0)
			{
				throw new ArgumentException();
			}
		}

		private void initializeContainerRows()
		{
			for (var i = 0; i < ContainerRows.Length; ++i)
			{
				ContainerRows[i] = new FreightContainerRow(Width);
			}
		}

		private double getLeftWeight() => ContainerRows.Take((int)Math.Floor(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		private double getRightWeight() => ContainerRows.Skip((int)Math.Ceiling(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		public double GetWeightBalanceRatio()
		{
			var leftWeight = getLeftWeight();
			var rightWeight = getRightWeight();

			return (leftWeight / rightWeight) - 1;
		}

		public bool IsBalanced() => Math.Abs(GetWeightBalanceRatio()) < .2;
	}
}
