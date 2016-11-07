USE [ODL]
GO

-- #############################################################
-- # TEMPORARILY DROP FK CONSTRAINTS IF EXIST (SINCE TRUNCATE IS NOT POSSIBLE WITH ENABLED FK CONSTRAINTS)
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
-- # TRUNCATE TABLES (IDENTITY COLUMN COUNTERS ARE RESET)
-- #############################################################

TRUNCATE TABLE [Person].[KonsultAvtal]
TRUNCATE TABLE [Person].[AnstalldAvtal]
TRUNCATE TABLE [Person].[ResultatenhetAvtal]

TRUNCATE TABLE [Adress].[PersonAdress]
TRUNCATE TABLE [Adress].[OrganisationAdress]

TRUNCATE TABLE [Adress].[Telefon]
TRUNCATE TABLE [Adress].[Mail]
TRUNCATE TABLE [Adress].[GatuAdress]

TRUNCATE TABLE [Organisation].[Resultatenhet]
TRUNCATE TABLE [Organisation].[Organisation]

TRUNCATE TABLE [Person].[Konsult]
TRUNCATE TABLE [Person].[Anstalld]

TRUNCATE TABLE [Person].[Person]
TRUNCATE TABLE [Person].[Avtal]

TRUNCATE TABLE [Adress].[Adress]
TRUNCATE TABLE [Adress].[AdressVariant]
TRUNCATE TABLE [Adress].[AdressTyp]


-- #############################################################
-- # NOW RECREATE FK CONSTRAINTS
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

DECLARE @updatedTime as datetime;
SET @updatedTime = SYSDATETIME();


-- #############################################################
-- # INSERT Personer
-- #############################################################

INSERT INTO [Person].[Person]([Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Kalle', 'Ove', 'Nilsson', '8012123456', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Person]([Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Marie', 'Eva', 'Persson', '7012123456', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Person]([Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Anders', 'Ola', 'Svensson', '7512123456', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Person]([Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Per', '', 'Andersson', '8512123456', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Person]([Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Olle', 'Sven', 'Andersson', '5512123456', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Person]([Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Anna', 'Maria', 'Nilsson', '6512123456', @updatedTime, 'DBO', @updatedTime, 'DBO')

-- #############################################################
-- # INSERT Anställda
-- #############################################################

INSERT INTO [Person].[Anstalld]([PersonFKId], [Typ], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, 1, 'KNI', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Typ], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, 1, 'MPE', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Typ], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3, 1, 'ASV', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Typ], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4, 1, 'PAN', @updatedTime, 'DBO', @updatedTime, 'DBO')

-- #############################################################
-- # INSERT Konsulter
-- #############################################################

INSERT INTO [Person].[Konsult]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(5, 'TOSV', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Konsult]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(6, 'TANI', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[Konsult]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, 'TKNI', @updatedTime, 'DBO', @updatedTime, 'DBO')

-- #############################################################
-- # INSERT Avtal
-- #############################################################

INSERT INTO [Person].[Avtal]([Avtalskod], [Avtalstext], [ArbetstidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('E03', 'Vård och omsorg',40, 1, 'Underläkare', 1, 0, 0, '2011-06-15', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([AnstalldFKID], [AvtalFKID])
VALUES(1,1)

INSERT INTO [Person].[Avtal]([AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('T01', 'Unionen, CF, tjänstemän. Månadslön', 40, 1, 'Läkare', 1, 0, 0, '2007-06-30', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([AnstalldFKID], [AvtalFKID])
VALUES(2,2)

INSERT INTO [Person].[Avtal]([AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('T01', 'Unionen, CF, tjänstemän. Månadslön', 40, 1, 'Undersköterska', 1, 0, 0, '2010-01-01', @updatedTime, 'DBO', @updatedTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([AnstalldFKID], [AvtalFKID])
VALUES(3,3)

-- #############################################################
-- # INSERT Adresstyp
-- #############################################################

INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('GatuAdress',@updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('MailAdress',@updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Telefon', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Facebook', @updatedTime, 'DBO', @updatedTime, 'DBO')

-- #############################################################
-- # INSERT Adressvariant
-- #############################################################

INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Folkbokföringsadress', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Adress Arbete', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'LeveransAdress', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'FaktureringsAdress', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Adressens Adress', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Tomte Adress', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2,'MailAdress Arbete', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2,'Mailadress Privat', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Mobil Arbete', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Mobil Privat', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Telefon Arbete', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Telefon Privat', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4,'Facebook Privat', @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKID], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4,'Facebook Arbete', @updatedTime, 'DBO', @updatedTime, 'DBO')


-- #############################################################
-- # INSERT Adress
-- #############################################################

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKID], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Storvägen 11',84019,'Färila', 'Sverige', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Jobb*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKID], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2,'Drottningvägen 23',82240,'Järvsö', 'Sverige', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Mail Arbete*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(7, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[Mail]([AdressFKID], [MailAdress], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'jarvsobacken@ptj.se', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Mail Privat*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(8, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[Mail]([AdressFKID], [MailAdress], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4,'kalle.ove@gmail.com', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Tele Privat*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(9, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[Telefon]([AdressFKID], [TelefonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(5,'065112345', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Tele Arbete*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(10, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[Telefon]([AdressFKID], [TelefonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(6,'070123456', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKID], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(7,'Strandvägen 13',76534,'Alingsås', 'Sverige', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKID], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(8,'Bruksvägen 55',59732,'Uppsala', 'Sverige', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKID], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(9,'Glimmervägen 7',78563,'Uppsala', 'Sverige', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKID], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(10,'Falsterbovägen 2',78543,'Falsterbo', 'Sverige', @updatedTime, 'DBO', @updatedTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKID], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @updatedTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKID], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(11,'Lundavägen 12A',96745,'Malmö', 'Sverige', @updatedTime, 'DBO', @updatedTime, 'DBO')

-- #############################################################
-- # INSERT Personadress
-- #############################################################

INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(1,1)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(1,2)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(1,3)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(1,4)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(1,5)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(1,6)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(2,7)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(2,8)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(3,9)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(4,10)
INSERT INTO [Adress].[PersonAdress]([PersonFKID], [AdressFKID])
VALUES(5,11)


GO


