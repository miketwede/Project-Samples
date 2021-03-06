USE [FileMaintenance]
GO
/****** Object:  StoredProcedure [dbo].[Files_Insert]    Script Date: 8/5/2018 3:33:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Files_Insert] 
	-- Add the parameters for the stored procedure here
	@FileID int OUTPUT,
	@HashKey char(32),
	@FileName nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Files (HashKey, [FileName]) values (@HashKey, @FileName);
	set @FileID = @@identity;
	--print '@FileID = ';
	--print @FileID;

	--return @FileID;
	--select @FileID;

END
