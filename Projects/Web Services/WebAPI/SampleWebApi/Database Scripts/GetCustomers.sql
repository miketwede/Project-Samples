USE [AdventureWorks2014]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomers]    Script Date: 12/26/2017 12:11:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCustomers] 
AS
BEGIN
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT top 100
--CT.Name as PersonType, 
--P.PersonType,
--P.NameStyle, 
C.CustomerID,
C.AccountNumber,
P.BusinessEntityID as 'PersonID',
P.PersonType,
P.Title,
P.FirstName,
P.LastName,
P.MiddleName,
P.Suffix,
P.EmailPromotion,
P.Demographics,
P.AdditionalContactInfo,
A.AddressID,
A.AddressLine1,
A.AddressLine2,
A.City,
SP.Name as [State],
SP.CountryRegionCode,
A.PostalCode,
EA.EmailAddressID,
EA.EmailAddress,
PPP.BusinessEntityID as 'PhoneNumberID',
PPP.PhoneNumber,
case
when exists(select 1 from [AdventureWorks2014].Person.Photo PP  where PP.BusinessEntityID = P.BusinessEntityID)
then (select PP.Photo from [AdventureWorks2014].Person.Photo PP  where PP.BusinessEntityID = P.BusinessEntityID)
else (select PP.Photo from [AdventureWorks2014].Person.Photo PP  where PP.BusinessEntityID = -1)
end as Photo
--PP.Photo

  FROM [AdventureWorks2014].[Sales].[Customer] C
  inner join [AdventureWorks2014].Person.Person P on P.BusinessEntityID = C.PersonID 
   
  inner join [AdventureWorks2014].Person.BusinessEntity BE on BE.BusinessEntityID = P.BusinessEntityID  

  inner join [AdventureWorks2014].Person.BusinessEntityAddress BEA on BEA.BusinessEntityID = BE.BusinessEntityID  
  inner join [AdventureWorks2014].Person.Address A on A.AddressID = BEA.AddressID 
  inner join [AdventureWorks2014].Person.StateProvince SP on SP.StateProvinceID = A.StateProvinceID  
 
  inner join [AdventureWorks2014].Person.EmailAddress EA on EA.BusinessEntityID = BEA.BusinessEntityID  
  inner join [AdventureWorks2014].Person.PersonPhone PPP on PPP.BusinessEntityID = BEA.BusinessEntityID  
  --left outer join [AdventureWorks2014].Person.Photo PP on PP.BusinessEntityID = P.BusinessEntityID  

  order by P.BusinessEntityID
  ----------inner join [AdventureWorks2014].Sales.Customer SC on SC.PersonID = C.PersonID 

  --left outer join [AdventureWorks2014].Person.BusinessEntityContact BEC on BEC.BusinessEntityID = BE.BusinessEntityID
  --left outer join [AdventureWorks2014].Person.ContactType CT on CT.ContactTypeID = BEC.ContactTypeID

  --inner join [AdventureWorks2014].Person.BusinessEntityContact BEC on BEC.BusinessEntityID = P.BusinessEntityID
  --inner join [AdventureWorks2014].Person.BusinessEntityContact BEC on BEC.PersonID = C.PersonID
END
