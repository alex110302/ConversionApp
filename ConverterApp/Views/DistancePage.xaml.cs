using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.Views;

public partial class DistancePage : ContentPage
{
    private double KeyValue = 0;
    
    private const double dbl_m2f = 3.280839;
    private const double dbl_m2i = 39.37007874;
    private const double dbl_m2mi = 0.00062137119;
    private const double dbl_m2m = 1;
    private const double dbl_m2nm = 0.0005399568034557;
    private const double dbl_m2y = 1.093613298;
    private const double dbl_m2k = 0.001;
    
    public DistancePage()
    {
        InitializeComponent();
        Title = "Distance Converter";

        ToolbarItem tbi = new ToolbarItem();
        tbi.Text = "About";
        ToolbarItems.Add(tbi);

        tbi.Clicked += delegate
        {
            Navigation.PushAsync(new AboutPage());
        };
    }
    
    private void btnClear_OnClick(object sender, EventArgs e)
    {
        txtFeet.Text = string.Empty;
        txtInches.Text = string.Empty;
        txtYards.Text = string.Empty;
        txtNauticalMiles.Text = string.Empty;
        txtMiles.Text = string.Empty;
        txtMeters.Text = string.Empty;
        txtKilometers.Text = string.Empty;
    }

    private void btnConvert_OnClicked(object sender, EventArgs e)
    {
        txtFeet.Text = (KeyValue * dbl_m2f).ToString("g9");
        txtInches.Text = (KeyValue * dbl_m2i).ToString("g9");
        txtYards.Text = (KeyValue * dbl_m2y).ToString("g9");
        txtNauticalMiles.Text = (KeyValue * dbl_m2nm).ToString("g9");
        txtMiles.Text = (KeyValue * dbl_m2mi).ToString("g9");
        txtMeters.Text = (KeyValue * dbl_m2m).ToString("g9");
        txtKilometers.Text = (KeyValue * dbl_m2k).ToString("g9");
    }
    
    private void TxtMeters_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = CalculateConversion(txtMeters.Text, dbl_m2m);
    }

    private void TxtInches_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = CalculateConversion(txtInches.Text, dbl_m2i);
    }

    private void TxtFeet_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = CalculateConversion(txtFeet.Text, dbl_m2f);
    }

    private void TxtYards_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = CalculateConversion(txtYards.Text, dbl_m2y);
    }

    private void TxtMiles_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = CalculateConversion(txtMiles.Text, dbl_m2mi);
    }

    private void TxtNauticalMiles_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = CalculateConversion(txtNauticalMiles.Text, dbl_m2nm);
    }

    private void TxtKilometers_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        KeyValue = CalculateConversion(txtKilometers.Text, dbl_m2k);
    }
    
    private double CalculateConversion(string textBoxText, double conversionNumber)
    {
        double dblNumber;
        if (double.TryParse(textBoxText, out dblNumber) && dblNumber != 0) 
            return dblNumber / conversionNumber;
        return 0;
    }
}