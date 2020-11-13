using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Interfaces
{
	public interface IContainerRow
	{
		IContainerColomn[] Colomns { get; }
		int TotalWeight { get; }
	}
}
