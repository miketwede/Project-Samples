//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SampleDemoAspNetCore.Models
//{
//    public class IndividualSurvey
//    {
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;

namespace SampleDemoAspNetCore.Models
{
	public class IndividualSurvey
	{
		public Decimal? TotalPurchaseYTD;
		public DateTime? DateFirstPurchase;
		public DateTime? BirthDate;
		public String MaritalStatus;
		public String YearlyIncome;
		public String Gender;
		public int? TotalChildren;
		public int? NumberChildrenAtHome;
		public String Education;
		public String Occupation;
		public bool? HomeOwnerFlag;
		public int? NumberCarsOwned;
		public String CommuteDistance;

	}
}