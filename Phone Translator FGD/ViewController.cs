using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Phone_Translator_FGD

    https://docs.microsoft.com/de-de/xamarin/ios/get-started/hello-ios/
{
    public partial class ViewController : UIViewController
{
    private string lsTranslatedNumber = "";
    public List<String> PhoneNumbers { get; set; }

    public ViewController(IntPtr handle) : base(handle)
    {
        PhoneNumbers = new List<string>();
    }

    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        // Perform any additional setup after loading the view, typically from a nib.
        btnTranslate.TouchUpInside += BtnTranslate_TouchUpInside;
        btnCall.TouchUpInside += BtnCall_TouchUpInside;
        //btnCallHistory.TouchUpInside += BtnCallHistory_TouchUpInside;
    }

    private void BtnCallHistory_TouchUpInside(object sender, EventArgs e)
    {
    }

    private void BtnCall_TouchUpInside(object sender, EventArgs e)
    {
        var url = new NSUrl("tel:" + lsTranslatedNumber);// using URL handler to dial by using iPhone telephone app
        PhoneNumbers.Add(lsTranslatedNumber);
        if (!UIApplication.SharedApplication.OpenUrl(url))
        {
            var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device",
                UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("OK...", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);// modal dialog
        }
    }

    private void BtnTranslate_TouchUpInside(object sender, EventArgs e)
    {
        lsTranslatedNumber = PhoneTranslator.ToNumber(txtPhoneword.Text);
        txtPhoneword.ResignFirstResponder();
        if (lsTranslatedNumber == "")
        {
            btnCall.SetTitle("Call", UIControlState.Normal);
            btnCall.Enabled = false;
        }
        else
        {
            btnCall.SetTitle("Call " + lsTranslatedNumber, UIControlState.Normal);
            btnCall.Enabled = true;
        }
    }

    public override void DidReceiveMemoryWarning()
    {
        base.DidReceiveMemoryWarning();
        // Release any cached data, images, etc that aren't in use.
    }

    public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
    {
        base.PrepareForSegue(segue, sender);
        // set the ViewController that is to be shown
        var callHistoryController = segue.DestinationViewController as CallHistoryController;
        // set list to list
        if (callHistoryController != null)
        {
            callHistoryController.PhoneNumbers = PhoneNumbers;
        }
    }
}
}