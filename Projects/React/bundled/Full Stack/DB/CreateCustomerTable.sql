USE [Customers]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 9/2/2017 1:47:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleInitial] [char](1) NULL,
	[NickName] [nvarchar](max) NULL,
	[Address1] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [char](2) NULL,
	[Zip] [nvarchar](50) NULL,
	[Age] [int] NULL,
	[Occupation] [nvarchar](max) NULL,
	[Hobbies] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

