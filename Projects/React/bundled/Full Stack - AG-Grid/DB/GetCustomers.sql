
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE GetCustomers 

AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C order by C.LastName, FirstName

END
GO
