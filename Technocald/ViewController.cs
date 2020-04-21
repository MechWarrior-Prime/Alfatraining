using Foundation;
using System;
using UIKit;

namespace Technocald
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetButton(btnAdd);
            SetButton(btnDiv);
            SetButton(btnMult);
            SetButton(btnPower);
            SetButton(btnSqrt);
            SetButton(btnSub);

            //lblOutput.BackgroundColor = UIColor.LightGray;
            lblOutput.Layer.BorderColor = UIColor.Black.CGColor;
            lblOutput.Layer.BorderWidth = 1;
            lblOutput.Layer.CornerRadius = 4;
            lblOutput.TextColor = UIColor.Black;

            btnAdd.TouchUpInside += Add;
            btnDiv.TouchUpInside += Div;
            btnMult.TouchUpInside += Mult;
            btnPower.TouchUpInside += Power;
            btnSqrt.TouchUpInside += Sqrt;
            btnSub.TouchUpInside += Sub;
        }

        public static void SetButton(UIButton button)
        {
            button.Layer.BorderWidth = 1;
            button.Layer.CornerRadius = 4;
            button.Layer.BorderColor = UIColor.Black.CGColor;
            button.BackgroundColor = UIColor.LightGray;
        }

        private void Add(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = txtInputA.Text + " + " + txtInputB.Text + " = " + (double.Parse(txtInputA.Text) + double.Parse(txtInputB.Text)).ToString();
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
        }

        private void Div(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = txtInputA.Text + " + " + txtInputB.Text + " = " + double.Parse(txtInputA.Text) / double.Parse(txtInputB.Text);
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
        }

        private void Mult(object sender, EventArgs e)

        {
            try
            {
                lblOutput.Text = txtInputA.Text + " + " + txtInputB.Text + " = " + double.Parse(txtInputA.Text) * double.Parse(txtInputB.Text);
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
        }

        private void Power(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = txtInputA.Text + " ^ " + txtInputB.Text + " = " + Math.Pow(double.Parse(txtInputA.Text), double.Parse(txtInputB.Text));
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
        }

        private void Sqrt(object sender, EventArgs e)
        {
            try
            {
                lblOutput.Text = "√" + txtInputA.Text + " = " + Math.Sqrt(double.Parse(txtInputA.Text));
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
        }

        private void Sub(object sender, EventArgs e)
        {
            try
            {
                double result = double.Parse(txtInputA.Text) - double.Parse(txtInputB.Text);
                lblOutput.Text = txtInputA.Text + " + " + txtInputB.Text + " = " + result.ToString();
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
            }
        }

        private void hideKeyBoard()
        {
            txtInputA.ResignFirstResponder();
            txtInputB.ResignFirstResponder();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}