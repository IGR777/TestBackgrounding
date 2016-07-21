using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;

namespace TestBackgrounding.Droid
{
	[Service]
	public class AndroidService : Service
	{
		public override IBinder OnBind (Intent intent) {
			return new AndroidServiceBinder (this);
		}

		public async Task Execute (Func<Task> act) {
			await act();
			Console.WriteLine ("Android service execute finished");
		}

	}


	class AndroidServiceBinder : Binder
	{
		public AndroidService AndroidService { get; set; }

		public AndroidServiceBinder (AndroidService androidService) {
			AndroidService = androidService;
		}
	}

	public class AndroidServiceConnection : Java.Lang.Object, IServiceConnection
	{
		IBinder _binder;

		public AndroidService Service {
			get {
				return ((AndroidServiceBinder)_binder).AndroidService;
			}
		}

		public event EventHandler<ServiceConnectionEventArgs> ConnectionChanged;

		public void OnServiceConnected (ComponentName name, IBinder service) {
			var b = service as AndroidServiceBinder;
			if (b != null) {
				_binder = service;
				ConnectionChanged?.Invoke (this, new ServiceConnectionEventArgs (true));
			}
		}

		public void OnServiceDisconnected (ComponentName name) {
			_binder = null;
			ConnectionChanged?.Invoke (this, new ServiceConnectionEventArgs (false));
		}
	}

	public class ServiceConnectionEventArgs
	{
		public bool IsConnected { get; set; }
		public ServiceConnectionEventArgs (bool isConnected)
		{
			IsConnected = isConnected;
		}
	}
}

