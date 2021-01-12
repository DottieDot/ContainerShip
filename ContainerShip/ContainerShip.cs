using System;
using System.Linq;
using ContainerShip.Interfaces;
using System.Collections.Generic;
using ContainerShip.Enums;

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
			InitializeContainerRows();

			if (width == 0 || length == 0)
			{
				throw new ArgumentException();
			}
		}

		private void InitializeContainerRows()
		{
			for (var i = 0; i < ContainerRows.Length; ++i)
			{
				ContainerRows[i] = new FreightContainerRow(Width);
			}
		}

		private void PlaceValuableContainers(IFreightContainer[] containers)
		{
			int containersPerRow = (int)(containers.Length / (double)Length);

			for (int i = 0; i < containers.Length; ++i)
			{
				var row = ContainerRows[(int)Math.Floor((i + 1) / (double)containersPerRow)];
				row.AddContainer(containers[i]);
			}

			foreach (var row in ContainerRows)
			{
				row.AddGapsToValuableContainers();
			}
		}

		private void PlaceNormalContainers(IFreightContainer[] containers)
		{
			int nextContainerIndex = 0;
			foreach (var row in ContainerRows)
			{
				int numRequired = row.GetRequiredNormalContainers();
				for (int i = 0; i < numRequired; ++i)
				{
					row.AddContainer(containers[nextContainerIndex]);
					++nextContainerIndex;
				}
			}
		}

		public void LoadContainers(IFreightContainer[] containers)
		{
			var valuableContainers = containers.Where(container => container.Type == FreightType.Valuable).ToArray();
			var normalContainers = containers.Where(container => container.Type == FreightType.Normal).ToArray();

			PlaceValuableContainers(valuableContainers);
			PlaceNormalContainers(normalContainers);
		}

		private double GetLeftWeight() => ContainerRows.Take((int)Math.Floor(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		private double GetRightWeight() => ContainerRows.Skip((int)Math.Ceiling(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		public double GetWeightBalanceRatio()
		{
			var leftWeight = GetLeftWeight();
			var rightWeight = GetRightWeight();

			return (leftWeight / rightWeight) - 1;
		}

		public bool IsBalanced() => Math.Abs(GetWeightBalanceRatio()) < .2;
	}
}
