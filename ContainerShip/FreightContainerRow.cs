using System;
using System.Collections;
using System.Linq;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public class FreightContainerRow : IFreightContainerRow
	{
		public IFreightContainerColumn[] Columns { get; }

		public uint TotalWeight => Columns.Aggregate(0u, (accumulator, next) => accumulator + next.TotalWeight);

		private int GetNumberOfValuableContainers()
			=> Columns.Where(column => column.HasValuableContainer()).Count();

		public FreightContainerRow(uint columns)
		{
			this.Columns = new IFreightContainerColumn[columns];
			InitializeContainerColumns();
		}

		private void InitializeContainerColumns()
		{
			for (var i = 0; i < Columns.Length; ++i)
			{
				Columns[i] = new FreightContainerColumn();
			}
		}

		private bool IsValuableContainerInColumnBlockedOnBothSides(int columnIndex)
		{
			if (columnIndex == 0 || columnIndex == (Columns.Length - 1))
			{
				return false;
			}

			var leftColumn = Columns[columnIndex - 1];
			var rightColumn = Columns[columnIndex + 1];
			var column = Columns[columnIndex];

			if (!column.HasValuableContainer())
				return false;

			return (leftColumn.Containers.Length >= column.Containers.Length) && 
				(rightColumn.Containers.Length >= column.Containers.Length);
		}

		private void AddValuableContainer(IFreightContainer container)
		{
			int numValuable = GetNumberOfValuableContainers();
			if (numValuable == Columns.Length)
			{
				throw new InvalidOperationException();
			}

			bool left = (numValuable % 2) == 0;

			int offset = (int)Math.Floor(numValuable / 2.0);
			int rightIndex = Columns.Length - 1 - offset;
			Columns[left ? offset : rightIndex].AddContainer(container);
		}

		private void AddNormalContainer(IFreightContainer container)
		{
			for (int i = 0; i < Columns.Length; ++i)
			{
				if (IsValuableContainerInColumnBlockedOnBothSides(i) && Columns[i].TryAddContainer(container))
					return;
			}

			throw new InvalidOperationException();
		}

		public void AddContainer(IFreightContainer container)
		{
			switch (container.Type)
			{
				case FreightType.Valuable:
					AddValuableContainer(container);
					break;
				case FreightType.Normal:
					AddNormalContainer(container);
					break;
				default:
					throw new NotImplementedException();
			}
		}

		private int GetNumberOfValuableContainerGaps()
		{
			int numValuable = GetNumberOfValuableContainers();
			return Columns.Length - numValuable;
		}

		private int GetNumNormalContainersForTriangle(int width)
		{
			int internalWidth = Math.Max(width - 2, 0);
			int internalHeight = (int)Math.Ceiling(internalWidth / 2.0);
			int internalArea = internalHeight * internalHeight;

			bool oddWidth = (internalWidth % 2) != 0;
			return internalArea + (oddWidth ? 0 : internalHeight);
		}

		public int GetRequiredNormalContainers()
		{
			int numValuable = GetNumberOfValuableContainers();
			int gaps = GetNumberOfValuableContainerGaps();

			int triangles = gaps + 1;
			int triangleWidth = (int)Math.Ceiling(numValuable / (double)triangles);

			int centerTriangleWidth = (int)Math.Floor((numValuable / (double)triangles));

			return (GetNumNormalContainersForTriangle(triangleWidth) * (triangles - 1)) + GetNumNormalContainersForTriangle(centerTriangleWidth);
		}

		void ShiftColumnsToCenter(int startIndex, bool rightToLeft)
		{
			double center = Columns.Length / 2.0;

			int aColumnIndex = rightToLeft ? (Columns.Length - 1 - startIndex) : startIndex;
			int bColumnIndex = 0;
			for (int i = startIndex; i < center; ++i)
			{
				int index = rightToLeft ? (Columns.Length - 1 - i) : i;
				if (Columns[index].Containers.Length == 0)
				{
					bColumnIndex = index;
					break;
				}
			}

			if (bColumnIndex == 0)
			{
				return;
			}

			var tmp = Columns[bColumnIndex];
			Columns[bColumnIndex] = Columns[aColumnIndex];
			Columns[aColumnIndex] = tmp;
		}

		public void AddGapsToValuableContainers()
		{
			int numValuable = GetNumberOfValuableContainers();
			int gaps = GetNumberOfValuableContainerGaps();

			int triangles = gaps + 1;
			int triangleWidth = (int)Math.Ceiling(numValuable / (double)triangles);

			for (int i = 0; i < Math.Floor(gaps / 2.0); ++i)
			{
				int n = triangleWidth * (i + 1) + i;

				ShiftColumnsToCenter(n, false);
				ShiftColumnsToCenter(n, true);
			}
		}
	}
}
