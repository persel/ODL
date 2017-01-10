-- #############################################################
-- # PREREQUISITE: A Database called "ODL", RecreateDB.sql has been executed 
-- #############################################################

USE [ODL]

-- #############################################################
-- # CREATE SCHEMA IF NOT EXIST (Schemas are not dropped though)
-- #############################################################

IF NOT EXISTS (SELECT  schema_name FROM    information_schema.schemata WHERE   schema_name = 'Behorighet' ) 
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA Behorighet'
END


-- #############################################################
-- # DROP FK CONSTRAINTS IF EXIST
-- #############################################################

GO
ALTER TABLE [Behorighet].[VerksamhetsrollAnvandargrupp] DROP CONSTRAINT [FK_VerksamhetsrollAnvandargrupp_Verksamhetsroll]
GO
ALTER TABLE [Behorighet].[VerksamhetsrollAnvandargrupp] DROP CONSTRAINT [FK_VerksamhetsrollAnvandargrupp_Systemanvandargrupp]
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionsvarde] DROP CONSTRAINT [FK_Verksamhetsdimensionsvarde_Verksamhetsdimensionsvarde]
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionsvarde] DROP CONSTRAINT [FK_Verksamhetsdimensionsvarde_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde] DROP CONSTRAINT [FK_VerksamhetsdimensionsvardeSystemattributvarde_Verksamhetsdimensionsvarde]
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde] DROP CONSTRAINT [FK_VerksamhetsdimensionsvardeSystemattributvarde_Systemattributvarde]
GO
ALTER TABLE [Behorighet].[SystembehorighetAttributVarde] DROP CONSTRAINT [FK_SystembehorighetAttributVarde_Systembehorighet]
GO
ALTER TABLE [Behorighet].[SystembehorighetAttributVarde] DROP CONSTRAINT [FK_SystembehorighetAttributVarde_Systemattributvarde]
GO
ALTER TABLE [Behorighet].[Systembehorighet] DROP CONSTRAINT [FK_Systembehorighet_Systemanvandargrupp]
GO
ALTER TABLE [Behorighet].[Systembehorighet] DROP CONSTRAINT [FK_Systembehorighet_Anvandare]
GO
ALTER TABLE [Behorighet].[Systembegransning] DROP CONSTRAINT [FK_Systembegransning_System]
GO
ALTER TABLE [Behorighet].[Systembegransning] DROP CONSTRAINT [FK_Systembegransning_PersonIVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[SystemattributVerksamhetsdimension] DROP CONSTRAINT [FK_SystemattributVerksamhetsdimension_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[SystemattributVerksamhetsdimension] DROP CONSTRAINT [FK_SystemattributVerksamhetsdimension_Systemattribut]
GO
ALTER TABLE [Behorighet].[Systemattributvarde] DROP CONSTRAINT [FK_Systemattributvarde_Systemattributvarde]
GO
ALTER TABLE [Behorighet].[Systemattributvarde] DROP CONSTRAINT [FK_Systemattributvarde_Systemattribut]
GO
ALTER TABLE [Behorighet].[Systemattribut] DROP CONSTRAINT [FK_Systemattribut_System]
GO
ALTER TABLE [Behorighet].[Systemanvandargrupp] DROP CONSTRAINT [FK_Systemanvandargrupp_System]
GO
ALTER TABLE [Behorighet].[Systemanvandargrupp] DROP CONSTRAINT [FK_Systemanvandargrupp_Behorighetsniva]
GO
ALTER TABLE [Behorighet].[RelevantVerksamhetsdimension] DROP CONSTRAINT [FK_RelevantVerksamhetsdimension_Verksamhetsroll]
GO
ALTER TABLE [Behorighet].[RelevantVerksamhetsdimension] DROP CONSTRAINT [FK_RelevantVerksamhetsdimension_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde] DROP CONSTRAINT [FK_PersonIVerksamhetsrollVerksamhetsdimensionsvarde_Verksamhetsdimensionsvarde]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde] DROP CONSTRAINT [FK_PersonIVerksamhetsrollVerksamhetsdimensionsvarde_PersonIVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsroll] DROP CONSTRAINT [FK_PersonIVerksamhetsroll_Verksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsroll] DROP CONSTRAINT [FK_PersonIVerksamhetsroll_Person]
GO
ALTER TABLE [Behorighet].[Behorighetsniva] DROP CONSTRAINT [FK_Behorighetsniva_System]
GO
ALTER TABLE [Behorighet].[Anvandare] DROP CONSTRAINT [FK_Anvandare_Person]
GO

-- #############################################################
-- # DROP UNIQUE CONSTRAINTS IF EXIST
-- #############################################################


-- #############################################################
-- # DROP TABLES IF EXIST
-- #############################################################

/****** Object:  Table [Behorighet].[VerksamhetsrollAnvandargrupp]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[VerksamhetsrollAnvandargrupp]
GO
/****** Object:  Table [Behorighet].[Verksamhetsroll]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Verksamhetsroll]
GO
/****** Object:  Table [Behorighet].[Verksamhetsdimensionsvarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Verksamhetsdimensionsvarde]
GO
/****** Object:  Table [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde]
GO
/****** Object:  Table [Behorighet].[Verksamhetsdimension]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Verksamhetsdimension]
GO
/****** Object:  Table [Behorighet].[SystembehorighetAttributVarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[SystembehorighetAttributVarde]
GO
/****** Object:  Table [Behorighet].[Systembehorighet]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Systembehorighet]
GO
/****** Object:  Table [Behorighet].[Systembegransning]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Systembegransning]
GO
/****** Object:  Table [Behorighet].[SystemattributVerksamhetsdimension]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[SystemattributVerksamhetsdimension]
GO
/****** Object:  Table [Behorighet].[Systemattributvarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Systemattributvarde]
GO
/****** Object:  Table [Behorighet].[Systemattribut]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Systemattribut]
GO
/****** Object:  Table [Behorighet].[Systemanvandargrupp]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Systemanvandargrupp]
GO
/****** Object:  Table [Behorighet].[System]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[System]
GO
/****** Object:  Table [Behorighet].[RelevantVerksamhetsdimension]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[RelevantVerksamhetsdimension]
GO
/****** Object:  Table [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde]
GO
/****** Object:  Table [Behorighet].[PersonIVerksamhetsroll]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[PersonIVerksamhetsroll]
GO
/****** Object:  Table [Behorighet].[Behorighetsniva]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Behorighetsniva]
GO
/****** Object:  Table [Behorighet].[Anvandare]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Anvandare]
GO

-- #############################################################
-- # CREATE TABLES
-- #############################################################

/****** Object:  Table [Behorighet].[Anvandare]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Anvandare](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonFKId] [int] NOT NULL,
	[Alias] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Anvandare] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Behorighetsniva]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Behorighetsniva](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemFKId] [int] NOT NULL,
	[Namn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Behorighetsniva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[PersonIVerksamhetsroll]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[PersonIVerksamhetsroll](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VerksamhetsrollFKId] [int] NOT NULL,
	[PersonFKId] [int] NOT NULL,
	[PrimarRoll] [bit] NOT NULL,
	[TillfalligGallerFran] [datetime] NULL,
	[TillfalligGallerTill] [datetime] NULL,
 CONSTRAINT [PK_PersonIVerksamhetsroll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde](
	[PersonIVerksamhetsrollFKId] [int] NOT NULL,
	[VerksamhetsdimensionsvardeFKId] [int] NOT NULL,
 CONSTRAINT [PK_PersonIVerksamhetsrollVerksamhetsdimensionsvarde] PRIMARY KEY CLUSTERED 
(
	[PersonIVerksamhetsrollFKId] ASC,
	[VerksamhetsdimensionsvardeFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[RelevantVerksamhetsdimension]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[RelevantVerksamhetsdimension](
	[VerksamhetsrollFKId] [int] NOT NULL,
	[VerksamhetsdimensionFKId] [int] NOT NULL,
 CONSTRAINT [PK_RelevantVerksamhetsdimension] PRIMARY KEY CLUSTERED 
(
	[VerksamhetsrollFKId] ASC,
	[VerksamhetsdimensionFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[System]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[System](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_System] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Systemanvandargrupp]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Systemanvandargrupp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemFKId] [int] NOT NULL,
	[BehorighetsnivaFKId] [int] NOT NULL,
	[Namn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Systemanvandargrupp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Systemattribut]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Systemattribut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemFKId] [int] NULL,
	[Namn] [nvarchar](250) NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Systemattribut] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Systemattributvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Systemattributvarde](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemattributFKId] [int] NOT NULL,
	[SystemattributvardeFKId] [int] NULL,
	[Vardetyp] [int] NOT NULL,
	[Varde] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Systemattributvarde] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[SystemattributVerksamhetsdimension]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[SystemattributVerksamhetsdimension](
	[SystemattributFKId] [int] NOT NULL,
	[VerksamhetsdimensionFKId] [int] NOT NULL,
 CONSTRAINT [PK_SystemattributVerksamhetsdimension] PRIMARY KEY CLUSTERED 
(
	[SystemattributFKId] ASC,
	[VerksamhetsdimensionFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Systembegransning]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Systembegransning](
	[PersonIVerksamhetsrollFKId] [int] NOT NULL,
	[SystemFKId] [int] NOT NULL,
 CONSTRAINT [PK_Systembegransning] PRIMARY KEY CLUSTERED 
(
	[PersonIVerksamhetsrollFKId] ASC,
	[SystemFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Systembehorighet]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Systembehorighet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemanvandargruppFKId] [int] NOT NULL,
	[AnvandareFKId] [int] NOT NULL,
	[GallerFran] [datetime] NULL,
	[GallerTill] [datetime] NULL
 CONSTRAINT [PK_Systembehorighet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[SystembehorighetAttributVarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[SystembehorighetAttributVarde](
	[SystemattributvardeFKId] [int] NOT NULL,
	[SystembehorighetFKId] [int] NOT NULL,
 CONSTRAINT [PK_SystembehorighetAttributVarde] PRIMARY KEY CLUSTERED 
(
	[SystemattributvardeFKId] ASC,
	[SystembehorighetFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Verksamhetsdimension]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Verksamhetsdimension](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Verksamhetsdimension] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde](
	[SystemattributvardeFKId] [int] NOT NULL,
	[VerksamhetsdimensionsvardeFKId] [int] NOT NULL,
 CONSTRAINT [PK_VerksamhetsdimensionsvardeSystemattributvarde] PRIMARY KEY CLUSTERED 
(
	[SystemattributvardeFKId] ASC,
	[VerksamhetsdimensionsvardeFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Verksamhetsdimensionsvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Verksamhetsdimensionsvarde](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VerksamhetsdimensionFKId] [int] NOT NULL,
	[VerksamhetsdimensionsvardeFKId] [int] NULL,
	[Vardetyp] [tinyint] NOT NULL,
	[Varde] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Verksamhetsdimensionsvarde] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Verksamhetsroll]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Verksamhetsroll](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Namn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Verksamhetsroll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[VerksamhetsrollAnvandargrupp]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[VerksamhetsrollAnvandargrupp](
	[VerksamhetsrollFKId] [int] NOT NULL,
	[SystemanvandargruppFKId] [int] NOT NULL,
 CONSTRAINT [PK_VerksamhetsrollAnvandargrupp] PRIMARY KEY CLUSTERED 
(
	[VerksamhetsrollFKId] ASC,
	[SystemanvandargruppFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Person]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- #############################################################
-- # CREATE UNIQUE CONSTRAINT
-- #############################################################


-- #############################################################
-- # CREATE FK CONSTRAINTS
-- #############################################################

ALTER TABLE [Behorighet].[Anvandare]  WITH CHECK ADD  CONSTRAINT [FK_Anvandare_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Behorighet].[Anvandare] CHECK CONSTRAINT [FK_Anvandare_Person]
GO
ALTER TABLE [Behorighet].[Behorighetsniva]  WITH CHECK ADD  CONSTRAINT [FK_Behorighetsniva_System] FOREIGN KEY([SystemFKId])
REFERENCES [Behorighet].[System] ([Id])
GO
ALTER TABLE [Behorighet].[Behorighetsniva] CHECK CONSTRAINT [FK_Behorighetsniva_System]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsroll]  WITH CHECK ADD  CONSTRAINT [FK_PersonIVerksamhetsroll_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsroll] CHECK CONSTRAINT [FK_PersonIVerksamhetsroll_Person]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsroll]  WITH CHECK ADD  CONSTRAINT [FK_PersonIVerksamhetsroll_Verksamhetsroll] FOREIGN KEY([VerksamhetsrollFKId])
REFERENCES [Behorighet].[Verksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsroll] CHECK CONSTRAINT [FK_PersonIVerksamhetsroll_Verksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde]  WITH CHECK ADD  CONSTRAINT [FK_PersonIVerksamhetsrollVerksamhetsdimensionsvarde_PersonIVerksamhetsroll] FOREIGN KEY([PersonIVerksamhetsrollFKId])
REFERENCES [Behorighet].[PersonIVerksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde] CHECK CONSTRAINT [FK_PersonIVerksamhetsrollVerksamhetsdimensionsvarde_PersonIVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde]  WITH CHECK ADD  CONSTRAINT [FK_PersonIVerksamhetsrollVerksamhetsdimensionsvarde_Verksamhetsdimensionsvarde] FOREIGN KEY([VerksamhetsdimensionsvardeFKId])
REFERENCES [Behorighet].[Verksamhetsdimensionsvarde] ([Id])
GO
ALTER TABLE [Behorighet].[PersonIVerksamhetsrollVerksamhetsdimensionsvarde] CHECK CONSTRAINT [FK_PersonIVerksamhetsrollVerksamhetsdimensionsvarde_Verksamhetsdimensionsvarde]
GO
ALTER TABLE [Behorighet].[RelevantVerksamhetsdimension]  WITH CHECK ADD  CONSTRAINT [FK_RelevantVerksamhetsdimension_Verksamhetsdimension] FOREIGN KEY([VerksamhetsdimensionFKId])
REFERENCES [Behorighet].[Verksamhetsdimension] ([Id])
GO
ALTER TABLE [Behorighet].[RelevantVerksamhetsdimension] CHECK CONSTRAINT [FK_RelevantVerksamhetsdimension_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[RelevantVerksamhetsdimension]  WITH CHECK ADD  CONSTRAINT [FK_RelevantVerksamhetsdimension_Verksamhetsroll] FOREIGN KEY([VerksamhetsrollFKId])
REFERENCES [Behorighet].[Verksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[RelevantVerksamhetsdimension] CHECK CONSTRAINT [FK_RelevantVerksamhetsdimension_Verksamhetsroll]
GO
ALTER TABLE [Behorighet].[Systemanvandargrupp]  WITH CHECK ADD  CONSTRAINT [FK_Systemanvandargrupp_Behorighetsniva] FOREIGN KEY([BehorighetsnivaFKId])
REFERENCES [Behorighet].[Behorighetsniva] ([Id])
GO
ALTER TABLE [Behorighet].[Systemanvandargrupp] CHECK CONSTRAINT [FK_Systemanvandargrupp_Behorighetsniva]
GO
ALTER TABLE [Behorighet].[Systemanvandargrupp]  WITH CHECK ADD  CONSTRAINT [FK_Systemanvandargrupp_System] FOREIGN KEY([SystemFKId])
REFERENCES [Behorighet].[System] ([Id])
GO
ALTER TABLE [Behorighet].[Systemanvandargrupp] CHECK CONSTRAINT [FK_Systemanvandargrupp_System]
GO
ALTER TABLE [Behorighet].[Systemattribut]  WITH CHECK ADD  CONSTRAINT [FK_Systemattribut_System] FOREIGN KEY([SystemFKId])
REFERENCES [Behorighet].[System] ([Id])
GO
ALTER TABLE [Behorighet].[Systemattribut] CHECK CONSTRAINT [FK_Systemattribut_System]
GO
ALTER TABLE [Behorighet].[Systemattributvarde]  WITH CHECK ADD  CONSTRAINT [FK_Systemattributvarde_Systemattribut] FOREIGN KEY([SystemattributFKId])
REFERENCES [Behorighet].[Systemattribut] ([Id])
GO
ALTER TABLE [Behorighet].[Systemattributvarde] CHECK CONSTRAINT [FK_Systemattributvarde_Systemattribut]
GO
ALTER TABLE [Behorighet].[Systemattributvarde]  WITH CHECK ADD  CONSTRAINT [FK_Systemattributvarde_Systemattributvarde] FOREIGN KEY([SystemattributvardeFKId])
REFERENCES [Behorighet].[Systemattributvarde] ([Id])
GO
ALTER TABLE [Behorighet].[Systemattributvarde] CHECK CONSTRAINT [FK_Systemattributvarde_Systemattributvarde]
GO
ALTER TABLE [Behorighet].[SystemattributVerksamhetsdimension]  WITH CHECK ADD  CONSTRAINT [FK_SystemattributVerksamhetsdimension_Systemattribut] FOREIGN KEY([SystemattributFKId])
REFERENCES [Behorighet].[Systemattribut] ([Id])
GO
ALTER TABLE [Behorighet].[SystemattributVerksamhetsdimension] CHECK CONSTRAINT [FK_SystemattributVerksamhetsdimension_Systemattribut]
GO
ALTER TABLE [Behorighet].[SystemattributVerksamhetsdimension]  WITH CHECK ADD  CONSTRAINT [FK_SystemattributVerksamhetsdimension_Verksamhetsdimension] FOREIGN KEY([VerksamhetsdimensionFKId])
REFERENCES [Behorighet].[Verksamhetsdimension] ([Id])
GO
ALTER TABLE [Behorighet].[SystemattributVerksamhetsdimension] CHECK CONSTRAINT [FK_SystemattributVerksamhetsdimension_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[Systembegransning]  WITH CHECK ADD  CONSTRAINT [FK_Systembegransning_PersonIVerksamhetsroll] FOREIGN KEY([PersonIVerksamhetsrollFKId])
REFERENCES [Behorighet].[PersonIVerksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[Systembegransning] CHECK CONSTRAINT [FK_Systembegransning_PersonIVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[Systembegransning]  WITH CHECK ADD  CONSTRAINT [FK_Systembegransning_System] FOREIGN KEY([SystemFKId])
REFERENCES [Behorighet].[System] ([Id])
GO
ALTER TABLE [Behorighet].[Systembegransning] CHECK CONSTRAINT [FK_Systembegransning_System]
GO
ALTER TABLE [Behorighet].[Systembehorighet]  WITH CHECK ADD  CONSTRAINT [FK_Systembehorighet_Anvandare] FOREIGN KEY([AnvandareFKId])
REFERENCES [Behorighet].[Anvandare] ([Id])
GO
ALTER TABLE [Behorighet].[Systembehorighet] CHECK CONSTRAINT [FK_Systembehorighet_Anvandare]
GO
ALTER TABLE [Behorighet].[Systembehorighet]  WITH CHECK ADD  CONSTRAINT [FK_Systembehorighet_Systemanvandargrupp] FOREIGN KEY([SystemanvandargruppFKId])
REFERENCES [Behorighet].[Systemanvandargrupp] ([Id])
GO
ALTER TABLE [Behorighet].[Systembehorighet] CHECK CONSTRAINT [FK_Systembehorighet_Systemanvandargrupp]
GO
ALTER TABLE [Behorighet].[SystembehorighetAttributVarde]  WITH CHECK ADD  CONSTRAINT [FK_SystembehorighetAttributVarde_Systemattributvarde] FOREIGN KEY([SystemattributvardeFKId])
REFERENCES [Behorighet].[Systemattributvarde] ([Id])
GO
ALTER TABLE [Behorighet].[SystembehorighetAttributVarde] CHECK CONSTRAINT [FK_SystembehorighetAttributVarde_Systemattributvarde]
GO
ALTER TABLE [Behorighet].[SystembehorighetAttributVarde]  WITH CHECK ADD  CONSTRAINT [FK_SystembehorighetAttributVarde_Systembehorighet] FOREIGN KEY([SystembehorighetFKId])
REFERENCES [Behorighet].[Systembehorighet] ([Id])
GO
ALTER TABLE [Behorighet].[SystembehorighetAttributVarde] CHECK CONSTRAINT [FK_SystembehorighetAttributVarde_Systembehorighet]
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde]  WITH CHECK ADD  CONSTRAINT [FK_VerksamhetsdimensionsvardeSystemattributvarde_Systemattributvarde] FOREIGN KEY([SystemattributvardeFKId])
REFERENCES [Behorighet].[Systemattributvarde] ([Id])
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde] CHECK CONSTRAINT [FK_VerksamhetsdimensionsvardeSystemattributvarde_Systemattributvarde]
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde]  WITH CHECK ADD  CONSTRAINT [FK_VerksamhetsdimensionsvardeSystemattributvarde_Verksamhetsdimensionsvarde] FOREIGN KEY([VerksamhetsdimensionsvardeFKId])
REFERENCES [Behorighet].[Verksamhetsdimensionsvarde] ([Id])
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionsvardeSystemattributvarde] CHECK CONSTRAINT [FK_VerksamhetsdimensionsvardeSystemattributvarde_Verksamhetsdimensionsvarde]
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionsvarde]  WITH CHECK ADD  CONSTRAINT [FK_Verksamhetsdimensionsvarde_Verksamhetsdimension] FOREIGN KEY([VerksamhetsdimensionFKId])
REFERENCES [Behorighet].[Verksamhetsdimension] ([Id])
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionsvarde] CHECK CONSTRAINT [FK_Verksamhetsdimensionsvarde_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionsvarde]  WITH CHECK ADD  CONSTRAINT [FK_Verksamhetsdimensionsvarde_Verksamhetsdimensionsvarde] FOREIGN KEY([VerksamhetsdimensionsvardeFKId])
REFERENCES [Behorighet].[Verksamhetsdimensionsvarde] ([Id])
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionsvarde] CHECK CONSTRAINT [FK_Verksamhetsdimensionsvarde_Verksamhetsdimensionsvarde]
GO
ALTER TABLE [Behorighet].[VerksamhetsrollAnvandargrupp]  WITH CHECK ADD  CONSTRAINT [FK_VerksamhetsrollAnvandargrupp_Systemanvandargrupp] FOREIGN KEY([SystemanvandargruppFKId])
REFERENCES [Behorighet].[Systemanvandargrupp] ([Id])
GO
ALTER TABLE [Behorighet].[VerksamhetsrollAnvandargrupp] CHECK CONSTRAINT [FK_VerksamhetsrollAnvandargrupp_Systemanvandargrupp]
GO
ALTER TABLE [Behorighet].[VerksamhetsrollAnvandargrupp]  WITH CHECK ADD  CONSTRAINT [FK_VerksamhetsrollAnvandargrupp_Verksamhetsroll] FOREIGN KEY([VerksamhetsrollFKId])
REFERENCES [Behorighet].[Verksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[VerksamhetsrollAnvandargrupp] CHECK CONSTRAINT [FK_VerksamhetsrollAnvandargrupp_Verksamhetsroll]
GO
