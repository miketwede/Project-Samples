USE [Customers]
GO
/****** Object:  StoredProcedure [dbo].[SearchCustomersByFirstNameOrLastName]    Script Date: 9/2/2017 10:30:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SearchCustomersByFirstNameOrLastName] 
    @FirstName varchar(50) = null,
    @LastName varchar(50) = null

AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.FirstName like '%' + @FirstName + '%' or C.LastName like '%' + @LastName + '%'
	order by C.LastName, C.FirstName

END
