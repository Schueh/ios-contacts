// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace contactsios
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel eMail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel firstName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lastName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel phone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView picture { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel street { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel zipCity { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (eMail != null) {
				eMail.Dispose ();
				eMail = null;
			}
			if (firstName != null) {
				firstName.Dispose ();
				firstName = null;
			}
			if (lastName != null) {
				lastName.Dispose ();
				lastName = null;
			}
			if (phone != null) {
				phone.Dispose ();
				phone = null;
			}
			if (picture != null) {
				picture.Dispose ();
				picture = null;
			}
			if (street != null) {
				street.Dispose ();
				street = null;
			}
			if (zipCity != null) {
				zipCity.Dispose ();
				zipCity = null;
			}
		}
	}
}
