using System;
using System.Drawing;

using UIKit;

namespace TapIcons
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		UIButton imgButton;
		string[] images;
		Random rand;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			imgButton = UIButton.FromType(UIButtonType.Custom);
			imgButton.Frame = new RectangleF(0, 0, float.Parse(View.Bounds.Width.ToString()),
											 float.Parse(View.Bounds.Height.ToString()));

			imgButton.SetImage(UIImage.FromFile("blank.png"), UIControlState.Normal);
			View.AddSubview(imgButton);

			images = new string[6];
			images[0] = "red.png";
			images[1] = "orange.png";
			images[2] = "yellow.png";
			images[3] = "green.png";
			images[4] = "blue.png";
			images[5] = "purple.png";

			rand = new Random();

			var imageSwitch = false;
			imgButton.TouchUpInside += delegate
			{
				if (imageSwitch)
				{
					imgButton.SetImage(UIImage.FromFile(images[rand.Next(0,6)]), UIControlState.Normal);
					imageSwitch = false;
				}
				else
				{
					imgButton.SetImage(UIImage.FromFile("blank.png"), UIControlState.Normal);
					imageSwitch = true;
				}
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

