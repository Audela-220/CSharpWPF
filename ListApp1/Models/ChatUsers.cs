using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListApp1.Models
{
	internal class ChatUsers
	{
		private List<ChatUser> _users;
		public List<ChatUser> Users
		{
			get { return this._users; }
			set { this._users = value; }
		}
	}
}