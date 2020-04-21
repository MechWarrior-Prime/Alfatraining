// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Personenverwaltung
{
    [Register ("DetailViewController")]
    partial class DetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView DetailViewController { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtIngredient1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtingredient2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtIngredient3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtIngredient4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSecretIngredient { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSave != null) {
                btnSave.Dispose ();
                btnSave = null;
            }

            if (DetailViewController != null) {
                DetailViewController.Dispose ();
                DetailViewController = null;
            }

            if (txtIngredient1 != null) {
                txtIngredient1.Dispose ();
                txtIngredient1 = null;
            }

            if (txtingredient2 != null) {
                txtingredient2.Dispose ();
                txtingredient2 = null;
            }

            if (txtIngredient3 != null) {
                txtIngredient3.Dispose ();
                txtIngredient3 = null;
            }

            if (txtIngredient4 != null) {
                txtIngredient4.Dispose ();
                txtIngredient4 = null;
            }

            if (txtSecretIngredient != null) {
                txtSecretIngredient.Dispose ();
                txtSecretIngredient = null;
            }
        }
    }
}