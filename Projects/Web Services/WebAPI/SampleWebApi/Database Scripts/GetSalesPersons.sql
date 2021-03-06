USE [AdventureWorks2014]
GO
/****** Object:  StoredProcedure [dbo].[GetSalesPersons]    Script Date: 11/26/2017 11:52:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetSalesPersons]
AS
BEGIN
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
SP.BusinessEntityID as SalesPersonID,
SP.TerritoryID,
--P.Title,
--P.FirstName,
--P.LastName,
--P.MiddleName,
--P.Suffix,

P.BusinessEntityID as PersonID,
P.PersonType,
P.Title,
P.FirstName,
P.LastName,
P.MiddleName,
P.Suffix,
A.AddressLine1,
A.AddressLine2,
A.City,
SPr.Name as [State],
SPr.CountryRegionCode,
A.PostalCode,
EA.EmailAddress,
PPP.PhoneNumber,
PP.Photo






  FROM Sales.SalesPerson SP
  inner join [AdventureWorks2014].Person.Person P on P.BusinessEntityID = SP.BusinessEntityID 
   
  inner join [AdventureWorks2014].Person.BusinessEntity BE on BE.BusinessEntityID = P.BusinessEntityID  

  inner join [AdventureWorks2014].Person.BusinessEntityAddress BEA on BEA.BusinessEntityID = BE.BusinessEntityID  
  inner join [AdventureWorks2014].Person.Address A on A.AddressID = BEA.AddressID 
  inner join [AdventureWorks2014].Person.StateProvince SPr on SPr.StateProvinceID = A.StateProvinceID  
 
  inner join [AdventureWorks2014].Person.EmailAddress EA on EA.BusinessEntityID = BEA.BusinessEntityID  
  inner join [AdventureWorks2014].Person.PersonPhone PPP on PPP.BusinessEntityID = BEA.BusinessEntityID  
  left outer join [AdventureWorks2014].Person.Photo PP on PP.BusinessEntityID = P.BusinessEntityID  

END
