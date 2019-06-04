using Foundation;
using System;
using UIKit;
using DeliveryApp.Model;

namespace DeliveryApp.iOS
{
    public partial class RegisterViewController : UIViewController
    {
        public string emailAddress;

        public RegisterViewController (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            emailTextField.Text = emailAddress;

            registerButton.TouchUpInside += RegisterButton_TouchUpInside;
        }

        private async void RegisterButton_TouchUpInside(object sender, EventArgs e)
        {
            var result = await User.Register(emailTextField.Text, passwordTextField.Text, confirmPasswordTextField.Text);

            UIAlertController alert = null;

            if (result)
            {
                 alert = UIAlertController.Create("Success", "User inserted", UIAlertControllerStyle.Alert);
            }
            else
            {
                 alert = UIAlertController.Create("Failure", "Try again", UIAlertControllerStyle.Alert);
            }

            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(alert, true, null);
        }
    }
}