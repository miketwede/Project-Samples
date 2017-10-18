using System;
using System.Collections.Generic;

using SampleDemoWebApi.CustomerApi.Models;
using SampleDemoWebApi.SalesTerritoryApi.DAL;

namespace SampleDemoWebApi.CustomerApi.BO
{
	public class SalesTerritoryBO
	{
		public SalesTerritory GetSalesTerritoryBySalesTerritoryID(int SalesTerritoryID)
		{
			SalesTerritoryDO salesTerritoryDO = new SalesTerritoryDO();

			SalesTerritory salesTerritory = salesTerritoryDO.GetSalesTerritoryBySalesTerritoryID(SalesTerritoryID);

			return salesTerritory;
		}

		public List<SalesTerritory> GetSalesTerritories()
		{
			SalesTerritoryDO salesTerritoryDO = new SalesTerritoryDO();
			List<SalesTerritory> salesTerritories = new List<SalesTerritory>();

			try
			{
				salesTerritories = salesTerritoryDO.GetSalesTerritories();
			}
			catch (Exception ex)
			{
				throw;
			}


			return salesTerritories;
		}

	}
}