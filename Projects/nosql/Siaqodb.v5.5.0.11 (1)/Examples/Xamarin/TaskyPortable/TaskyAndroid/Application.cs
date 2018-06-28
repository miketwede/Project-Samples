using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Tasky.BL.Managers;
using System.IO;
using Sqo;
namespace TaskyAndroid {
    [Application]
    public class TaskyApp : Application {
        public static TaskyApp Current { get; private set; }

        public TaskManager TaskMgr { get; set; }
		ISiaqodb db;

        public TaskyApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer) {
                Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

			SetupSiaqodb ();
        }
		private void SetupSiaqodb()
		{
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder

			SiaqodbConfigurator.SetLicense (@"put your license key");
			db = new Siaqodb(documentsPath);
			TaskMgr = new TaskManager(db);
		}

    }
}
