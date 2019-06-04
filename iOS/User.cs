using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;


namespace DeliveryApp.iOS
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        internal static object Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
