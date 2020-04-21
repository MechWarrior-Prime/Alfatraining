using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Phone_Translator_FGD
{
    public class CallHistoryDataSource : UITableViewSource// in C#, : means inherits from
    {
        private CallHistoryController controller;

        public CallHistoryDataSource(CallHistoryController controller)
        {
            this.controller = controller;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CallHistoryController.callHistoryCellId);

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, CallHistoryController.callHistoryCellId);
            }
            int row = indexPath.Row;
            cell.TextLabel.Text = controller.PhoneNumbers[row];
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return controller.PhoneNumbers.Count;
        }
    }
}