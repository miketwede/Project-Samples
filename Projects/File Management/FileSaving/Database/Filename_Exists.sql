GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE Filename_Exists 
	-- Add the parameters for the stored procedure here
	@HashKey char(32),
	@FileName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

select top 1 FileID from dbo.Files F where F.HashKey = @HashKey and F.FileName = @FileName
END
GO