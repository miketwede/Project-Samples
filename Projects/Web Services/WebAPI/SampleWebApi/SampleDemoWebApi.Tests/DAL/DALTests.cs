using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SampleDemoWebApi.CustomerApi;
using SampleDemoWebApi.CustomerApi.Controllers;
using SampleDemoWebApi.CustomerApi.BO;
using SampleDemoWebApi.CustomerApi.Models;
using SampleDemoWebApi.CustomerApi.DAL;

//using log4net;
//using log4net.Config;
using NLog;
using System.Drawing;

namespace SampleDemoWebApi.CustomerApi.Tests.Controllers
{
	[TestClass]
	public class DALTests2
	{
		//private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private static Logger logger = LogManager.GetCurrentClassLogger();


		[TestMethod]
		public void UpdatePhotos()
		{
			CustomerDO customerDO = new CustomerDO();
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face2.jpg", 1699);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face1.jpg", 1700);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face7.jpg", 1701);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face9.jpg", 1701);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face4.jpg", 1703);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face5.jpg", 1704);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face6.jpg", 1705);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face8.jpg", 1706);
			//customerDO.saveImage(@"C:\Dev\React\ReactTraining\Full Stack - AG-Grid\API\Images", "face3.jpg", 1707);

			//customerDO.saveImage(@"C:\Dev\Web Services\WebAPI\SampleWebApi\SampleDemoWebApi\Images", "FemaleSillouette.jpg", 1708);
			//	customerDO.saveImage(@"C:\Dev\Web Services\WebAPI\SampleWebApi\SampleDemoWebApi\Images", "generic.png", -1);
			//customerDO.saveImage(@"C:\Dev\Web Services\WebAPI\SampleWebApi\SampleDemoWebApi\Images", "Female2.jpg", -2);
			customerDO.saveImage(@"C:\Dev\Web Services\WebAPI\SampleWebApi\SampleDemoWebApi\Images", "MaleSillouette.png", -3);

		}
		

	   [TestMethod]
		public void RetrievePhotos()
		{
			CustomerDO customerDO = new CustomerDO();
			Image mike = customerDO.getImage();

		}

		

	}
}
