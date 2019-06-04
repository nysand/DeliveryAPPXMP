//using CoreLocation;
//using DeliveryApp.Model;
//using Foundation;
//using MapKit;
//using System;
//using UIKit;

//namespace DeliveryApp.iOS
//{
//    public partial class NewDeliveryViewController : UIViewController
//    {
//        CLLocationManager locationManager;
//        public NewDeliveryViewController (IntPtr handle) : base (handle)
//        {
//        }

//        public override void ViewDidLoad()
//        {
//            base.ViewDidLoad();

//            locationManager = new CLLocationManager();
//            locationManager.RequestWhenInUseAuthorization();
//            originMapView.ShowsUserLocation = true;
//            destinationMapView.ShowsUserLocation = true;

//            originMapView.DidUpdateUserLocation += OriginMapView_DidUpdateUserLocation;
//            destinationMapView.DidUpdateUserLocation += DestinationMapView_DidUpdateUserLocation;

//            saveBarButtonItem.Clicked += SaveBarButtonItem_Clicked;
//        }

//        //get user location, display it and center it to the map
//        void DestinationMapView_DidUpdateUserLocation(object sender, MapKit.MKUserLocationEventArgs e)
//        {
//            if (destinationMapView.UserLocation != null)
//            {
//                var coordinates = destinationMapView.UserLocation.Coordinate;
//                var span = new MKCoordinateSpan(0.15, 0.15);
//                destinationMapView.Region = new MKCoordinateRegion(coordinates, span);

//                destinationMapView.RemoveAnnotations();
//                destinationMapView.AddAnnotation(new MKPointAnnotation()
//                {
//                    Coordinate = coordinates,
//                    Title = "Your location"
//                });
//            }
//        }

//        //get user location, display it and center it to the map
//        void OriginMapView_DidUpdateUserLocation(object sender, MapKit.MKUserLocationEventArgs e)
//        {
//            if(originMapView.UserLocation != null)
//            {
//                var coordinates = originMapView.UserLocation.Coordinate;
//                var span = new MKCoordinateSpan(0.15, 0.15);
//                originMapView.Region = new MKCoordinateRegion(coordinates, span);

//                //add title to the location
//                originMapView.RemoveAnnotations();
//                originMapView.AddAnnotation(new MKPointAnnotation()
//                {
//                    Coordinate = coordinates,
//                    Title = "Your location"
//                });

//            }
//        }


//        private async void SaveBarButtonItem_Clicked(object sender, EventArgs e)
//        {
//            var origin = originMapView.CenterCoordinate;
//            var destination = destinationMapView.CenterCoordinate;
//            Delivery delivery = new Delivery()
//            {
//                Name = packageNameTextField.Text,
//                Status = 0,
//                OriginLatitude = origin.Latitude,
//                OriginLongitude = origin.Longitude,
//                DestinationLatitude = destination.Latitude,
//                DestinationLongitude = destination.Longitude
             

//            };

//            await Delivery.InsertDelivery(delivery);
//        }

//    }
//}