USE [AdventureWorks2014]
GO
/****** Object:  StoredProcedure [dbo].[CreateNewCustomer]    Script Date: 11/26/2017 11:52:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[CreateNewCustomer] 
				@CustomerID  as  int out,
				@PersonType as [nchar](2),
				@NameStyle as [dbo].[NameStyle],
				@Title as [nvarchar](8),
				@FirstName as [dbo].[Name],
				@LastName as [dbo].[Name],
				@MiddleInitial as [dbo].[Name],
				@Suffix as  [nvarchar](10) ,
				@Address1 as [nvarchar](60),
				@Address2 as [nvarchar](60),
				@City as [nvarchar](30),
				@State as [dbo].[Name] ,
				@Zip as  [nvarchar](15),
				@Country as [nvarchar](3),
				@EmailAddress as [nvarchar](50),
				@PhoneNumber as [nvarchar](25),
				@AccountNumber as [varchar](10) out,
				@EmailPromotion as int,
				@AdditionalContactInfo as [xml](CONTENT [Person].[AdditionalContactInfoSchemaCollection]) = null,
				@Demographics as [xml](CONTENT [Person].[IndividualSurveySchemaCollection]) = null
AS
BEGIN

  declare @BusinessEntityID as numeric(18,0);
  declare @AddressID as numeric(18,0);
  declare @PersonID as numeric(18,0);
  declare @EmailAddressID as numeric(18,0);
  declare @PhoneNumberID as numeric(18,0);

insert into [AdventureWorks2014].Person.Person (PersonType, NameStyle, Title, FirstName, MiddleName, LastName, Suffix, EmailPromotion, AdditionalContactInfo, Demographics, rowguid, ModifiedDate)
values (@PersonType, @NameStyle, @Title, @FirstName, @MiddleInitial, @LastName, @Suffix, @EmailPromotion, @AdditionalContactInfo, @Demographics, NEWID(), getdate());
set @CustomerID = @@IDENTITY;

--insert into [AdventureWorks2014].[Sales].[Customer]  (PersonID, AccountNumber, rowguid, ModifiedDate)
--values (@CustomerID, @AccountNumber, NEWID(), getdate());
--set @PersonID = @@IDENTITY;

insert into [AdventureWorks2014].[Sales].[Customer]  (PersonID, rowguid, ModifiedDate)
values (@CustomerID, NEWID(), getdate());
set @PersonID = @@IDENTITY;
set @AccountNumber = (select AccountNumber from [AdventureWorks2014].[Sales].[Customer] where CustomerID = @PersonID)

insert into [AdventureWorks2014].Person.BusinessEntity (BusinessEntityID, rowguid, ModifiedDate)
values (@CustomerID, NEWID(), getdate());
set @BusinessEntityID = @@IDENTITY;

insert into [AdventureWorks2014].Person.Address (AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate)
values (@Address1, @Address2, @City, @State, @Zip, @Country, NEWID(), getdate());
set @AddressID = @@IDENTITY;

insert into [AdventureWorks2014].Person.BusinessEntityAddress (BusinessEntityID, AddressID, AddressTypeID, rowguid, ModifiedDate)
values (@BusinessEntityID, @AddressID, 1, NEWID(), getdate());

insert into [AdventureWorks2014].Person.EmailAddress (BusinessEntityID, EmailAddress, rowguid, ModifiedDate)
values (@BusinessEntityID, @EmailAddress, NEWID(), getdate());
set @EmailAddressID = @@IDENTITY;

insert into [AdventureWorks2014].Person.PersonPhone (BusinessEntityID, PhoneNumber, PhoneNumberTypeID, ModifiedDate)
values (@BusinessEntityID, @PhoneNumber, 1, getdate());
set @PhoneNumberID = @@IDENTITY;


END
