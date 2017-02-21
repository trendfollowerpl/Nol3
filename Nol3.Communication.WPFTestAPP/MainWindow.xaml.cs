using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nol3.Communication;

namespace Nol3.Communication.WPFTestAPP
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Nol3Client _nol3Clinet;
		public MainWindow()
		{
			InitializeComponent();
			_nol3Clinet = Nol3Client.GetNol3Client(Nol3RegistryReader.Settings);
		}

		private void loginButton_Click(object sender, RoutedEventArgs e)
		{
			_nol3Clinet.LoginNol3();
		}

		private void logoutbutton_Click(object sender, RoutedEventArgs e)
		{
			_nol3Clinet.LogoutNol3();
		}
	}
}
