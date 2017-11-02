using System;
using UIKit;

namespace AdderXamarin
{
    /// <summary>
    /// implementation of our main view controller (our user defined part),
    /// see MainViewController.designer.cs for the automatically 
    /// generated part (code behind/beside) of the view controller
    /// </summary>
    public partial class MainViewController : UIViewController
    {
        /// <summary>
        /// constructor, called by the iOS runtime
        /// </summary>
        /// <param name="handle"></param>
        public MainViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view

            // set the event handler for the TouchUpInside-event raised
            // by the add button:
            AddButton.TouchUpInside += DidTapAdd;
        }

        /// <summary>
        /// event handler that reacts to a tap on the "Add" button,
        /// reads the given numbers in the 2 textboxes and calculates
        /// their sum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DidTapAdd(object sender, EventArgs e)
        {
            var number1 = int.Parse(Number1.Text);
            var number2 = int.Parse(Number2.Text);

            var adder = new Adder();
            var result = adder.AddTwoNumbers(number1, number2);

            ResultLabel.Text = result.ToString();
        }

    }
}