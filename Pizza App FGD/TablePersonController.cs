using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Pizza_App_FGD
{
    public partial class TablePizzaController : UITableViewController
    {
        public static List<Pizza> listPizza = new List<Pizza>();

        public TablePizzaController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            tvPizzas.Source = new TableSource(this, listPizza);
            tvPizzas.ReloadData();

            //Navigations-Buttons anlegen
            UIBarButtonItem btnAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add, btnAdd_onClick);
            UIBarButtonItem btnDelete = new UIBarButtonItem(UIBarButtonSystemItem.Trash, btnDelete_onClick);

            //Buttons der Navigation hinzufügen
            UIBarButtonItem[] buttons = new UIBarButtonItem[] { btnDelete, btnAdd };
            NavigationItem.SetRightBarButtonItems(buttons, true);

            //Swipe-Gesten hinzufügen
            UILongPressGestureRecognizer longPressGestureRecognizer = new UILongPressGestureRecognizer(longPress);
            tvPizzas.AddGestureRecognizer(longPressGestureRecognizer);
        }

        private void longPress()
        {
        }

        public void btnAdd_onClick(object sender, EventArgs args)
        {
            DetailViewController detailViewController = (DetailViewController)Storyboard.InstantiateViewController("DetailViewController");
            detailViewController.personList = listPizza;
            detailViewController.tablePersonController = this;
            NavigationController.PushViewController(detailViewController, true);
        }

        public void btnDelete_onClick(object sender, EventArgs args)
        {
            listPizza.Clear();
            tvPizzas.ReloadData();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            tvPersons.ReloadData();
        }
    }
}