using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;
using DeliveryApp.Model;


namespace DeliveryApp.Droid
{
    [Activity(Label = "DeliveryApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText emailEditText, passwordEditText;
        Button signinButton, registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            signinButton.Click += SigninButton_Click;
            registerButton.Click +=RegisterButton_Click;
        }

        void RegisterButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }

        private async void SigninButton_Click(object sender, System.EventArgs e)
        {
            var email = emailEditText.Text;
            var password = passwordEditText.Text;

            var result = await User.Login(email, password);

            if (result)
            {
                Toast.MakeText(this, "welcome", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(TabsActivity));
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Try again later", ToastLength.Long).Show();
            }
        }
    }
}

