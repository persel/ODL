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


-- #############################################################
-- # DROP ALL FK CONSTRAINTS
-- #############################################################

declare @sql1 nvarchar(max) = N'';
SELECT @sql1 += ('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME
+ '] DROP CONSTRAINT [' + CONSTRAINT_NAME + '];')
FROM information_schema.table_constraints
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' AND TABLE_SCHEMA IN('Adress', 'Organisation', 'Person') -- CONSTRAINT_CATALOG = 'ODL'
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
WHERE  t.type = 'U' AND s.name IN('Adress', 'Organisation', 'Person')
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
	[Namn] [nvarchar](255) NOT NULL,
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
 CONSTRAINT [PK_GatuAdress] PRIMARY KEY CLUSTERED 
(
	[AdressFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[Mail](
	[AdressFKId] [int] NOT NULL,
	[MailAdress] [varchar](255) NOT NULL,
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
	[Telefonnummer] [nvarchar](25) NOT NULL
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
