using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nol3.Communication;
using Nol3.Communication.Tools;
using System.Threading;

namespace Nol3.Communication.ConsoleTestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			SaveConfig();

			var nol3Clinet = Nol3Client.GetNol3Client(Nol3RegistryReader.Settings);
			Nol3EventHandlersConfiguration(nol3Clinet);
			ConsoleKey key = ConsoleKey.D;

			MainLoop(nol3Clinet, key);

			Console.WriteLine("\n Nacisnij Enter aby zakończuyć.");
			Console.ReadLine();
		}

		private static void MainLoop(Nol3Client nol3Clinet, ConsoleKey key)
		{
			Console.WindowHeight= (int)Math.Floor(Console.WindowHeight * 1.5);


			while (key != ConsoleKey.Escape)
			{
				//Console.Clear();
				Console.WriteLine("1. Logowanie");
				Console.WriteLine("2. WyLogowanie");
				Console.WriteLine("ESC. Koniec");
				key = Console.ReadKey().Key;
				switch (key)
				{
					case ConsoleKey.NumPad1:
						nol3Clinet.LoginNol3();
						break;
					case ConsoleKey.NumPad2:
						nol3Clinet.LogoutNol3();
						break;
					case ConsoleKey.Escape:
						break;
					default:
						Console.WriteLine("zły wybór");
						Thread.Sleep(1000);
						break;
				}
			}

		}

		private static void Nol3EventHandlersConfiguration(Nol3Client nol3Clinet)
		{
			nol3Clinet.BusinessMessageRejectEvent += (obj) => {
				Console.WriteLine("\nBusinessMessageReject".ToUpper()+" : {0}, Reason: {1}, Type : {2}"
					, obj.Text, obj.BusinessRejectReason, obj.RefMsgType);
			};
			nol3Clinet.UnknownMessageTypeEvent += (obj) => {
				Console.WriteLine("\nUnknownMessageType".ToUpper() + " : {0}", obj.ToString());
			};
			nol3Clinet.UserResponseEvent += (obj) => {
				Console.WriteLine("\nUserResponse".ToUpper() + " : {0}, UserName: {1}, Status : {2}, MarketDepth: {3} ",
					obj.UserStatusText , obj.Username, obj.UserStatus,  obj.MarketDepth);
			};
		}

		private static void SaveConfig()
		{
			Nol3ConfigurationManager.SaveConfiguration(new Tools.Model.Nol3Configuration
			{
				ID = Convert.ToInt32(Nol3ConfigurationManager.GetConfiguration().ID),
				Login = "BOS",
				Password = "BOS"
			});
		}
	}
}
