-- #############################################################
-- # PREREQUISITE: A Database called "ODL"
-- #############################################################

USE [ODL] 
GO
--EXEC sp_msforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT all"
--EXEC sp_MSforeachtable @command1 = "DROP TABLE ?"


-- #############################################################
-- # CREATE SCHEMA IF NOT EXIST (Schemas are not dropped though)
-- #############################################################

IF NOT EXISTS (SELECT  schema_name FROM information_schema.schemata WHERE   schema_name = 'Person' ) 
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA Person'
END

IF NOT EXISTS (SELECT  schema_name FROM    information_schema.schemata WHERE   schema_name = 'Organisation' ) 
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA Organisation'
END

IF NOT EXISTS (SELECT  schema_name FROM    information_schema.schemata WHERE   schema_name = 'Adress' ) 
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA Adress'
END

IF NOT EXISTS (SELECT  schema_name FROM    information_schema.schemata WHERE   schema_name = 'Behorighet' ) 
BEGIN
	EXEC sp_executesql N'CREATE SCHEMA Behorighet'
END

-- #############################################################
-- # DROP ALL FK CONSTRAINTS
-- #############################################################

declare @sql1 nvarchar(max) = N'';
SELECT @sql1 += ('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME
+ '] DROP CONSTRAINT [' + CONSTRAINT_NAME + '];')
FROM information_schema.table_constraints
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_SCHEMA IN('Adress', 'Organisation', 'Person', 'Behorighet') -- CONSTRAINT_CATALOG = 'ODL'
--PRINT @sql1;
EXEC (@sql1)


-- #############################################################
-- # DROP ALL TABLES
-- #############################################################

declare @sql2 nvarchar(max) = N'';
SELECT @sql2 += (' DROP TABLE ' + s.NAME + '.' + t.NAME + ';')
FROM   sys.tables t
       JOIN sys.schemas s
         ON t.[schema_id] = s.[schema_id]
WHERE  t.type = 'U' AND s.name IN('Adress', 'Organisation', 'Person', 'Behorighet')
--PRINT @sql2;
EXEC (@sql2)




