using System;
using System.Threading.Tasks;

namespace TestBackgrounding
{
	public interface IBackgroundService
	{
		void StartInBackground (Func<Task> act);
	}
}

