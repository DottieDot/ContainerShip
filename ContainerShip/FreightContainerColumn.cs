using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using ContainerShip.Interfaces;
using ContainerShip.Enums;

namespace ContainerShip
{
	public class FreightContainerColumn : IFreightContainerColumn, IEnumerable
	{
		private readonly List<IFreightContainer> _containers = new List<IFreightContainer>();

		public IFreightContainer[] Containers => _containers.ToArray();

		public uint TotalWeight => _containers.Aggregate(0u, (accumulator, next) => accumulator + next.Weight);

		public IFreightContainer this[int index] => _containers[index];

		public IEnumerator GetEnumerator()
		{
			return _containers.GetEnumerator();
		}

		public bool HasValuableContainer()
		{
			return _containers.Find(container => container.Type == FreightType.Valuable) != null;
		}

		public bool CanAddContainer(IFreightContainer container)
		{
			if (HasValuableContainer() && container.Type == FreightType.Valuable)
				return false;

			return (TotalWeight + container.Weight) <= 120_000;
		}

		public void AddContainer(IFreightContainer container)
		{
			if (CanAddContainer(container))
			{
				if (container.Type == FreightType.Valuable)
				{
					_containers.Add(container);
				}
				else
				{
					_containers.Insert(0, container);
				}
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
