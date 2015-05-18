using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haytham
{
	/// <summary>
	/// Object used to hold informations about haytham external variables
	/// </summary>
	public class DataObject
	{		
		public Guid ClientId { get; set; }
		public bool IsRemoved { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Abbrevation { get; set; }
		public System.Drawing.Rectangle Position { get; set; }

		public int? ImageId { get; set; }
		public string ValueString { get; set; }	
	}
}
