USE [AdventureWorks2014]
GO
/****** Object:  StoredProcedure [dbo].[CreateNewCustomer]    Script Date: 11/22/2017 10:28:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UpdateCustomer] 
				@PersonID  as  int,
				@PersonType as [nchar](2),
				@Title as [nvarchar](8),
				@FirstName as [dbo].[Name],
				@LastName as [dbo].[Name],
				@MiddleInitial as [dbo].[Name],
				@Suffix as  [nvarchar](10) ,
				@AddressID  as  int,
				@Address1 as [nvarchar](60),
				@Address2 as [nvarchar](60),
				@City as [nvarchar](30),
				@State as [dbo].[Name] ,
				@Zip as  [nvarchar](15),
				@Country as [nvarchar](3),
				@EmailAddressID  as  int,
				@EmailAddress as [nvarchar](50),
				@PhoneNumberID  as  int,
				@PhoneNumber as [nvarchar](25),
				@AccountNumber as [varchar](10) out,
				@EmailPromotion as int
				--@AdditionalContactInfo as [xml](CONTENT [Person].[AdditionalContactInfoSchemaCollection]) = null,
				--@Demographics as [xml](CONTENT [Person].[IndividualSurveySchemaCollection]) = null
AS
BEGIN

  --declare @BusinessEntityID as numeric(18,0);
  --declare @AddressID as numeric(18,0);
  --declare @PersonID as numeric(18,0);
  --declare @EmailAddressID as numeric(18,0);
  --declare @PhoneNumberID as numeric(18,0);

update [AdventureWorks2014].Person.Person 
set PersonType = @PersonType, 
	Title = @Title, 
	FirstName = @FirstName, 
	MiddleName = @MiddleInitial, 
	LastName = @LastName, 
	Suffix = @Suffix, 
	EmailPromotion = @EmailPromotion, 
	--AdditionalContactInfo = @AdditionalContactInfo, 
	--Demographics = @Demographics, 
	ModifiedDate = getdate()
where BusinessEntityID = @PersonID;

update [AdventureWorks2014].Person.Address 
set AddressLine1 = @Address1, 
	AddressLine2 = @Address2, 
	City = @City, 
	StateProvinceID = (select StateProvinceID from  Person.StateProvince where Name = @State and CountryRegionCode = @Country), 
	--select StateProvinceID from  Person.StateProvince where Name = 'Nordrhein-Westfalen' and [CountryRegionCode] = 'DE'
	PostalCode = @Zip, 
	--SpatialLocation = @Country, 
	ModifiedDate = getdate()
where AddressID = @AddressID;

update [AdventureWorks2014].Person.EmailAddress 
set EmailAddress =  @EmailAddress, 
	ModifiedDate = getdate()
where EmailAddressID = @EmailAddressID;

update [AdventureWorks2014].Person.PersonPhone 
set PhoneNumber = @PhoneNumber, 
	ModifiedDate = getdate()
where BusinessEntityID = @PhoneNumberID;


END
