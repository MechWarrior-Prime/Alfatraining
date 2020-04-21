using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Pizza_App_FGD;
using UIKit;

namespace Pizza_App_FGD
{
    public class TableSource : UITableViewSource
    {
        private List<Pizza> listPizzas = new List<Pizza>();
        private string cellIdentifier = "PizzaCell";
        public Pizza currentPizza;
        private TablePizzaController tablePersonController;

        public TableSource(TablePizzaController tablePersonController, List<Pizza> listPizzas)
        {
            this.tablePersonController = tablePersonController;
            this.listPizzas = listPizzas;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);

            cell.TextLabel.Text = listPizzas[indexPath.Row].gsName;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return listPersons.Count;
        }

        //ContextualAction zum Bearbeiten der Person
        public UIContextualAction contextualEditAction(int row, UITableView tableView)
        {
            var action = UIContextualAction.FromContextualActionStyle(UIContextualActionStyle.Normal,
                "Edit",
                (UIContextualAction EditItem, UIView view, UIContextualActionCompletionHandler success) =>
                {
                    DetailViewController detailViewController = (DetailViewController)tablePersonController.Storyboard.InstantiateViewController("DetailViewController");
                    detailViewController.currentPerson = listPersons[row];
                    detailViewController.personList = listPersons;
                    detailViewController.tablePersonController = tablePersonController;
                    tablePersonController.NavigationController.PushViewController(detailViewController, true);
                    success(true);
                });
            action.BackgroundColor = UIColor.Orange;
            return action;
        }

        //ContextualAction zum Löschen eines Eintrags
        public UIContextualAction contextualDeleteAction(NSIndexPath indexPath, UITableView tableView)
        {
            var action = UIContextualAction.FromContextualActionStyle(UIContextualActionStyle.Normal,
                "Delete",
                (deleteItem, view, success) =>
                {
                    listPersons.RemoveAt(indexPath.Row);
                    tableView.BeginUpdates();
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    tableView.EndUpdates();
                    success(true);
                });
            action.BackgroundColor = UIColor.Red;
            return action;
        }

        //Methode zum hinzufügen der Swipe-Gesten
        public override UISwipeActionsConfiguration GetLeadingSwipeActionsConfiguration(UITableView tableView, NSIndexPath indexPath)
        {
            var editAction = contextualEditAction(indexPath.Row, tableView);

            var leadingSwipe = UISwipeActionsConfiguration.FromActions(new UIContextualAction[] { editAction });
            leadingSwipe.PerformsFirstActionWithFullSwipe = false;

            return leadingSwipe;
        }

        public override UISwipeActionsConfiguration GetTrailingSwipeActionsConfiguration(UITableView tableView, NSIndexPath indexPath)
        {
            var deleteAction = contextualDeleteAction(indexPath, tableView);

            var trailingSwipe = UISwipeActionsConfiguration.FromActions(new UIContextualAction[] { deleteAction });
            trailingSwipe.PerformsFirstActionWithFullSwipe = true;

            return trailingSwipe;
        }
    }
}