using System;
using System.ServiceModel;

namespace Haytham.ExtData
{
	/// <summary>
	/// WCF service interface
	/// </summary>
	[ServiceContract]
    public interface IExtDataService
    {				
		[OperationContract]
		int Register(string name, string abbr, Guid clientId);
		[OperationContract]
		void UnRegister(int id);
		[OperationContract]
		void Reset(Guid clientId);
		[OperationContract]
		int? LoadImage(string fullPath);
		[OperationContract]
		void SetPosition(int id, int x, int y, int width, int height);		
		
		[OperationContract]
		void PushData(int id, string valueString, int? imgId);		
    }
}
