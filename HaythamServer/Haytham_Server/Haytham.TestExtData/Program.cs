

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Haytham.ExtData;

namespace Haytham.TestExtData
{
	class Program
	{
		static void Main(string[] args)
		{
			var col = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Hit ENTER when Haytham is running and enabled in firewall.");
			Console.ForegroundColor = col;
			Console.ReadLine();

			//find haytham hosts on network
			Console.WriteLine("Searching for host ... ");
			var host = Client.getActiveHosts().FirstOrDefault();
			//if no haytham on net .. kill me
			if (host == null)
			{
				//host not found
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Haytham not found on network. :o(( .. Bye!");
				Console.ForegroundColor = col;
				return;
			}

			Console.WriteLine("Found host: {0}", host);
			var client = Client.GetClient(host);

			//setup new variable
			Console.WriteLine("Registering variable");
			var varId = client.Register("Test variable", "TV");			
			client.SetPosition(varId, 0, 0, 100, 22);	//ideal height for default font .. 22

			bool loop = true;
			//push data in separate thread
			Console.WriteLine("Pushing data ...");
			var task = System.Threading.Tasks.Task.Factory.StartNew(() =>
				{					
					var clientData = 0;
					while (loop)
					{
						//prepare data
						clientData++;
						if (clientData > 1000)
							clientData = 0;
						
						//push them
						client.PushData(varId, clientData.ToString(), null);
						System.Threading.Thread.Sleep(500);
					}
					//remove all my variables from haytham
					client.Clear();
					client.Dispose();
				});

			Console.WriteLine("Push any key to end");
			Console.ReadKey();
			loop = false;
			//wait for data thread to end
			task.Wait();
		}
	}
}
