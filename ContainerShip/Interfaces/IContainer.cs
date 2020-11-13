using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContainerShip.Enums;

namespace ContainerShip.Interfaces
{
	public interface IContainer
	{
		FreightType Type { get; }
		int Weight { get; }
	}
}
