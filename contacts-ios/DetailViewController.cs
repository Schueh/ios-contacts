using System;

using UIKit;
using contactsios.model;
using Foundation;

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
            Contact = contact;
        }

        void ConfigureView()
        {
            Title = string.Format("{0} {1}", Contact.FirstName, Contact.LastName);

            SetPicture(Contact.Picture);

            firstName.Text = Contact.FirstName;
            lastName.Text = Contact.LastName;
            street.Text = Contact.Address.Street;
            zipCity.Text = string.Format("{0} {1}", Contact.Address.Zip, Contact.Address.City);
            phone.Text = Contact.Phone;
            eMail.Text = Contact.Email;
        }

        private void SetPicture(string pictureUrl)
        {
            using (var url = new NSUrl(pictureUrl))
            using (var data = NSData.FromUrl(url))
            {
                picture.Image = UIImage.LoadFromData(data);
            }
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


