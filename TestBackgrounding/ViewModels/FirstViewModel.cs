using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace TestBackgrounding.ViewModels
{
    public class FirstViewModel 
        : MvxViewModel
    {
       
		public IMvxCommand Command {
			get {
				return new MvxCommand (() => {
					Mvx.Resolve<IMyService> ().Calculate ();
				});
			}
		}

    }
}
