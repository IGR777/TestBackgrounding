using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmCross.Platform;

namespace TestBackgrounding
{
	public class MyService: IMyService
	{

		public async void Calculate () {

			Mvx.Resolve<IBackgroundService> ().StartInBackground (async () => {

				Debug.WriteLine ("Calculate started");
				for (int i = 0; i < 20; i++) {
					await Task.Delay (1000);
					Debug.WriteLine (i);
				}

				Debug.WriteLine ("Calculate finished");
			});

		}
	}
}

