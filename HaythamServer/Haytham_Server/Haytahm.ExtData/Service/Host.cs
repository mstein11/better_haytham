using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;

namespace Haytham.ExtData
{
	/// <summary>
	/// WCF host used by haytham to self-host service
	/// </summary>
	public class Host : IDisposable
	{
		private ServiceHost serviceHost;
		private object resetToken = new object();
		int port = 4502;

		public int Port
		{
			get { return port; }
		}

		public Uri BaseAddress { get; private set; }
		public ExtDataService Reciever { get; private set; }		

		public Host()
		{
			this.setBaseAddress();
			this.Reciever = new ExtDataService();
		}

		public void setBaseAddress()
		{
			this.BaseAddress = new Uri(string.Format("net.tcp://{0}:{2}/Haytham/{1}/",
			   System.Net.Dns.GetHostName(), DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"), this.port));
		}

		public Host StartHost(IEnumerable<Uri> hosts = null)
		{
			if (hosts != null)
			{
				var portNew = hosts
					 .Select(h => h.Port)
					 .OrderBy(x => x)
					 .LastOrDefault() + 1;

				this.port = portNew > 1 ? portNew : port;
			}
			this.setBaseAddress();

			// Create a ServiceHost for the CalculatorService type.
			serviceHost = new ServiceHost(this.Reciever, this.BaseAddress);
			//serviceHost = new ServiceHost(typeof(InfoReciever), this.BaseAddress);

			NetTcpBinding netTcpBinding = new NetTcpBinding(SecurityMode.None);
			netTcpBinding.ReliableSession.Enabled = true;
			//netTcpBinding.PortSharingEnabled = true;
			//netTcpBinding.ReliableSession.Ordered = true;
			netTcpBinding.ReliableSession.InactivityTimeout = new TimeSpan(1, 0, 0);
			netTcpBinding.ReceiveTimeout = new TimeSpan(1, 0, 0);
			netTcpBinding.SendTimeout = new TimeSpan(1, 0, 0);
			netTcpBinding.OpenTimeout = new TimeSpan(1, 0, 0);


			//ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
			//smb.HttpGetEnabled = true;
			//smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
			//serviceHost.Description.Behaviors.Add(smb);

			// add calculator endpoint
			serviceHost.AddServiceEndpoint(typeof(IExtDataService), netTcpBinding, string.Empty);

			// ** DISCOVERY ** //
			// make the service discoverable by adding the discovery behavior
			serviceHost.Description.Behaviors.Add(new ServiceDiscoveryBehavior());

			// ** DISCOVERY ** //
			// add the discovery endpoint that specifies where to publish the services
			serviceHost.AddServiceEndpoint(new UdpDiscoveryEndpoint());			

			serviceHost.Faulted += serviceHost_Faulted;

			// Open the ServiceHost to create listeners and start listening for messages.
			serviceHost.Open();

			return this;
		}
		private void StopHost(bool abort = false)
		{
			if (this.serviceHost != null)
			{
				if (abort)
					this.serviceHost.Abort();
				else
					this.serviceHost.Close(TimeSpan.FromSeconds(1));
			}
		}
		public void Dispose()
		{
			StopHost();
			this.Reciever = null;
		}
		public void Reset()
		{
			lock (this.resetToken)
			{
				this.StopHost(true);
				this.StartHost();
			}
		}


		public event EventHandler Faulted;
		private void serviceHost_Faulted(object sender, EventArgs e)
		{
			if (this.Faulted != null)
				this.Faulted(this, e);

			this.Reset();
		}

	}
}