-- #############################################################
-- # CREATE TABLES
-- #############################################################


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Adress].[Adress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdressVariantFKId] [int] NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[AdressTyp](
	[Id] [int] NOT NULL,
	[Namn] [nvarchar](50) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_AdressTyp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[AdressVariant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdressTypFKId] [int] NOT NULL,
	[Variant] [nvarchar](255) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_AdressVariant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[GatuAdress](
	[AdressFKId] [int] NOT NULL,
	[AdressRad1] [nvarchar](255) NULL,
	[AdressRad2] [nvarchar](255) NULL,
	[AdressRad3] [nvarchar](255) NULL,
	[AdressRad4] [nvarchar](255) NULL,
	[AdressRad5] [nvarchar](255) NULL,
	[Postnummer] [numeric](18, 0) NOT NULL,
	[Stad] [nvarchar](255) NOT NULL,
	[Land] [nvarchar](255) NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_GatuAdress] PRIMARY KEY CLUSTERED 
(
	[AdressFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[Mail](
	[AdressFKId] [int] NOT NULL,
	[MailAdress] [varchar](255) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Mail] PRIMARY KEY CLUSTERED 
(
	[AdressFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[OrganisationAdress](
	[AdressFKId] [int] NOT NULL,
	[OrganisationFKId] [int] NOT NULL
 CONSTRAINT [PK_OrganisationAdress] PRIMARY KEY CLUSTERED 
(
	[AdressFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[PersonAdress](
	[AdressFKId] [int] NOT NULL,
	[PersonFKId] [int] NOT NULL
 CONSTRAINT [PK_PersonAdress] PRIMARY KEY CLUSTERED 
(
	[AdressFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[Telefon](
	[AdressFKId] [int] NOT NULL,
	[Telefonnummer] [nvarchar](25) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Telefon] PRIMARY KEY CLUSTERED 
(
	[AdressFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO
CREATE TABLE [Organisation].[Organisation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrganisationsId] [varchar](50) NOT NULL,
	[Namn] [nvarchar](100) NULL,
	[IngarIOrganisationFKId] [int] NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Organisation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Organisation].[Resultatenhet](
	[OrganisationFKId] [int] NOT NULL,
	[KstNr] [int] NOT NULL,
	[Typ] [nvarchar](5) NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Resultatenhet] PRIMARY KEY CLUSTERED 
(
	[OrganisationFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[AnstalldAvtal](
	[AvtalFKId] [int] NOT NULL,
	[PersonFKId] [int] NOT NULL	
 CONSTRAINT [PK_AnstalldAvtal] PRIMARY KEY CLUSTERED 
(
	[AvtalFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[Avtal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KallsystemId] [nvarchar](25) NOT NULL,
	[Avtalskod] [nvarchar](50) NULL,
	[Avtalstext] [nvarchar](50) NULL,
	[ArbetstidVecka] [int] NULL,
	[Befkod] [int] NULL,
	[BefText] [nvarchar](50) NULL,
	[Aktiv] [bit] NULL,
	[Ansvarig] [bit] NULL,
	[Chef] [bit] NULL,
	[TjledigFran] [datetime] NULL,
	[TjledigTom] [datetime] NULL,
	[Fproc] [decimal](5,2) NULL,
	[DeltidFranvaro] [nvarchar](10) NULL,
	[FranvaroProcent] [decimal](5,2) NULL,
	[SjukP] [nvarchar](10) NULL,
	[GrundArbtidVecka] [decimal](6,2) NULL,
	[Avtalstyp] [tinyint] NULL,
	[Lon] [int] NULL,
	[LonDatum] [datetime] NULL,
	[LoneTyp] [nvarchar](10) NULL,
	[LoneTillagg] [int] NULL,
	[TimLon] [int] NULL,
	[Anstallningsdatum] [datetime] NULL,
	[Avgangsdatum] [datetime] NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Avtal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [Person].[KonsultAvtal](
	[AvtalFKId] [int] NOT NULL,
	[PersonFKId] [int] NOT NULL,
 CONSTRAINT [PK_KonsultAvtal] PRIMARY KEY CLUSTERED 
(
	[AvtalFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KallsystemId] [nvarchar](25) NOT NULL,
	[Fornamn] [nvarchar](255) NOT NULL,
	[Mellannamn] [nvarchar](255) NULL,
	[Efternamn] [nvarchar](255) NOT NULL,
	[Personnummer] [nvarchar](12) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](10) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](10) NOT NULL
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


CREATE TABLE [Person].[OrganisationAvtal](
	[AvtalFKId] [int] NOT NULL,
	[OrganisationFKId] [int] NOT NULL,
	[ProcentuellFordelning] [decimal](5,2) NULL,
	[Huvudkostnadsstalle] [bit] NOT NULL
 CONSTRAINT [PK_OrganisationAvtal] PRIMARY KEY CLUSTERED 
(
	[AvtalFKId] ASC,
	[OrganisationFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- #############################################################
-- # CREATE UNIQUE CONSTRAINT
-- #############################################################



-- #############################################################
-- # CREATE FK CONSTRAINTS
-- #############################################################


ALTER TABLE [Adress].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_AdressVariant] FOREIGN KEY([AdressVariantFKId])
REFERENCES [Adress].[AdressVariant] ([Id])
GO
ALTER TABLE [Adress].[Adress] CHECK CONSTRAINT [FK_Adress_AdressVariant]
GO
ALTER TABLE [Adress].[AdressVariant]  WITH CHECK ADD  CONSTRAINT [FK_AdressVariant_AdressTyp] FOREIGN KEY([AdressTypFKId])
REFERENCES [Adress].[AdressTyp] ([Id])
GO
ALTER TABLE [Adress].[AdressVariant] CHECK CONSTRAINT [FK_AdressVariant_AdressTyp]
GO
ALTER TABLE [Adress].[GatuAdress]  WITH CHECK ADD  CONSTRAINT [FK_GatuAdress_Adress] FOREIGN KEY([AdressFKId])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[GatuAdress] CHECK CONSTRAINT [FK_GatuAdress_Adress]
GO
ALTER TABLE [Adress].[Mail]  WITH CHECK ADD  CONSTRAINT [FK_Mail_Adress] FOREIGN KEY([AdressFKId])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[Mail] CHECK CONSTRAINT [FK_Mail_Adress]
GO
ALTER TABLE [Adress].[OrganisationAdress]  WITH CHECK ADD  CONSTRAINT [FK_OrganisationAdress_Adress] FOREIGN KEY([AdressFKId])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[OrganisationAdress] CHECK CONSTRAINT [FK_OrganisationAdress_Adress]
GO
ALTER TABLE [Adress].[OrganisationAdress]  WITH CHECK ADD  CONSTRAINT [FK_OrganisationAdress_Organisation] FOREIGN KEY([OrganisationFKId])
REFERENCES [Organisation].[Organisation] ([Id])
GO
ALTER TABLE [Adress].[OrganisationAdress] CHECK CONSTRAINT [FK_OrganisationAdress_Organisation]
GO
ALTER TABLE [Adress].[PersonAdress]  WITH CHECK ADD  CONSTRAINT [FK_PersonAdress_Adress] FOREIGN KEY([AdressFKId])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[PersonAdress] CHECK CONSTRAINT [FK_PersonAdress_Adress]
GO
ALTER TABLE [Adress].[PersonAdress]  WITH CHECK ADD  CONSTRAINT [FK_PersonAdress_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Adress].[PersonAdress] CHECK CONSTRAINT [FK_PersonAdress_Person]
GO
ALTER TABLE [Adress].[Telefon]  WITH CHECK ADD  CONSTRAINT [FK_Telefon_Adress] FOREIGN KEY([AdressFKId])
REFERENCES [Adress].[Adress] ([Id])
GO
ALTER TABLE [Adress].[Telefon] CHECK CONSTRAINT [FK_Telefon_Adress]
GO
ALTER TABLE [Organisation].[Resultatenhet]  WITH CHECK ADD  CONSTRAINT [FK_Resultatenhet_Organisation] FOREIGN KEY([OrganisationFKId])
REFERENCES [Organisation].[Organisation] ([Id])
GO
ALTER TABLE [Organisation].[Resultatenhet] CHECK CONSTRAINT [FK_Resultatenhet_Organisation]
GO
ALTER TABLE [Organisation].[Organisation]  WITH CHECK ADD  CONSTRAINT [FK_Organisation_Organisation] FOREIGN KEY([IngarIOrganisationFKId])
REFERENCES [Organisation].[Organisation] ([Id])
GO
ALTER TABLE [Organisation].[Organisation] CHECK CONSTRAINT [FK_Organisation_Organisation]
GO
ALTER TABLE [Person].[AnstalldAvtal]  WITH CHECK ADD  CONSTRAINT [FK_AnstalldAvtal_Avtal] FOREIGN KEY([AvtalFKId])
REFERENCES [Person].[Avtal] ([Id])
GO
ALTER TABLE [Person].[AnstalldAvtal] CHECK CONSTRAINT [FK_AnstalldAvtal_Avtal]
GO
ALTER TABLE [Person].[KonsultAvtal]  WITH CHECK ADD  CONSTRAINT [FK_KonsultAvtal_Avtal] FOREIGN KEY([AvtalFKId])
REFERENCES [Person].[Avtal] ([Id])
GO
ALTER TABLE [Person].[KonsultAvtal] CHECK CONSTRAINT [FK_KonsultAvtal_Avtal]
GO
ALTER TABLE [Person].[KonsultAvtal]  WITH CHECK ADD  CONSTRAINT [FK_KonsultAvtal_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[KonsultAvtal] CHECK CONSTRAINT [FK_KonsultAvtal_Person]
GO
ALTER TABLE [Person].[AnstalldAvtal]  WITH CHECK ADD  CONSTRAINT [FK_AnstalldAvtal_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[AnstalldAvtal] CHECK CONSTRAINT [FK_AnstalldAvtal_Person]
GO
ALTER TABLE [Person].[OrganisationAvtal]  WITH CHECK ADD  CONSTRAINT [FK_OrganisationAvtal_Avtal] FOREIGN KEY([AvtalFKId])
REFERENCES [Person].[Avtal] ([Id])
GO
ALTER TABLE [Person].[OrganisationAvtal] CHECK CONSTRAINT [FK_OrganisationAvtal_Avtal]
GO
ALTER TABLE [Person].[OrganisationAvtal]  WITH CHECK ADD  CONSTRAINT [FK_OrganisationAvtal_Organisation] FOREIGN KEY([OrganisationFKId])
REFERENCES [Organisation].[Organisation] ([Id])
GO
ALTER TABLE [Person].[OrganisationAvtal] CHECK CONSTRAINT [FK_OrganisationAvtal_Organisation]
GO



-- #############################################################
-- # Behörighet tables and FK's
-- #############################################################


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
/****** Object:  Table [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionsvarde]    Script Date: 2017-01-03 16:20:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionsvarde](
	[PersonVerksamhetsrollFKId] [int] NOT NULL,
	[VerksamhetsdimensionsvardeFKId] [int] NOT NULL,
 CONSTRAINT [PK_PersonVerksamhetsrollVerksamhetsdimensionsvarde] PRIMARY KEY CLUSTERED 
(
	[PersonVerksamhetsrollFKId] ASC,
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
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionsvarde]  WITH CHECK ADD  CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionsvarde_PersonVerksamhetsroll] FOREIGN KEY([PersonVerksamhetsrollFKId])
REFERENCES [Behorighet].[PersonVerksamhetsroll] ([Id])
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionsvarde] CHECK CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionsvarde_PersonVerksamhetsroll]
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionsvarde]  WITH CHECK ADD  CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionsvarde_Verksamhetsdimensionsvarde] FOREIGN KEY([VerksamhetsdimensionsvardeFKId])
REFERENCES [Behorighet].[Verksamhetsdimensionsvarde] ([Id])
GO
ALTER TABLE [Behorighet].[PersonVerksamhetsrollVerksamhetsdimensionsvarde] CHECK CONSTRAINT [FK_PersonVerksamhetsrollVerksamhetsdimensionsvarde_Verksamhetsdimensionsvarde]
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
