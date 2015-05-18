using System;
using System.ServiceModel.Discovery;

namespace Haytham.ExtData
{
	/// <summary>
	/// class used for automatic haytham discovery on local network
	/// </summary>
	public class ClientDiscovery : IDisposable
	{

		DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
		Action<Uri> onHostFound;
		System.Timers.Timer timer;

		public ClientDiscovery(Action<Uri> onFound)
		{
			this.onHostFound = onFound;

			discoveryClient.FindProgressChanged += discoveryClient_FindProgressChanged;
			this.t_Elapsed(null, null);

			this.timer = new System.Timers.Timer(20000);			
			this.timer.Elapsed += t_Elapsed;
			this.timer.Start();			

		}

		void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			discoveryClient.FindAsync(new FindCriteria(typeof(IExtDataService)) { Duration = TimeSpan.FromSeconds(5) });
		}
		void discoveryClient_FindProgressChanged(object sender, FindProgressChangedEventArgs e)
		{
			this.onHostFound(e.EndpointDiscoveryMetadata.Address.Uri);
		}


		public void Dispose()
		{
			discoveryClient.Close();
			this.timer.Stop();
			this.timer.Dispose();
		}

		public void Force()
		{
			this.timer.Stop();
			this.t_Elapsed(null, null);
			this.timer.Start();
		}
	}
}
