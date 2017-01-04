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
ALTER TABLE [Behorighet].[Verksamhetsdimensionvarde] DROP CONSTRAINT [FK_Verksamhetsdimensionvarde_Verksamhetsdimensionvarde]
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionvarde] DROP CONSTRAINT [FK_Verksamhetsdimensionvarde_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde] DROP CONSTRAINT [FK_VerksamhetsdimensionSystemattributvarde_Verksamhetsdimensionvarde]
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde] DROP CONSTRAINT [FK_VerksamhetsdimensionSystemattributvarde_Systemattributvarde]
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
ALTER TABLE [Behorighet].[Systembegransning] DROP CONSTRAINT [FK_Systembegransning_PersonVerksamhetsroll]
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
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde] DROP CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionvarde_Verksamhetsdimensionvarde]
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde] DROP CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionvarde_PersonVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsroll] DROP CONSTRAINT [FK_PersonVerksamhetsroll_Verksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsroll] DROP CONSTRAINT [FK_PersonVerksamhetsroll_Person]
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
/****** Object:  Table [Behorighet].[Verksamhetsdimensionvarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[Verksamhetsdimensionvarde]
GO
/****** Object:  Table [Behorighet].[VerksamhetsdimensionSystemattributvarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde]
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
/****** Object:  Table [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde]
GO
/****** Object:  Table [Behorighet].[PersonVerksamhetsroll]    Script Date: 2017-01-03 16:20:36 ******/
DROP TABLE [Behorighet].[PersonVerksamhetsroll]
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
	[PersonFKId] [int] NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Anvandare_1] PRIMARY KEY CLUSTERED 
