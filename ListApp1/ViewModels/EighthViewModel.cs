using ListApp1.Models;
using MVVMLib.ViewModels;
namespace ListApp1.ViewModels
{
	internal class EighthViewModel : NotificationObject
	{
		public EighthViewModel()
		{
			_message = "";
		}
		private string _messages;
		public string Messages
		{
			get { return this._messages; }
			set { SetProperty(ref this._messages, value ); }
		}

		private string _message;
		public string Message {
			get { return this._message; }
			set { SetProperty(ref this._message, value); }
		}

		// Command
		private DelegateCommand _addCommand;
		public DelegateCommand AddCommand {
			get {
				return this._addCommand ?? (this._addCommand = new DelegateCommand(
					_ =>
					{
						Messages += Message + "\n";
						Message = "";
						RaisePorpertyChanged("Messages");
						RaisePorpertyChanged("Message");
					}));
			}
		}

	}
}
