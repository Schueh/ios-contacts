using System;

using UIKit;
using contactsios.model;

namespace contactsios
{
    public partial class DetailViewController : UIViewController
    {
        public Contact Contact { get; set; }

        public DetailViewController(IntPtr handle)
            : base(handle)
        {
        }

        public void SetDetailItem(Contact contact)
        {
            if (Contact != contact)
            {
                Contact = contact;
				
                // Update the view
                ConfigureView();
            }
        }

        void ConfigureView()
        {
            // Update the user interface for the detail item
            if (IsViewLoaded && Contact != null)
                return; // TODO: Update labels and image view
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            ConfigureView();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}


