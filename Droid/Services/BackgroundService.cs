using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

namespace TestBackgrounding.Droid
{
	public class BackgroundService : IBackgroundService
	{
		public void StartInBackground (Func<Task> act) {

			var intent = new Intent (Application.Context, typeof (AndroidService));
			var connection = new AndroidServiceConnection ();
			Application.Context.BindService (intent, connection, Bind.AutoCreate);

			connection.ConnectionChanged += async (sender, e) => {
				if (e.IsConnected) {
					await connection.Service.Execute (act);
				} else {
					Application.Context.UnbindService (connection);
				}
			};

		}
	}
}

