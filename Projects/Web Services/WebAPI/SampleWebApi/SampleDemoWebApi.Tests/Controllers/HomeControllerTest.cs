using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleDemoWebApi.CustomerApi;
using SampleDemoWebApi.CustomerApi.Controllers;
using System.Linq;


namespace SampleDemoWebApi.CustomerApi.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		public string ApplicationName { get; set; } = "My Great Application";
		public int MaxItemsPerList { get; set; } = 15;

		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", result.ViewBag.Title);
		}

		[TestMethod]
		public void misc()
		{
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
			int oddNumbers = numbers.Count(n => n % 2 == 1);
			var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
			int sum = numbers.Sum();


	}
	}
}
