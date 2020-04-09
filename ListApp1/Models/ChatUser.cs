using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp1.Models
{
	public class ChatUser
	{
		public string Account   { get; set; }
		public string Name      { get; set; }
		public string IPAddress { get; set; }
		public bool   Connected { get; set; }
		public ChatUser()
		{
			Account = "";
			Name = "";
			IPAddress = "";
			Connected = false;
		}
		public ChatUser( string csvLine ) : base()
		{
			string[] parts = csvLine.Split( new char[] { ',' } );
			if( parts.Length == 3 ) {
				Account   = parts[0];
				Name      = parts[1];
				IPAddress = parts[2];
			}
		}
	}
}
