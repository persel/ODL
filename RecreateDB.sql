-- #############################################################
-- # PREREQUISITE: A Database called "ODL"
-- #############################################################

USE [ODL]
GO

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
-- # DROP FK CONSTRAINTS IF EXIST
-- #############################################################

IF (OBJECT_ID('Person.FK_AvtalResultatenhet_Resultatenhet', 'F') IS NOT NULL)
	ALTER TABLE [Person].[ResultatenhetAvtal] DROP CONSTRAINT [FK_AvtalResultatenhet_Resultatenhet]
GO
IF (OBJECT_ID('Person.FK_AvtalResultatenhet_Avtal', 'F') IS NOT NULL)
	ALTER TABLE [Person].[ResultatenhetAvtal] DROP CONSTRAINT [FK_AvtalResultatenhet_Avtal]
GO
IF (OBJECT_ID('Person.FK_KonsultAvtal_Konsult', 'F') IS NOT NULL)
	ALTER TABLE [Person].[KonsultAvtal] DROP CONSTRAINT [FK_KonsultAvtal_Konsult]
GO
IF (OBJECT_ID('Person.FK_KonsultAvtal_Avtal', 'F') IS NOT NULL)
	ALTER TABLE [Person].[KonsultAvtal] DROP CONSTRAINT [FK_KonsultAvtal_Avtal]
GO
IF (OBJECT_ID('Person.FK_Konsult_Person', 'F') IS NOT NULL)
	ALTER TABLE [Person].[Konsult] DROP CONSTRAINT [FK_Konsult_Person]
GO
IF (OBJECT_ID('Person.FK_AnstalldAvtal_Avtal', 'F') IS NOT NULL)
	ALTER TABLE [Person].[AnstalldAvtal] DROP CONSTRAINT [FK_AnstalldAvtal_Avtal]
GO
IF (OBJECT_ID('Person.FK_AnstalldAvtal_Anstalld', 'F') IS NOT NULL)
	ALTER TABLE [Person].[AnstalldAvtal] DROP CONSTRAINT [FK_AnstalldAvtal_Anstalld]
GO
IF (OBJECT_ID('Person.FK_Anstalld_Person', 'F') IS NOT NULL)
	ALTER TABLE [Person].[Anstalld] DROP CONSTRAINT [FK_Anstalld_Person]
GO
IF (OBJECT_ID('Organisation.FK_Resultatenhet_Organisation', 'F') IS NOT NULL)
	ALTER TABLE [Organisation].[Resultatenhet] DROP CONSTRAINT [FK_Resultatenhet_Organisation]
GO
IF (OBJECT_ID('Organisation.FK_Organisation_Organisation', 'F') IS NOT NULL)
	ALTER TABLE [Organisation].[Organisation] DROP CONSTRAINT [FK_Organisation_Organisation]
