using System;
using System.Collections.Generic;
using DeliveryApp.Model;
using Foundation;
using UIKit;


namespace DeliveryApp.iOS
{
    public partial class DeliveriesViewController : UITableViewController
    {
        List<Delivery> deliveries;

        public DeliveriesViewController(IntPtr handle) : base (handle)
        {
            deliveries = new List<Delivery>();
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            deliveries = await Delivery.GetDeliveries();
            TableView.ReloadData();
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return deliveries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("deliveryCell") as deliveryTableViewCell;

            var delivery = deliveries[indexPath.Row];
            cell.nameLabel.Text = delivery.Name;
            cell.coordinatesLabel.Text = $"{delivery.OriginLatitude}, {delivery.OriginLongitude}";
            //switch (delivery.Status)
            //{
            //    case 0:
            //        cell.statusLabel.Text = "Waiting delivery Person";
            //        break;
            //    case 1:
            //        cell.statusLabel.Text = "In delivery";
            //        break;
            //    case 2:
            //        cell.statusLabel.Text = "Delivered";
            //        break;
            //}

            return cell;
        }

    }
}

