using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using ContainerShip.Interfaces;

namespace ContainerShip
{
	public class FreightContainerColomn : IFreightContainerColomn, IEnumerable
	{
		readonly List<IFreightContainer> _containers = new List<IFreightContainer>();

		public IFreightContainer[] Containers => _containers.ToArray();

		public uint TotalWeight => _containers.Aggregate(0u, (accumulator, next) => accumulator + next.Weight);

		public IFreightContainer this[int index] => _containers[index];

		public IEnumerator GetEnumerator()
		{
			return _containers.GetEnumerator();
		}

		public bool CanAddContainer(IFreightContainer container)
		{
			return (TotalWeight + container.Weight) <= 120_000;
		}

		public void AddContainer(IFreightContainer container)
		{
			if (CanAddContainer(container))
			{
				_containers.Add(container);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

		public bool TryAddContainer(IFreightContainer container)
		{
			try
			{
				AddContainer(container);
				return true;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
		}
	}
}