GO
IF (OBJECT_ID('Adress.FK_Telefon_Adress', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[Telefon] DROP CONSTRAINT [FK_Telefon_Adress]
GO
IF (OBJECT_ID('Adress.FK_PersonAdress_Person', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[PersonAdress] DROP CONSTRAINT [FK_PersonAdress_Person]
GO
IF (OBJECT_ID('Adress.FK_PersonAdress_Adress', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[PersonAdress] DROP CONSTRAINT [FK_PersonAdress_Adress]
GO
IF (OBJECT_ID('Adress.FK_OrganisationAdress_Organisation', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[OrganisationAdress] DROP CONSTRAINT [FK_OrganisationAdress_Organisation]
GO
IF (OBJECT_ID('Adress.FK_OrganisationAdress_Adress', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[OrganisationAdress] DROP CONSTRAINT [FK_OrganisationAdress_Adress]
GO
IF (OBJECT_ID('Adress.FK_Mail_Adress', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[Mail] DROP CONSTRAINT [FK_Mail_Adress]
GO
IF (OBJECT_ID('Adress.FK_GatuAdress_Adress', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[GatuAdress] DROP CONSTRAINT [FK_GatuAdress_Adress]
GO
IF (OBJECT_ID('Adress.FK_AdressVariant_AdressTyp', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[AdressVariant] DROP CONSTRAINT [FK_AdressVariant_AdressTyp]
GO
IF (OBJECT_ID('Adress.FK_Adress_AdressVariant', 'F') IS NOT NULL)
	ALTER TABLE [Adress].[Adress] DROP CONSTRAINT [FK_Adress_AdressVariant]
GO


-- #############################################################
-- # DROP UNIQUE CONSTRAINTS IF EXIST
-- #############################################################

IF OBJECT_ID('Person.IX_Anstalld', 'UQ') IS NOT NULL
	ALTER TABLE [Person].[Anstalld] DROP CONSTRAINT [IX_Anstalld]
GO

IF OBJECT_ID('Person.IX_AnstalldAvtal', 'UQ') IS NOT NULL
	ALTER TABLE [Person].[AnstalldAvtal] DROP CONSTRAINT [IX_AnstalldAvtal]
GO

IF OBJECT_ID('Person.IX_Konsult', 'UQ') IS NOT NULL
	ALTER TABLE [Person].[Konsult] DROP CONSTRAINT [IX_Konsult]
GO

IF OBJECT_ID('Person.IX_KonsultAvtal', 'UQ') IS NOT NULL
	ALTER TABLE [Person].[KonsultAvtal] DROP CONSTRAINT [IX_KonsultAvtal]
GO

IF OBJECT_ID('Person.IX_PersonAdress', 'UQ') IS NOT NULL
	ALTER TABLE [Adress].[PersonAdress] DROP CONSTRAINT [IX_PersonAdress]
GO

IF OBJECT_ID('Person.IX_OrganisationAdress', 'UQ') IS NOT NULL
	ALTER TABLE [Adress].[OrganisationAdress] DROP CONSTRAINT [IX_OrganisationAdress]
GO

-- #############################################################
-- # DROP TABLES IF EXIST
-- #############################################################

IF OBJECT_ID('Person.ResultatenhetAvtal', 'U') IS NOT NULL
	DROP TABLE [Person].[ResultatenhetAvtal]
GO
IF OBJECT_ID('Person.Person', 'U') IS NOT NULL
	DROP TABLE [Person].[Person]
GO
IF OBJECT_ID('Person.KonsultAvtal', 'U') IS NOT NULL
	DROP TABLE [Person].[KonsultAvtal]
GO
IF OBJECT_ID('Person.Konsult', 'U') IS NOT NULL
	DROP TABLE [Person].[Konsult]
GO
IF OBJECT_ID('Person.Avtal', 'U') IS NOT NULL
	DROP TABLE [Person].[Avtal]
GO
IF OBJECT_ID('Person.AnstalldAvtal', 'U') IS NOT NULL
	DROP TABLE [Person].[AnstalldAvtal]
GO
IF OBJECT_ID('Person.Anstalld', 'U') IS NOT NULL
	DROP TABLE [Person].[Anstalld]
GO
IF OBJECT_ID('Organisation.Resultatenhet', 'U') IS NOT NULL
	DROP TABLE [Organisation].[Resultatenhet]
GO
IF OBJECT_ID('Organisation.Organisation', 'U') IS NOT NULL
	DROP TABLE [Organisation].[Organisation]
GO
IF OBJECT_ID('Adress.Telefon', 'U') IS NOT NULL
	DROP TABLE [Adress].[Telefon]
GO
IF OBJECT_ID('Adress.PersonAdress', 'U') IS NOT NULL
	DROP TABLE [Adress].[PersonAdress]
GO
IF OBJECT_ID('Adress.OrganisationAdress', 'U') IS NOT NULL
	DROP TABLE [Adress].[OrganisationAdress]
GO
IF OBJECT_ID('Adress.Mail', 'U') IS NOT NULL
	DROP TABLE [Adress].[Mail]
GO
IF OBJECT_ID('Adress.GatuAdress', 'U') IS NOT NULL
	DROP TABLE [Adress].[GatuAdress]
GO
IF OBJECT_ID('Adress.AdressVariant', 'U') IS NOT NULL
	DROP TABLE [Adress].[AdressVariant]
GO
IF OBJECT_ID('Adress.AdressTyp', 'U') IS NOT NULL
	DROP TABLE [Adress].[AdressTyp]
GO
IF OBJECT_ID('Adress.Adress', 'U') IS NOT NULL
	DROP TABLE [Adress].[Adress]
GO


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
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[AdressTyp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Typ] [nvarchar](50) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
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
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_AdressVariant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[GatuAdress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_GatuAdress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[Mail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdressFKId] [int] NOT NULL,
	[MailAdress] [varchar](255) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Mail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[OrganisationAdress](
	[OrganisationFKId] [int] NOT NULL,
	[AdressFKId] [int] NOT NULL
 CONSTRAINT [PK_OrganisationAdress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[PersonAdress](
	[PersonFKId] [int] NOT NULL,
	[AdressFKId] [int] NOT NULL,
 CONSTRAINT [PK_PersonAdress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Adress].[Telefon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdressFKId] [int] NOT NULL,
	[Telefonnummer] [nvarchar](25) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Telefon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO
CREATE TABLE [Organisation].[Organisation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrganisationsId] [varchar](50) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Organisation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Organisation].[Resultatenhet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Kstnr] [int] NOT NULL,
	[Namn] [nvarchar](100) NULL,
	[Typ] [char](10) NULL,
	[OrganisationFKId] [int] NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Resultatenhet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[Anstalld](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonFKId] [int] NOT NULL,
	[Typ] [tinyint] NULL,
	[Alias] [varchar](50) NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Anstalld] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[AnstalldAvtal](
	[AnstalldFKId] [int] NOT NULL,
	[AvtalFKId] [int] NOT NULL,
 CONSTRAINT [PK_AnstalldAvtal] PRIMARY KEY CLUSTERED 
(
	[AnstalldFKId] ASC,
	[AvtalFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[Avtal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Avtalskod] [varchar](50) NULL,
	[Avtalstext] [varchar](50) NULL,
	[ArbetstidVecka] [int] NULL,
	[Befkod] [int] NULL,
	[BefText] [nvarchar](50) NULL,
	[Aktiv] [bit] NULL,
	[Ansvarig] [bit] NULL,
	[Chef] [bit] NULL,
	[TjledigFran] [datetime] NULL,
	[TjledigTom] [datetime] NULL,
	[Fproc] [float] NULL,
	[DeltidFranvaro] [nchar](10) NULL,
	[FranvaroProcent] [float] NULL,
	[SjukP] [nchar](10) NULL,
	[GrundArbtidVecka] [float] NULL,
	[Lon] [int] NULL,
	[LonDatum] [datetime] NULL,
	[LoneTyp] [nchar](10) NULL,
	[LoneTillagg] [int] NULL,
	[TimLon] [int] NULL,
	[Anstallningsdatum] [datetime] NULL,
	[Avgangsdatum] [datetime] NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Avtal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[Konsult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Alias] [nchar](10) NULL,
	[PersonFKId] [int] NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Konsult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[KonsultAvtal](
	[KonsultFKId] [int] NOT NULL,
	[AvtalFKId] [int] NOT NULL,
 CONSTRAINT [PK_KonsultAvtal] PRIMARY KEY CLUSTERED 
(
	[KonsultFKId] ASC,
	[AvtalFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [Person].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fornamn] [nvarchar](255) NOT NULL,
	[Mellannamn] [nvarchar](255) NULL,
	[Efternamn] [nvarchar](255) NOT NULL,
	[Personnummer] [varchar](12) NOT NULL,
	[UppdateradDatum] [datetime] NULL,
	[UppdateradAv] [nvarchar](100) NULL,
	[SkapadDatum] [datetime] NOT NULL,
	[SkapadAv] [nvarchar](100) NULL
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO


CREATE TABLE [Person].[ResultatenhetAvtal](
	[AvtalFKId] [int] NOT NULL,
	[ResultatenhetFKId] [int] NOT NULL,
 CONSTRAINT [PK_AvtalResultatenhet] PRIMARY KEY CLUSTERED 
(
	[AvtalFKId] ASC,
	[ResultatenhetFKId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- #############################################################
-- # CREATE UNIQUE CONSTRAINT
-- #############################################################


ALTER TABLE [Person].[Anstalld] ADD CONSTRAINT
[IX_Anstalld] UNIQUE NONCLUSTERED
(
[PersonFKId]
) ON [PRIMARY]
GO

ALTER TABLE [Person].[AnstalldAvtal] ADD CONSTRAINT
[IX_AnstalldAvtal] UNIQUE NONCLUSTERED
(
[AvtalFKId]
) ON [PRIMARY]
GO

ALTER TABLE [Person].[Konsult] ADD CONSTRAINT
[IX_Konsult] UNIQUE NONCLUSTERED
(
[PersonFKId]
) ON [PRIMARY]
GO

ALTER TABLE [Person].[KonsultAvtal] ADD CONSTRAINT
[IX_KonsultAvtal] UNIQUE NONCLUSTERED
(
[AvtalFKId]
) ON [PRIMARY]
GO

ALTER TABLE [Adress].[PersonAdress] ADD CONSTRAINT
[IX_PersonAdress] UNIQUE NONCLUSTERED
(
[AdressFKId]
) ON [PRIMARY]
GO

ALTER TABLE [Adress].[OrganisationAdress] ADD CONSTRAINT
[IX_OrganisationAdress] UNIQUE NONCLUSTERED
(
[AdressFKId]
) ON [PRIMARY]
GO

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
ALTER TABLE [Person].[Anstalld]  WITH CHECK ADD  CONSTRAINT [FK_Anstalld_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Anstalld] CHECK CONSTRAINT [FK_Anstalld_Person]
GO
ALTER TABLE [Person].[AnstalldAvtal]  WITH CHECK ADD  CONSTRAINT [FK_AnstalldAvtal_Anstalld] FOREIGN KEY([AnstalldFKId])
REFERENCES [Person].[Anstalld] ([Id])
GO
ALTER TABLE [Person].[AnstalldAvtal] CHECK CONSTRAINT [FK_AnstalldAvtal_Anstalld]
GO
ALTER TABLE [Person].[AnstalldAvtal]  WITH CHECK ADD  CONSTRAINT [FK_AnstalldAvtal_Avtal] FOREIGN KEY([AvtalFKId])
REFERENCES [Person].[Avtal] ([Id])
GO
ALTER TABLE [Person].[AnstalldAvtal] CHECK CONSTRAINT [FK_AnstalldAvtal_Avtal]
GO
ALTER TABLE [Person].[Konsult]  WITH CHECK ADD  CONSTRAINT [FK_Konsult_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Konsult] CHECK CONSTRAINT [FK_Konsult_Person]
GO
ALTER TABLE [Person].[KonsultAvtal]  WITH CHECK ADD  CONSTRAINT [FK_KonsultAvtal_Avtal] FOREIGN KEY([AvtalFKId])
REFERENCES [Person].[Avtal] ([Id])
GO
ALTER TABLE [Person].[KonsultAvtal] CHECK CONSTRAINT [FK_KonsultAvtal_Avtal]
GO
ALTER TABLE [Person].[KonsultAvtal]  WITH CHECK ADD  CONSTRAINT [FK_KonsultAvtal_Konsult] FOREIGN KEY([KonsultFKId])
REFERENCES [Person].[Konsult] ([Id])
GO
ALTER TABLE [Person].[KonsultAvtal] CHECK CONSTRAINT [FK_KonsultAvtal_Konsult]
GO
ALTER TABLE [Person].[ResultatenhetAvtal]  WITH CHECK ADD  CONSTRAINT [FK_AvtalResultatenhet_Avtal] FOREIGN KEY([AvtalFKId])
REFERENCES [Person].[Avtal] ([Id])
GO
ALTER TABLE [Person].[ResultatenhetAvtal] CHECK CONSTRAINT [FK_AvtalResultatenhet_Avtal]
GO
ALTER TABLE [Person].[ResultatenhetAvtal]  WITH CHECK ADD  CONSTRAINT [FK_AvtalResultatenhet_Resultatenhet] FOREIGN KEY([ResultatenhetFKId])
REFERENCES [Organisation].[Resultatenhet] ([Id])
GO
ALTER TABLE [Person].[ResultatenhetAvtal] CHECK CONSTRAINT [FK_AvtalResultatenhet_Resultatenhet]
GO
