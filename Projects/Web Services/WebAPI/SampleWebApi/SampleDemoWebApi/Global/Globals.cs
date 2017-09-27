using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleDemoWebApi.CustomerApi.Global
{
	public static class Globals
	{

		public static Dictionary<string, string> MaritalStatus = new Dictionary<string, string>();
		public static Dictionary<string, string> Gender = new Dictionary<string, string>();

		static Globals()
		{
			MaritalStatus.Add("M", "Married");
			MaritalStatus.Add("S", "Single");
			MaritalStatus.Add("D", "Divorced");
			MaritalStatus.Add("W", "Widowed");

			Gender.Add("M", "Male");
			Gender.Add("F", "Female");
			Gender.Add("U", "Undisclosed");

		}

	}
}