(
	[PersonFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Behorighetsniva]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Behorighetsniva](
	[Id] [int] NOT NULL,
	[SystemFKId] [int] NOT NULL,
	[Namn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Behorighetsniva] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[PersonVerksamhetsroll]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[PersonVerksamhetsroll](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VerksamhetsrollFKId] [int] NOT NULL,
	[PersonFKId] [int] NOT NULL,
	[PrimarRoll] [bit] NOT NULL,
	[TillfalligGallerFran] [datetime] NULL,
	[TillfalligGallerTill] [datetime] NULL,
 CONSTRAINT [PK_PersonVerksamhetsroll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde](
	[PersonVerksamhetsrollFKId] [int] NOT NULL,
	[VerksamhetsdimensionvardeFKId] [int] NOT NULL,
 CONSTRAINT [PK_PersonVerksamhetsrollVerksamhetsdimensionvarde] PRIMARY KEY CLUSTERED 
(
	[PersonVerksamhetsrollFKId] ASC,
	[VerksamhetsdimensionvardeFKId] ASC
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
	[Id] [int] NOT NULL,
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
	[Datatyp] [tinyint] NOT NULL,
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
	[PersonVerksamhetsrollFKId] [int] NOT NULL,
	[SystemFKId] [int] NOT NULL,
 CONSTRAINT [PK_Systembegransning] PRIMARY KEY CLUSTERED 
(
	[PersonVerksamhetsrollFKId] ASC,
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
	[Id] [int] NOT NULL,
	[SystemanvandargruppFKId] [int] NOT NULL,
	[PersonFKId] [int] NOT NULL,
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
/****** Object:  Table [Behorighet].[VerksamhetsdimensionSystemattributvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde](
	[SystemattributvardeFKId] [int] NOT NULL,
	[VerksamhetsdimensionvardeFKId] [int] NOT NULL,
 CONSTRAINT [PK_VerksamhetsdimensionSystemattributvarde] PRIMARY KEY CLUSTERED 
(
	[SystemattributvardeFKId] ASC,
	[VerksamhetsdimensionvardeFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Behorighet].[Verksamhetsdimensionvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[Verksamhetsdimensionvarde](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VerksamhetsdimensionFKId] [int] NOT NULL,
	[VerksamhetsdimensionvardeFKId] [int] NULL,
	[Datatyp] [tinyint] NOT NULL,
	[Varde] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Verksamhetsdimensionvarde] PRIMARY KEY CLUSTERED 
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
ALTER TABLE [Behorighet].[PersonVerksamhetsroll]  WITH CHECK ADD  CONSTRAINT [FK_PersonVerksamhetsroll_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsroll] CHECK CONSTRAINT [FK_PersonVerksamhetsroll_Person]
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsroll]  WITH CHECK ADD  CONSTRAINT [FK_PersonVerksamhetsroll_Verksamhetsroll] FOREIGN KEY([VerksamhetsrollFKId])
REFERENCES [Behorighet].[Verksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsroll] CHECK CONSTRAINT [FK_PersonVerksamhetsroll_Verksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde]  WITH CHECK ADD  CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionvarde_PersonVerksamhetsroll] FOREIGN KEY([PersonVerksamhetsrollFKId])
REFERENCES [Behorighet].[PersonVerksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde] CHECK CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionvarde_PersonVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde]  WITH CHECK ADD  CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionvarde_Verksamhetsdimensionvarde] FOREIGN KEY([VerksamhetsdimensionvardeFKId])
REFERENCES [Behorighet].[Verksamhetsdimensionvarde] ([Id])
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionvarde] CHECK CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionvarde_Verksamhetsdimensionvarde]
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
ALTER TABLE [Behorighet].[Systembegransning]  WITH CHECK ADD  CONSTRAINT [FK_Systembegransning_PersonVerksamhetsroll] FOREIGN KEY([PersonVerksamhetsrollFKId])
REFERENCES [Behorighet].[PersonVerksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[Systembegransning] CHECK CONSTRAINT [FK_Systembegransning_PersonVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[Systembegransning]  WITH CHECK ADD  CONSTRAINT [FK_Systembegransning_System] FOREIGN KEY([SystemFKId])
REFERENCES [Behorighet].[System] ([Id])
GO
ALTER TABLE [Behorighet].[Systembegransning] CHECK CONSTRAINT [FK_Systembegransning_System]
GO
ALTER TABLE [Behorighet].[Systembehorighet]  WITH CHECK ADD  CONSTRAINT [FK_Systembehorighet_Anvandare] FOREIGN KEY([PersonFKId])
REFERENCES [Behorighet].[Anvandare] ([PersonFKId])
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
ALTER TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde]  WITH CHECK ADD  CONSTRAINT [FK_VerksamhetsdimensionSystemattributvarde_Systemattributvarde] FOREIGN KEY([SystemattributvardeFKId])
REFERENCES [Behorighet].[Systemattributvarde] ([Id])
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde] CHECK CONSTRAINT [FK_VerksamhetsdimensionSystemattributvarde_Systemattributvarde]
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde]  WITH CHECK ADD  CONSTRAINT [FK_VerksamhetsdimensionSystemattributvarde_Verksamhetsdimensionvarde] FOREIGN KEY([VerksamhetsdimensionvardeFKId])
REFERENCES [Behorighet].[Verksamhetsdimensionvarde] ([Id])
GO
ALTER TABLE [Behorighet].[VerksamhetsdimensionSystemattributvarde] CHECK CONSTRAINT [FK_VerksamhetsdimensionSystemattributvarde_Verksamhetsdimensionvarde]
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionvarde]  WITH CHECK ADD  CONSTRAINT [FK_Verksamhetsdimensionvarde_Verksamhetsdimension] FOREIGN KEY([VerksamhetsdimensionFKId])
REFERENCES [Behorighet].[Verksamhetsdimension] ([Id])
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionvarde] CHECK CONSTRAINT [FK_Verksamhetsdimensionvarde_Verksamhetsdimension]
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionvarde]  WITH CHECK ADD  CONSTRAINT [FK_Verksamhetsdimensionvarde_Verksamhetsdimensionvarde] FOREIGN KEY([VerksamhetsdimensionvardeFKId])
REFERENCES [Behorighet].[Verksamhetsdimensionvarde] ([Id])
GO
ALTER TABLE [Behorighet].[Verksamhetsdimensionvarde] CHECK CONSTRAINT [FK_Verksamhetsdimensionvarde_Verksamhetsdimensionvarde]
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
