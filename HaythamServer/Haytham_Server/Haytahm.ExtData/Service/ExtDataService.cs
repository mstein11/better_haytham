using System;
using System.ServiceModel;

namespace Haytham.ExtData
{
	/// <summary>
	/// WCF service ised by haytham to recieva data
	/// </summary>
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ExtDataService : IExtDataService
	{
		public IExtDataService Handler { get; set; }

		public int Register(string name, string abbr, Guid clientId)
		{
			if (this.Handler != null)
				return this.Handler.Register(name, abbr, clientId);
			return -1;
		}

		public void UnRegister(int id)
		{
			if (this.Handler != null)
				this.Handler.UnRegister(id);
		}

		public int? LoadImage(string fullPath)
		{
			if (this.Handler != null)
				return this.Handler.LoadImage(fullPath);
			return null;
		}

		public void SetPosition(int id, int x, int y, int width, int height)
		{
			if (this.Handler != null)
				this.Handler.SetPosition(id, x, y, width, height);
		}

		public void PushData(int id, string valueString, int? imgId)
		{
			if (this.Handler != null)
				this.Handler.PushData(id, valueString, imgId);
		}

		public void Reset(Guid clientId)
		{
			if (this.Handler != null)
				this.Handler.Reset(clientId);
		}
	}
}
