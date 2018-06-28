using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using Tasky.BL.Managers;
using System.IO;
using Sqo;
namespace Tasky {
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		// class-level declarations
		UIWindow window;
		UINavigationController navController;
		UITableViewController homeViewController;

		public static AppDelegate Current { get; private set; }
        public TaskManager TaskMgr { get; set; }
		ISiaqodb db;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			Current = this;

			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			// create our nav controller
			navController = new UINavigationController ();

			// create our home controller based on the device
//			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
			homeViewController = new Tasky.Screens.HomeScreen();


			// Styling
			UINavigationBar.Appearance.TintColor = UIColor.FromRGB (38, 117 ,255); // nice blue
			UITextAttributes ta = new UITextAttributes();
			ta.Font = UIFont.FromName ("AmericanTypewriter-Bold", 0f);
			UINavigationBar.Appearance.SetTitleTextAttributes(ta);
			ta.Font = UIFont.FromName ("AmericanTypewriter", 0f);
			UIBarButtonItem.Appearance.SetTitleTextAttributes(ta, UIControlState.Normal);
			

			SetupSiaqodb ();


			// push the view controller onto the nav controller and show the window
			navController.PushViewController(homeViewController, false);
			window.RootViewController = navController;
			window.MakeKeyAndVisible ();
			
			return true;
		}
		private void SetupSiaqodb()
		{
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string dbpath = Path.Combine (documentsPath, "../Library/siaqodb"); // Library folder
			if (!System.IO.Directory.Exists (dbpath))
			{
				System.IO.Directory.CreateDirectory (dbpath);
			}
			SiaqodbConfigurator.SetLicense (@"put your license key");
			db = new Siaqodb(dbpath);
			TaskMgr = new TaskManager(db);
		}


	}
}