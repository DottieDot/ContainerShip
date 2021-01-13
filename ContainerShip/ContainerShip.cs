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

		private IEnumerable<IFreightContainer> PlaceNormalContainersIntoPiramides(IFreightContainer[] containers)
		{
			int nextContainerIndex = 0;
			foreach (var row in ContainerRows)
			{
				int numRequired = row.GetRequiredNormalContainers();
				for (int i = 0; i < numRequired; ++i)
				{
					if (nextContainerIndex >= containers.Length)
					{
						throw new InvalidOperationException();
					}

					row.AddContainer(containers[nextContainerIndex]);
					++nextContainerIndex;
				}
			}

			return containers.Skip(nextContainerIndex);
		}

		private void PlaceRemainingNormalContainers(IEnumerable<IFreightContainer> containers)
		{
			int nextContainerIndex = 0;
			var heaviest = containers.Reverse().ToArray();

			foreach (var row in ContainerRows)
			{
				if (row.TryAddContainer(heaviest[nextContainerIndex]))
				{
					++nextContainerIndex;
					if (nextContainerIndex == heaviest.Length)
					{
						break;
					}
				}
			}
		}

		private void PlaceNormalContainers(IFreightContainer[] containers)
		{
			var remainingContainers = PlaceNormalContainersIntoPiramides(containers);
			if (remainingContainers.Count() != 0)
			{
				PlaceRemainingNormalContainers(remainingContainers);
			}
		}

		public void LoadContainers(IEnumerable<IFreightContainer> containers)
		{
			var valuableContainers = containers
				.Where(container => container.Type == FreightType.Valuable)
				.OrderByDescending(container => container.Weight)
				.ToArray();
			var normalContainers = containers
				.Where(container => container.Type == FreightType.Normal)
				.OrderBy(container => container.Weight)
				.ToArray();

			PlaceValuableContainers(valuableContainers);
			PlaceNormalContainers(normalContainers);

			for (int i = 0; i < ContainerRows.Length; ++i)
			{
				if ((i % 2) == 0)
				{
					ContainerRows[i].ReverseColumns();
				}
			}
		}

		private double GetLeftWeight() => ContainerRows.Take((int)Math.Floor(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		private double GetRightWeight() => ContainerRows.Skip((int)Math.Ceiling(Length / 2.0)).Aggregate(0.0, (accumulator, next) => accumulator + next.TotalWeight);

		public double GetWeightBalanceRatio()
		{
			var leftWeight = GetLeftWeight();
			var rightWeight = GetRightWeight();

			return (leftWeight / rightWeight) - 1;
		}
	}
}
