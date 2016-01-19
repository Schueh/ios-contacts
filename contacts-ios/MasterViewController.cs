using System;
using System.Collections.Generic;

using UIKit;
using Foundation;
using CoreGraphics;
using contactsios.model;
using contactsios.proxy;
using System.Threading.Tasks;

namespace contactsios
{
    public partial class MasterViewController : UITableViewController
    {
        public DetailViewController DetailViewController { get; set; }

        ContactProxy _contactProxy;

        DataSource dataSource;

        public MasterViewController(IntPtr handle)
            : base(handle)
        {
            Title = "Contacts";
			
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                PreferredContentSize = new CGSize(320f, 600f);
                ClearsSelectionOnViewWillAppear = false;
            }

            _contactProxy = new ContactProxy();
        }

        // async void is ok for events
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;

            DetailViewController = (DetailViewController)((UINavigationController)SplitViewController.ViewControllers[1]).TopViewController;

            TableView.Source = dataSource = new DataSource(this);

            await LoadContacts();
        }

        private async Task LoadContacts()
        {
            busyIndicator.StartAnimating();

            foreach (var contact in await _contactProxy.GetContacts())
            {
                dataSource.Objects.Add(contact);
            }

            TableView.ReloadData();

            busyIndicator.StopAnimating();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                var indexPath = TableView.IndexPathForSelectedRow;
                var item = dataSource.Objects[indexPath.Row];
                var controller = (DetailViewController)((UINavigationController)segue.DestinationViewController).TopViewController;
                controller.SetDetailItem(item);
                controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
                controller.NavigationItem.LeftItemsSupplementBackButton = true;
            }
        }

        class DataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            readonly List<Contact> contacts = new List<Contact>();
            readonly MasterViewController controller;

            public DataSource(MasterViewController controller)
            {
                this.controller = controller;
            }

            public IList<Contact> Objects
            {
                get { return contacts; }
            }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return contacts.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

                Contact contact = contacts[indexPath.Row];
                cell.TextLabel.Text = contact.ToString();
                cell.DetailTextLabel.Text = contact.Email;
                cell.ImageView.Image = GetPicture(contact.Picture);

                return cell;
            }

            private UIImage GetPicture(string pictureUrl)
            {
                using (var url = new NSUrl(pictureUrl))
                using (var data = NSData.FromUrl(url))
                {
                    return UIImage.LoadFromData(data);
                }
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                // Return false if you do not want the specified item to be editable.
                return true;
            }

            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
            {
                if (editingStyle == UITableViewCellEditingStyle.Delete)
                {
                    // Delete the row from the data source.
                    contacts.RemoveAt(indexPath.Row);
                    controller.TableView.DeleteRows(new [] { indexPath }, UITableViewRowAnimation.Fade);
                }
                else if (editingStyle == UITableViewCellEditingStyle.Insert)
                {
                    // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
                }
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                    controller.DetailViewController.SetDetailItem(contacts[indexPath.Row] as Contact);
            }
        }
    }
}


