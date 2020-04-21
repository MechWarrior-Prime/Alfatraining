using Contacts_FGD;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace ToDo_NavBar_FGD
{
    public partial class TaskListController : UITableViewController
    {
        private TableSource tableSource;

        private List<Person> personList = new List<Person>();

        public TaskListController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //create navigation menu buttons
            tableTasks.Source = new TableSource(this, personList);
            UIBarButtonItem barbtnAdd = new UIBarButtonItem(UIBarButtonSystemItem.Add, (object sender, EventArgs args) =>
            {
                CreateDialog();
            });
            UIBarButtonItem barbtnDelete = new UIBarButtonItem(UIBarButtonSystemItem.Trash, deleteAllItems);

            UIBarButtonItem[] buttons = new UIBarButtonItem[] { barbtnAdd, barbtnDelete };
            NavigationItem.SetRightBarButtonItems(buttons, true);

            void deleteAllItems(object sender, EventArgs args)
            {
                personList.Clear();
                tableTasks.ReloadData();
            }
            UILongPressGestureRecognizer longPressGestureRecognizer = new UILongPressGestureRecognizer(LongPress);
            tableTasks.AddGestureRecognizer(longPressGestureRecognizer);
        }

        private void CreateDialog()
        {
            //AlertController anlegen
            UIAlertController alertController = UIAlertController.Create(
            "Add Person",
            "Please enter the person's name",
            UIAlertControllerStyle.Alert);

            //Eingabefeld hinzufügen
            UITextField txtAddTask = null;
            alertController.AddTextField(AddTaskTxt =>
            {
                txtAddTask = AddTaskTxt;
                txtAddTask.Placeholder = "Enter person name";
            });

            //OK-Button hinzufügen
            alertController.AddAction(UIAlertAction.Create(
            "OK",
            UIAlertActionStyle.Default,
            onClick =>
            {
                if (txtAddTask.Text.Length > 0)
                {
                    personList.Add(new Person(txtAddTask.Text, ""));//TODO add surname in UI
                    //taskList.Add(new Task("(add new)"));
                    tableTasks.ReloadData();
                }
            }));
            //Cancel-Button hinzufügen
            alertController.AddAction(UIAlertAction.Create(
            "Cancel",
            UIAlertActionStyle.Default,
            null));
            //PresentViewController aufrufen zur Anzeige des Dialoges
            PresentViewController(alertController, true, null);
        }

        //LongPress-Gesture zum bearbeiten von Tasks
        private void LongPress(UILongPressGestureRecognizer longPressGestureRecognizer)
        {
            if (longPressGestureRecognizer.State == UIGestureRecognizerState.Began)
            {
                var point = longPressGestureRecognizer.LocationInView(tableTasks);
                var indexPath = tableTasks.IndexPathForRowAtPoint(point);
                EditAlertDialog(indexPath);
            }
        }

        //AlertDialog zum Bearbeiten von einem Task
        private void EditAlertDialog(NSIndexPath indexPath)
        {
            Person currentTask = personList[indexPath.Row];
            //AlertController anlegen
            UIAlertController alertController = UIAlertController.Create(
            "Edit Person",
            "Please change peron's name",
            UIAlertControllerStyle.Alert);

            //Eingabefeld hinzufügen
            UITextField txtEditTask = null;
            alertController.AddTextField(EditTaskTxt =>
            {
                txtEditTask = EditTaskTxt;
                txtEditTask.Text = currentTask.gsName;
            });

            //OK-Button hinzufügen
            alertController.AddAction(UIAlertAction.Create(
            "OK",
            UIAlertActionStyle.Default,
            onClick =>
            {
                if (txtEditTask.Text.Length > 0)
                {
                    currentTask.gsName = txtEditTask.Text;
                    personList[indexPath.Row].gsName = currentTask.gsName;

                    tableTasks.BeginUpdates();
                    tableTasks.ReloadRows(tableTasks.IndexPathsForVisibleRows, UITableViewRowAnimation.Automatic);
                    tableTasks.EndUpdates();
                }
            }));
            //Cancel-Button hinzufügen
            alertController.AddAction(UIAlertAction.Create(
            "Cancel",
            UIAlertActionStyle.Default,
            null));
            //PresentViewController aufrufen zur Anzeige des Dialoges
            PresentViewController(alertController, true, null);
        }
    }
}