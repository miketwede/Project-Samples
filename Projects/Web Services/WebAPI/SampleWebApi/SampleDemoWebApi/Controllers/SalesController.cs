using System.Collections.Generic;
using System.Web.Http;
using SampleDemoWebApi.CustomerApi.Models;
using SampleDemoWebApi.CustomerApi.BO;

namespace SampleDemoWebApi.CustomerApi.Controllers
{
	[RoutePrefix("api/sales")]
	public class SalesController : ApiController
	{
		[Route("{GetSalesTerritoryBySalesTerritoryID}")]
		public SalesTerritory GetSalesTerritoryBySalesTerritoryID(int SalesTerritoryID)
		{
			SalesTerritoryBO salesTerritoryBO = new SalesTerritoryBO();

			SalesTerritory salesTerritory = salesTerritoryBO.GetSalesTerritoryBySalesTerritoryID(SalesTerritoryID);

			return salesTerritory;
		}

		[Route("{GetSalesTerritories}")]
		public List<SalesTerritory> GetSalesTerritories()
		{
			SalesTerritoryBO salesTerritoryBO = new SalesTerritoryBO();

			List<SalesTerritory> salesTerritories = salesTerritoryBO.GetSalesTerritories();

			return salesTerritories;
		}

	}
}
