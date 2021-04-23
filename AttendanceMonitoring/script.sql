USE [master]
GO
/****** Object:  Database [EIS]    Script Date: 23/04/2021 11:12:52 pm ******/
CREATE DATABASE [EIS]
GO

USE [EIS]
GO
/****** Object:  Table [dbo].[tbl_Attendance]    Script Date: 23/04/2021 11:12:52 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Attendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttDate] [datetime] NULL,
	[EmpID] [varchar](50) NULL,
	[ATime] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_employee]    Script Date: 23/04/2021 11:12:52 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpID] [varchar](50) NULL,
	[Fname] [varchar](max) NULL,
	[Mname] [varchar](max) NULL,
	[Lname] [varchar](max) NULL,
	[Department] [varchar](max) NULL,
	[Position] [varchar](max) NULL,
	[Picture] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [EIS] SET  READ_WRITE 
GO
