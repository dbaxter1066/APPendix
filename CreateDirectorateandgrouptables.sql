USE [DTaS_LaunchPad]
GO
/****** Object:  Table [dbo].[tblVPDirectorate]    Script Date: 24/04/2019 14:54:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVPDirectorate](
	[Directorate_ID] [int] IDENTITY(1,1) NOT NULL,
	[Directorate] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblVPGroup]    Script Date: 24/04/2019 14:54:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVPGroup](
	[Group_ID] [int] IDENTITY(1,1) NOT NULL,
	[Directorate] [nvarchar](50) NOT NULL,
	[CGroup] [nvarchar](50) NOT NULL,
	[Active] [bit] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblVPDirectorate] ADD  CONSTRAINT [DF_tblVPDirectorate_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[tblVPGroup] ADD  CONSTRAINT [DF_tblVPGroup_Active]  DEFAULT ((1)) FOR [Active]
GO
