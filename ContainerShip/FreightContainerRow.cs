using System.Collections;
using System.Linq;
using ContainerShip.Interfaces;

namespace ContainerShip
{
	class FreightContainerRow : IFreightContainerRow, IEnumerable
	{
		public IFreightContainerColomn[] Colomns { get; }

		public uint TotalWeight => Colomns.Aggregate(0u, (accumulator, next) => accumulator + next.TotalWeight);

		public FreightContainerRow(uint colomns)
		{
			this.Colomns = new IFreightContainerColomn[colomns];
			initializeContainerColomns();
		}

		private void initializeContainerColomns()
		{
			for (int i = 0; i < Colomns.Length; ++i)
			{
				Colomns[i] = new FreightContainerColomn();
			}
		}

		public IFreightContainerColomn this[int index] => Colomns[index];

		public IEnumerator GetEnumerator()
		{
			return Colomns.GetEnumerator();
		}
	}
}
