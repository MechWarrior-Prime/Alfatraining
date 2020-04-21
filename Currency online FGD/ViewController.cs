using Foundation;
using System;
using UIKit;

namespace Currency_online_FGD
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var pickerModel = new CurrencyModel(lblOutput);
            //personPicker.Model = pickerModel;
            pvSource.Model = pickerModel;
            pvTarget.Model = pickerModel;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}