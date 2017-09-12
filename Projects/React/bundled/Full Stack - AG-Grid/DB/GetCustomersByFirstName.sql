USE [Customers]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomersByFirstName]    Script Date: 9/3/2017 12:13:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCustomersByFirstName] 
    @FirstName varchar(50) = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.FirstName = @FirstName
	order by C.LastName, C.FirstName

END
