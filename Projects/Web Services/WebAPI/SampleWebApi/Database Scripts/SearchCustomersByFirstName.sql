USE [Customers]
GO
/****** Object:  StoredProcedure [dbo].[SearchCustomersByFirstName]    Script Date: 9/3/2017 12:10:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SearchCustomersByFirstName] 
    @FirstName varchar(50) = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.FirstName like '%' + @FirstName + '%'
	order by C.LastName, C.FirstName

END
