using System;
using System.Threading.Tasks;
using UIKit;
namespace TestBackgrounding.iOS
{
	public class BackgroundService : IBackgroundService
	{
		public async void StartInBackground (Func<Task> act) {
			nint taskId = 0;
			taskId = UIApplication.SharedApplication.BeginBackgroundTask (() => {
				Console.WriteLine ("Task canceled");
				UIApplication.SharedApplication.EndBackgroundTask (taskId);
			});

			try {
				await act ();
			} finally {
				UIApplication.SharedApplication.EndBackgroundTask (taskId);
			}
		}
	}
}

