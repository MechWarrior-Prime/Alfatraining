using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace ToDo_List_FGD
{
    internal class TableViewSource : UITableViewSource
    {
        public List<String> tasks;

        public TableViewSource(List<String> tasks)
        {
            this.tasks = tasks;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell("cell");
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "cell");
            }
            cell.TextLabel.Text = tasks[indexPath.Row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tasks.Count;
        }

        /*
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("TaskCell");

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, "TaskCell");
            }
            int row = indexPath.Row;
            cell.TextLabel.Text = tasks[row];
            return cell;
        }
        */
    }
}