
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE GetCustomersByFirstNameOrLastName 
    @FirstName varchar(50) = null,
    @LastName varchar(50) = null

AS
BEGIN

	SET NOCOUNT ON;

	SELECT * from Customer C 
	where C.FirstName =+ @FirstName or C.LastName = @LastName
	order by C.LastName, C.FirstName

END
GO
