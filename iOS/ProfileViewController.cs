using CoreLocation;
using DeliveryApp.Model;
using Foundation;
using MapKit;
using System;
using UIKit;

namespace DeliveryApp.iOS
{
    public partial class ProfileViewController : UIViewController
    {
        CLLocationManager locationManager;
        public ProfileViewController (IntPtr handle) : base(handle)
        {

        }
        //share button  
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();
            originMapViewIcon.ShowsUserLocation = true;
            originMapViewIcon.DidUpdateUserLocation += OriginMapViewIcon_DidUpdateUserLocation1;
            saveButton.TouchUpInside += SaveButton_TouchUpInside;
        }

        private async void SaveButton_TouchUpInside(object sender, EventArgs e)
        {
            var origin = originMapViewIcon.CenterCoordinate;

            Delivery delivery = new Delivery()
            {
                Name = locationTextField.Text,
                Status = 0,
                OriginLatitude = origin.Latitude,
                OriginLongitude = origin.Longitude
            };
            await Delivery.InsertDelivery(delivery);
        }
        //add pin
        void OriginMapViewIcon_DidUpdateUserLocation1(object sender, MKUserLocationEventArgs e)
        {
            if (originMapViewIcon.UserLocation != null)
            {
                var coordinates = originMapViewIcon.UserLocation.Coordinate;
                var span = new MKCoordinateSpan(0.15, 0.15);
                originMapViewIcon.Region = new MKCoordinateRegion(coordinates, span);

                //add title to the location
                originMapViewIcon.RemoveAnnotations();
                originMapViewIcon.AddAnnotation(new MKPointAnnotation()
                {
                    Coordinate = coordinates,
                    Title = "Your location"
                });
            }
        }                  
    }
}

