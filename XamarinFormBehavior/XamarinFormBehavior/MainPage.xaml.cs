using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormBehavior
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public string[] colors = { "Pick a Color","Cyan", "Yellow", "Green", "Brown" };
        public MainPage()
        {
            InitializeComponent();

            ColorPicker.ItemsSource = colors;
            ColorPicker.SelectedIndex = 0;
        }
    }
}
