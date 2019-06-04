
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliveryApp.Model;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Droid;

namespace DeliveryApp.Droid
{
    public class Delivered : Android.Support.V4.App.ListFragment
    {
        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            var delivered = await Delivery.GetDelivered();
            ListAdapter = new DeliveryAdapter(Activity, delivered);
        }

    }
}