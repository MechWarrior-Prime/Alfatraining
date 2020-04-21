using Foundation;
using System;
using UIKit;

namespace My_First_App
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            btnTrigger.TouchUpInside += btnTrigger_TouchUpInside;
        }

        private void btnTrigger_TouchUpInside(object sender, EventArgs e)
        {
            lblOutput.Text = "Hello " + txtInputName.Text;
        }
        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}