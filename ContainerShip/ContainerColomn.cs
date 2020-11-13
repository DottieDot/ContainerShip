using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using ContainerShip.Interfaces;

namespace ContainerShip
{
	public class ContainerColomn : IContainerColomn, IEnumerable
	{
		List<IContainer> _containers;

		public IContainer[] Containers => _containers.ToArray();

		public uint TotalWeight => _containers.Aggregate(0u, (accumulator, next) => accumulator + next.Weight);

		public IContainer this[int index] => _containers[index];

		public IEnumerator GetEnumerator()
		{
			return _containers.GetEnumerator();
		}

		public bool CanAddContainer(IContainer container)
		{
			return (TotalWeight + container.Weight) <= 120_000;
		}

		public void AddContainer(IContainer container)
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

		public bool TryAddContainer(IContainer container)
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
