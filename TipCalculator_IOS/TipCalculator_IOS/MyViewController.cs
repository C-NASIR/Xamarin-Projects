using System;

using UIKit;
using CoreGraphics;

namespace TipCalculator_IOS
{
    public partial class MyViewController : UIViewController
    {
        //private views 
        private UITextField totalAmount;
        private UIButton calcButton;
        private UILabel resultLabel;

        public MyViewController() : base("MyViewController", null)
        {
        }

        public override void ViewDidLoad()
        { 
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.View.BackgroundColor = UIColor.Yellow;

            //instantiating the private views and filling their properties
            var topPadding = UIApplication.SharedApplication.Windows[0].SafeAreaInsets.Top;

             totalAmount = new UITextField
             {
                 Frame = new CGRect(20, 28 + topPadding, 380, 35),
                 KeyboardType = UIKeyboardType.DecimalPad,
                 BorderStyle = UITextBorderStyle.RoundedRect,
                 Placeholder = "Enter Total Amount",
             };

            calcButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20, 71 + topPadding,380, 45),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),
            };
            calcButton.SetTitle("Calculate", UIControlState.Normal);

            resultLabel = new UILabel()
            {
                Frame = new CGRect(20, 124 + topPadding,350, 40),
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(24),
                Text = "Tip is $0.00",
            };

            //adding the private subviews to the superview
            View.AddSubviews(totalAmount, calcButton, resultLabel);
        }

        //this method executes when the view will appaer
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            calcButton.TouchUpInside += CalcButton_TouchUpInside;
        }


        //this method is called when the view is about ot disappear
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            calcButton.TouchUpInside -= CalcButton_TouchUpInside;
        }

        //thid method is called when the user clicks on the calculate button
        private void CalcButton_TouchUpInside(object sender, EventArgs e)
        {
            double value = 0;
            if (Double.TryParse(totalAmount.Text, out value))
            {
                resultLabel.Text = string.Format("Tip is {0:C}", GetTip(value, 20));
            }
            else
            {
                resultLabel.Text = "Please enter a valid amount";
            }

            totalAmount.ResignFirstResponder();
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //this method calculates the tip and returns the value
        public double GetTip(double amount, double percentage)
        {
            return amount * percentage / 100.0;
        }
    }
}

