
/****** Object:  Table [dbo].[App]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App](
	[AppId] [int] IDENTITY(1,1) NOT NULL,
	[AppTypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Tags] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[AppId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AppComponent]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppComponent](
	[AppComponentId] [int] IDENTITY(1,1) NOT NULL,
	[AppId] [int] NOT NULL,
	[ComponentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AppComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Artifact]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artifact](
	[ArtifactId] [int] IDENTITY(0,1) NOT NULL,
	[Id] [uniqueidentifier] NOT NULL,
	[ArtifactTypeId] [int] NOT NULL,
	[Mime] [nvarchar](100) NOT NULL,
	[ContentLength] [bigint] NOT NULL,
	[OriginalFilename] [nvarchar](200) NOT NULL,
	[Location] [nvarchar](300) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Tds] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Artifact] PRIMARY KEY CLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Component]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Component](
	[ComponentId] [int] IDENTITY(1,1) NOT NULL,
	[ComponentTypeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComponentConstruct]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComponentConstruct](
	[ComponentConstructId] [int] IDENTITY(1,1) NOT NULL,
	[ComponentId] [int] NOT NULL,
	[ConstructId] [int] NOT NULL,
 CONSTRAINT [PK_ComponentConstruct] PRIMARY KEY CLUSTERED 
(
	[ComponentId] ASC,
	[ConstructId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Construct]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Construct](
	[ConstructId] [int] IDENTITY(1,1) NOT NULL,
	[ConstructTypeId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ConstructId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Documentation]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentation](
	[DocumentationId] [int] IDENTITY(1,1) NOT NULL,
	[ArtifactScopeTypeId] [int] NOT NULL,
	[ArtifactScopeId] [int] NOT NULL,
	[ArtifactId] [int] NOT NULL,
 CONSTRAINT [PK_Documentation] PRIMARY KEY CLUSTERED 
(
	[DocumentationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Selection]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Selection](
	[SelectionId] [int] IDENTITY(0,1) NOT NULL,
	[Display] [nvarchar](50) NOT NULL,
	[Token] [nvarchar](50) NOT NULL,
	[Sort] [int] NOT NULL CONSTRAINT [DF__Selection__Sort__182C9B23]  DEFAULT ((0)),
	[GroupId] [int] NULL CONSTRAINT [DF__Selection__Group__1920BF5C]  DEFAULT ((0)),
	[MasterId] [int] NULL CONSTRAINT [DF__Selection__Maste__1A14E395]  DEFAULT ((0)),
 CONSTRAINT [PK__Selectio__7F17914F6521B50E] PRIMARY KEY CLUSTERED 
(
	[SelectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Server]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Server](
	[ServerId] [int] IDENTITY(1,1) NOT NULL,
	[OperatingSystemId] [int] NOT NULL,
	[HostPlatformId] [int] NOT NULL,
	[SecurityId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[ExternalIP] [nvarchar](20) NULL,
	[InternalIP] [nvarchar](20) NULL,
	[Tags] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServerApp]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServerApp](
	[ServerAppId] [int] IDENTITY(1,1) NOT NULL,
	[ServerId] [int] NOT NULL,
	[AppId] [int] NOT NULL,
	[ZoneId] [int] NOT NULL,
	[ScopeId] [int] NOT NULL,
	[DomainId] [int] NULL,
	[Folderpath] [nvarchar](300) NULL,
	[BackupFolderpath] [nvarchar](300) NULL,
 CONSTRAINT [PK_ServerApp] PRIMARY KEY CLUSTERED 
(
	[ScopeId] ASC,
	[ZoneId] ASC,
	[AppId] ASC,
	[ServerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solution]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solution](
	[SolutionId] [int] IDENTITY(1,1) NOT NULL,
	[ScopeId] [int] NOT NULL CONSTRAINT [DF__Solution__ScopeI__20C1E124]  DEFAULT ((0)),
	[Name] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK__Solution__6B633AD0FE0E775C] PRIMARY KEY CLUSTERED 
(
	[SolutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionApp]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionApp](
	[SolutionAppId] [int] IDENTITY(1,1) NOT NULL,
	[SolutionId] [int] NOT NULL,
	[AppId] [int] NOT NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_SolutionApp_1] PRIMARY KEY CLUSTERED 
(
	[SolutionId] ASC,
	[AppId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SolutionZone]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolutionZone](
	[SolutionZoneId] [int] IDENTITY(1,1) NOT NULL,
	[SolutionId] [int] NOT NULL,
	[ZoneId] [int] NOT NULL,
	[DomainId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](300) NULL,
 CONSTRAINT [PK_SolutionZone_1] PRIMARY KEY CLUSTERED 
(
	[SolutionId] ASC,
	[ZoneId] ASC,
	[DomainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Zone]    Script Date: 3/21/2016 3:55:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zone](
	[ZoneId] [int] IDENTITY(0,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Token] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Zone__601667B55FC20E16] PRIMARY KEY CLUSTERED 
(
	[ZoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Artifact] ADD  CONSTRAINT [DF_Artifact_ArtifactTypeId]  DEFAULT ((0)) FOR [ArtifactTypeId]
GO
ALTER TABLE [dbo].[Artifact] ADD  CONSTRAINT [DF_Artifact_ContentLength]  DEFAULT ((0)) FOR [ContentLength]
GO
ALTER TABLE [dbo].[Artifact] ADD  CONSTRAINT [DF_Artifact_Tds]  DEFAULT (sysdatetimeoffset()) FOR [Tds]
GO
ALTER TABLE [dbo].[Documentation] ADD  CONSTRAINT [DF_Documentation_ArtifactId]  DEFAULT ((0)) FOR [ArtifactId]
GO
ALTER TABLE [dbo].[AppComponent]  WITH CHECK ADD  CONSTRAINT [FK_AppComponent_App] FOREIGN KEY([AppId])
REFERENCES [dbo].[App] ([AppId])
GO
ALTER TABLE [dbo].[AppComponent] CHECK CONSTRAINT [FK_AppComponent_App]
GO
ALTER TABLE [dbo].[AppComponent]  WITH CHECK ADD  CONSTRAINT [FK_AppComponent_Component] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([ComponentId])
GO
ALTER TABLE [dbo].[AppComponent] CHECK CONSTRAINT [FK_AppComponent_Component]
GO
ALTER TABLE [dbo].[ComponentConstruct]  WITH CHECK ADD  CONSTRAINT [FK_ComponentConstruct_Component] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Component] ([ComponentId])
GO
ALTER TABLE [dbo].[ComponentConstruct] CHECK CONSTRAINT [FK_ComponentConstruct_Component]
GO
ALTER TABLE [dbo].[ComponentConstruct]  WITH CHECK ADD  CONSTRAINT [FK_ComponentConstruct_Construct] FOREIGN KEY([ConstructId])
REFERENCES [dbo].[Construct] ([ConstructId])
GO
ALTER TABLE [dbo].[ComponentConstruct] CHECK CONSTRAINT [FK_ComponentConstruct_Construct]
GO
ALTER TABLE [dbo].[SolutionApp]  WITH CHECK ADD  CONSTRAINT [FK_SolutionApp_App] FOREIGN KEY([AppId])
REFERENCES [dbo].[App] ([AppId])
GO
ALTER TABLE [dbo].[SolutionApp] CHECK CONSTRAINT [FK_SolutionApp_App]
GO
