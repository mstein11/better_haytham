using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading.Tasks;

namespace Haytham.ExtData
{
	/// <summary>
	/// Class used by external SW to send data do Haytham
	/// </summary>
	public class Client : IDisposable
	{
		private ChannelFactory<IExtDataService> infoFactory = null;
		private IExtDataService client = null;
		private object resetToken = new object();
		public Uri Uri { get; set; }
		private Guid MyClientId = Guid.NewGuid();

		public static IEnumerable<Uri> getActiveHosts()
		{
			DiscoveryClient discoveryClient =
			   new DiscoveryClient(new UdpDiscoveryEndpoint());

			System.Collections.ObjectModel.Collection<EndpointDiscoveryMetadata> cielServices =
				discoveryClient.Find(new FindCriteria(typeof(IExtDataService)) { Duration = TimeSpan.FromSeconds(2) }).Endpoints;			

			discoveryClient.Close();

			return cielServices
				.Select(cs => cs.Address.Uri);
		}

		public static Client GetClient(Uri addr)
		{
			return Client.GetClient(new EndpointAddress(addr));
		}
		internal static Client GetClient(EndpointAddress addr)
		{
			var client = new Client();
			client.Uri = addr.Uri;
			return client.Init(addr);
		}

		private Client Init(EndpointAddress addr)
		{
			if (infoFactory == null)
			{
				NetTcpBinding netTcpBinding = new NetTcpBinding(SecurityMode.None);
				netTcpBinding.ReliableSession.Enabled = true;
				netTcpBinding.ReliableSession.InactivityTimeout = new TimeSpan(1, 0, 0);
				netTcpBinding.ReceiveTimeout = new TimeSpan(0, 10, 0);
				netTcpBinding.SendTimeout = new TimeSpan(0, 0, 10);
				netTcpBinding.OpenTimeout = new TimeSpan(0, 0, 10);

				this.infoFactory = new ChannelFactory<IExtDataService>(netTcpBinding, addr);				
			}

			this.infoFactory.Open();
			this.client = infoFactory.CreateChannel();
			
			try
			{				
				this.client.Reset(this.MyClientId);
			}
			catch (Exception)
			{
				this.infoFactory.Abort();
				return null;				
			}

			return this;
		}
		public void Dispose()
		{
			if (this.infoFactory != null)
			{
				this.client.Reset(this.MyClientId);				
				this.infoFactory.Abort();
				
				this.infoFactory = null;
				this.client = null;
			}
		}
		public void Refresh(EndpointAddress addr = null)
		{
			lock (this.resetToken)
			{
				if (addr == null)
					addr = this.infoFactory.Endpoint.Address;

				this.Dispose();
				this.Init(addr);
			}
		}


		public event EventHandler Faulted;
		private void factory_Faulted(object sender, EventArgs e)
		{
			if (this.Faulted != null)
				this.Faulted(this, e);

			this.Refresh();
		}

		/// <summary>
		/// Function registers new imported variable
		/// </summary>
		/// <param name="name">name of variable used in export of data into csv file while haytham is recording video</param>
		/// <param name="abbr">abbrevation used in video</param>
		/// <returns>index of created variable</returns>
		public int Register(string name, string abbr)
		{
			if (client == null || this.infoFactory.State != CommunicationState.Opened)
				this.Refresh();

			var result = this.client.Register(name, abbr, this.MyClientId);

			if (result < 0)
				throw new Exception("Unable to register");
			return result;
		}
		/// <summary>
		/// Function removes variable from haytham variables list	//TODO may be buggy
		/// </summary>
		/// <param name="id">id of variable</param>
		public void UnRegister(int id)
		{
			if (client == null || this.infoFactory.State != CommunicationState.Opened)
				this.Refresh();

			this.client.UnRegister(id);
		}
		/// <summary>
		/// Functin for preloading icons into haytham
		/// </summary>
		/// <param name="fullPath"></param>
		/// <returns></returns>
		public int? LoadImage(string fullPath)
		{
			if (client == null || this.infoFactory.State != CommunicationState.Opened)
				this.Refresh();

			var result = this.client.LoadImage(fullPath);
			if (result == null)
				throw new Exception("Unable to load image. Please check fullpath");
			return result;
		}
		/// <summary>
		/// set change variable rectangle on screen
		/// </summary>
		/// <param name="id">id of variable</param>
		/// <param name="x">x</param>
		/// <param name="y">y</param>
		/// <param name="width">w</param>
		/// <param name="height">h</param>
		public void SetPosition(int id, int x, int y, int width, int height)
		{
			if (client == null || this.infoFactory.State != CommunicationState.Opened)
				this.Refresh();

			Task.Factory.StartNew(() => this.client.SetPosition(id, x, y, width, height));
		}
		/// <summary>
		/// push data into haytham
		/// </summary>
		/// <param name="id">id of variable</param>
		/// <param name="valueString">string value</param>
		/// <param name="imgId">optional icon id (icon must be preloaded with LoadImage function)</param>
		public void PushData(int id, string valueString, int? imgId)
		{
			if (client == null || this.infoFactory.State != CommunicationState.Opened)
				this.Refresh();

			Task.Factory.StartNew(() => this.client.PushData(id, valueString, imgId));
		}
		/// <summary>
		/// removes all variables of current client from haytham variable list
		/// </summary>
		public void Clear()
		{			
			if (client == null || this.infoFactory.State != CommunicationState.Opened)
				this.Refresh();

			this.client.Reset(this.MyClientId);
		}
	}
}
