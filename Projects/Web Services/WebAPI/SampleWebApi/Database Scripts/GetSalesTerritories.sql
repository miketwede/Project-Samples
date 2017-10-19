USE [AdventureWorks2014]
GO
/****** Object:  StoredProcedure [dbo].[GetSalesTerritories]    Script Date: 10/18/2017 1:43:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetSalesTerritories]
AS
BEGIN
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
ST.TerritoryID,
ST.[Group],
CR.Name as Country,
ST.Name as Region,
ST.SalesLastYear,
ST.SalesYTD,
ST.CostLastYear,
ST.CostYTD





  FROM Sales.SalesTerritory ST
  inner join Person.CountryRegion CR on CR.CountryRegionCode = ST.CountryRegionCode
END
