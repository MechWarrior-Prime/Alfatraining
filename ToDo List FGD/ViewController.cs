using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ToDo_List_FGD
{
    public partial class ViewController : UIViewController
    {
        private List<string> tasks = new List<string>();

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btnAdd.TouchUpInside += BtnAdd_TouchUpInside;
            tvTasks.Source = new TableViewSource(tasks);
            //make pretty
            btnAdd.Layer.BorderColor = UIColor.Black.CGColor;
            btnAdd.Layer.BorderWidth = 1;
            btnAdd.Layer.CornerRadius = 8;
            tvTasks.Layer.BorderColor = UIColor.Black.CGColor;
            tvTasks.Layer.BorderWidth = 1;
            tvTasks.Layer.CornerRadius = 8;
        }

        private void BtnAdd_TouchUpInside(object sender, EventArgs e)
        {
            tasks.Add(txtInput.Text);
            tvTasks.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}