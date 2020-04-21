using Foundation;
using System;
using UIKit;

namespace Farbwechsler_FGD
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

            slrRed.ValueChanged += sldrChange;
            slrGreen.ValueChanged += sldrChange;
            slrBlue.ValueChanged += sldrChange;
        }

        private void sldrChange(object sender, EventArgs e)
        {
            changeColor((int) slrRed.Value, (int) slrGreen.Value, (int) slrBlue.Value);
            //UISlider sldr = (UISlider)sender;
            int red, green, blue;
            red = (int) slrRed.Value;
            green = (int)slrGreen.Value;
            blue = (int)slrBlue.Value;


            txtRed.Text = slrRed.Value.ToString();
            txtGreen.Text = slrGreen.Value.ToString();
            txtBlue.Text = slrBlue.Value.ToString();
            lblOutput.TextColor = UIColor.FromRGB(Invert(red), Invert(green), Invert(blue));
        }

        private static int Invert (int color)
        {
            return 255 - color;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void changeColor(int red, int green, int blue)
        {
            lblOutput.BackgroundColor = UIColor.FromRGB(red, green, blue);
            lblOutput.Text = "#" + red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");


        }
    }
}