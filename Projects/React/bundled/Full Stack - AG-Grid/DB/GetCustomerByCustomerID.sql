USE [Customers]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomersByLastName]    Script Date: 9/2/2017 10:41:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetCustomerByCustomerID] 
    @CustomerID int = 0
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.CustomerID = @CustomerID

END
