using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip.Interfaces
{
	public interface IContainerShip
	{
		int Width { get; }
		int Length { get; }
		IContainerRow[] ContainerRows { get; }
	}
}
