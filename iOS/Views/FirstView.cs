using System;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using TestBackgrounding.ViewModels;
using CoreImage;

namespace TestBackgrounding.iOS
{
	public partial class FirstView : MvxViewController
	{
		public FirstView () : base ("FirstView", null) {
		}

		public override void ViewDidLoad () {
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			var set = this.CreateBindingSet<FirstView, FirstViewModel> ();
			set.Bind (MyButton).To (vm=>vm.Command);
			set.Apply ();
			    
		}

		public override void DidReceiveMemoryWarning () {
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


