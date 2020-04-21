using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace Currency_online_FGD { }

public class CurrencyModel : UIPickerViewModel
{
    public string[] names = new string[] {
            "USD",
            "GBP",
            "EUR"
        };

    private UILabel currencyLabel;

    public CurrencyModel(UILabel currencyLabel)
    {
        this.currencyLabel = currencyLabel;
    }

    public override nint GetComponentCount(UIPickerView pickerView)
    {
        return 2;
    }

    public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
    {
        return names.Length;
    }

    public override string GetTitle(UIPickerView pickerView, nint row, nint component)
    {
        if (component == 0)
            return names[row];
        else
            return row.ToString();
    }

    public override void Selected(UIPickerView pickerView, nint row, nint component)
    {
        currencyLabel.Text = $"This currency is: {names[pickerView.SelectedRowInComponent(0)]},\n it is number {pickerView.SelectedRowInComponent(1)}";
    }

    public override nfloat GetComponentWidth(UIPickerView picker, nint component)
    {
        if (component == 0)
            return 240f;
        else
            return 40f;
    }

    public override nfloat GetRowHeight(UIPickerView picker, nint component)
    {
        return 40f;
    }
}