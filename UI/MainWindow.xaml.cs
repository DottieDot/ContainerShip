using ContainerShip;
using ContainerShip.Enums;
using ContainerShip.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		uint _shipLength = 1;
		uint _shipWidth = 1;

		public uint ShipLength { get => _shipLength; set { _shipLength = Math.Max(value, 1); } }
		public uint ShipWidth { get => _shipWidth; set { _shipWidth = Math.Max(value, 1); } }

		uint _numContainers = 1;
		uint _cargoWeight = 0;

		public uint NumContainers { get => _numContainers; set { _numContainers = Math.Max(value, 1); } }
		public uint CargoWeight { get => _cargoWeight; set { _cargoWeight = Math.Min(value, 26_000); }  }

		public ObservableCollection<IFreightContainer> Containers { get; set; } = new ObservableCollection<IFreightContainer>();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void btnAddContainers_Click(object sender, RoutedEventArgs e)
		{
			for (int i = 0; i < _numContainers; ++i)
			{
				Containers.Add(new FreightContainer(FreightType.Normal, _cargoWeight));
			}
		}

		private void dgContainers_LoadingRow(object sender, DataGridRowEventArgs e)
		{
			e.Row.Header = e.Row.GetIndex() + 1;
		}
	}
}
