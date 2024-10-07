using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.Views;

public partial class WeightPage : ContentPage
{
    private double KeyValue;

    private const double dbl_p2p = 1;
    private const double dbl_p2k = .45359237;
    private const double dbl_p2g = 453.59237;
    private const double dbl_p2t = .00045359237;

    public WeightPage()
    {
        InitializeComponent();
        Title = "Weight Page";

        ToolbarItem tbi = new ToolbarItem();
        tbi.Text = "About";
        ToolbarItems.Add(tbi);

        tbi.Clicked += delegate { Navigation.PushAsync(new AboutPage()); };
    }

    private void BtnClear_OnClicked(object sender, EventArgs e)
    {
        txtPounds.Text = string.Empty;
        txtKilograms.Text = string.Empty;
        txtGrams.Text = string.Empty;
        txtTons.Text = string.Empty;
    }

    private void BtnConvert_OnClick(object sender, EventArgs e)
    {
        txtPounds.Text = (KeyValue * dbl_p2p).ToString("g9");
        txtKilograms.Text = (KeyValue * dbl_p2k).ToString("g9");
        txtGrams.Text = (KeyValue * dbl_p2g).ToString("g9");
        txtTons.Text = (KeyValue * dbl_p2t).ToString("g9");
    }

    private void TxtPounds_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = ConvertWeight(txtPounds.Text, dbl_p2p);
    }

    private void TxtKilograms_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = ConvertWeight(txtKilograms.Text, dbl_p2k);
    }

    private void TxtGrams_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = ConvertWeight(txtGrams.Text, dbl_p2g);
    }

    private void TxtTons_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = ConvertWeight(txtTons.Text, dbl_p2t);
    }


    private double ConvertWeight(string textBoxText, double conversionNumber)
    {
        double numToConvert;
        if (double.TryParse(textBoxText, out numToConvert) && numToConvert != 0)
            return numToConvert / conversionNumber;
        return 0;
        ;
    }
}