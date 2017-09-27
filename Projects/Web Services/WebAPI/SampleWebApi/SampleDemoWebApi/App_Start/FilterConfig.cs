using System.Web;
using System.Web.Mvc;

namespace SampleDemoWebApi.CustomerApi
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
