USE [Customers]
GO
/****** Object:  StoredProcedure [dbo].[SearchCustomersByLastName]    Script Date: 9/3/2017 12:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SearchCustomersByLastName] 
    @LastName varchar(50) = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.LastName like '%' + @LastName + '%'
	order by C.LastName, C.FirstName

END
