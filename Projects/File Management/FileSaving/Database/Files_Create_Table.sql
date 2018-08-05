USE [FileMaintenance]
GO

/****** Object:  Table [dbo].[Files]    Script Date: 8/4/2018 12:28:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Files](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[HaskKey] [char](32) NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[MetadataFK] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

