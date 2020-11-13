using System.Collections;
using System.Linq;
using ContainerShip.Interfaces;

namespace ContainerShip
{
	public class FreightContainerRow : IFreightContainerRow, IEnumerable
	{
		public IFreightContainerColumn[] Columns { get; }

		public uint TotalWeight => Columns.Aggregate(0u, (accumulator, next) => accumulator + next.TotalWeight);

		public FreightContainerRow(uint columns)
		{
			this.Columns = new IFreightContainerColumn[columns];
			initializeContainerColomns();
		}

		private void initializeContainerColomns()
		{
			for (var i = 0; i < Columns.Length; ++i)
			{
				Columns[i] = new FreightContainerColumn();
			}
		}

		public IFreightContainerColumn this[int index] => Columns[index];

		public IEnumerator GetEnumerator()
		{
			return Columns.GetEnumerator();
		}
	}
}
