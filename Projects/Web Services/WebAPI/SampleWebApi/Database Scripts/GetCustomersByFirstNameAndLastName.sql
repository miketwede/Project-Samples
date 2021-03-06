USE [Customers]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomersByFirstNameOrLastName]    Script Date: 9/2/2017 10:34:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCustomersByFirstNameAndLastName] 
    @FirstName varchar(50) = null,
    @LastName varchar(50) = null

AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.FirstName = @FirstName and C.LastName = @LastName
	order by C.LastName, C.FirstName

END
