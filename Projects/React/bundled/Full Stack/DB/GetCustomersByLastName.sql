USE [Customers]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomersByLastName]    Script Date: 9/3/2017 12:14:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCustomersByLastName] 
    @LastName varchar(50) = null
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.LastName = @LastName
	order by C.LastName, C.FirstName

END
