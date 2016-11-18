USE [ODL]
GO
 
-- #############################################################
-- # TEMPORARILY DROP FK CONSTRAINTS IF EXIST (SINCE TRUNCATE IS NOT POSSIBLE WITH ENABLED FK CONSTRAINTS)
-- #############################################################

IF (OBJECT_ID('Person.FK_OrganisationAvtal_Organisation', 'F') IS NOT NULL)
	ALTER TABLE [Person].[OrganisationAvtal] DROP CONSTRAINT [FK_OrganisationAvtal_Organisation]
GO
IF (OBJECT_ID('Person.FK_OrganisationAvtal_Avtal', 'F') IS NOT NULL)
	ALTER TABLE [Person].[OrganisationAvtal] DROP CONSTRAINT [FK_OrganisationAvtal_Avtal]
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
TRUNCATE TABLE [Person].[OrganisationAvtal]

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
ALTER TABLE [Organisation].[Organisation]  WITH CHECK ADD  CONSTRAINT [FK_Organisation_Organisation] FOREIGN KEY([IngarIOrganisationFKId])
REFERENCES [Organisation].[Organisation] ([Id])
GO
ALTER TABLE [Organisation].[Organisation] CHECK CONSTRAINT [FK_Organisation_Organisation]
GO
ALTER TABLE [Person].[Anstalld]  WITH CHECK ADD  CONSTRAINT [FK_Anstalld_Person] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Anstalld] CHECK CONSTRAINT [FK_Anstalld_Person]
GO
ALTER TABLE [Person].[AnstalldAvtal]  WITH CHECK ADD  CONSTRAINT [FK_AnstalldAvtal_Anstalld] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Anstalld] ([PersonFKId])
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
ALTER TABLE [Person].[KonsultAvtal]  WITH CHECK ADD  CONSTRAINT [FK_KonsultAvtal_Konsult] FOREIGN KEY([PersonFKId])
REFERENCES [Person].[Konsult] ([PersonFKId])
GO
ALTER TABLE [Person].[KonsultAvtal] CHECK CONSTRAINT [FK_KonsultAvtal_Konsult]
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

DECLARE @createdTime datetime, @updatedTime datetime;

SET @createdTime = SYSDATETIME(); -- '2016-11-08 08:13:27.5080812'
SET @updatedTime = DATEADD(day, 45, @createdTime)


-- #############################################################
-- # INSERT Personer
-- #############################################################

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('93574395', 'Kalle', 'Ove', 'Nilsson', '197012123456', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('39487983', 'Marie', 'Eva', 'Persson', '196212303456', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('48795842', 'Anders', 'Ola', 'Svensson', '197505223456', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('93285742', 'Per', null, 'Andersson', '198512123456', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('39457836', 'Olle', 'Sven', 'Andersson', '195506103456', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('98427592', 'Anna', 'Maria', 'Nilsson', '196410261356', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('12093839', 'Erik', 'Henrik', 'Karlsson', '195511301456', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Person]([KallsystemId], [Fornamn], [Mellannamn], [Efternamn], [PersonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('56453549', 'Stina', null, 'Einarsson', '197002201406', @updatedTime, 'DBO', @createdTime, 'DBO')

-- #############################################################
-- # INSERT Anställda
-- #############################################################

INSERT INTO [Person].[Anstalld]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, 'KNI', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, 'MPE', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3, 'ASV', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4, 'PAN', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(6, 'ANI', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(7, 'EKA', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Anstalld]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(8, 'SEI', @updatedTime, 'DBO', @createdTime, 'DBO')
-- #############################################################
-- # INSERT Konsulter
-- #############################################################

INSERT INTO [Person].[Konsult]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(5, 'TOSV', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[Konsult]([PersonFKId], [Alias], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, 'TKNI', @updatedTime, 'DBO', @createdTime, 'DBO')


-- #############################################################
-- # INSERT Adresstyp
-- #############################################################

INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('GatuAdress',@updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('MailAdress',@updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Telefon', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressTyp]([Typ], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('Facebook', @updatedTime, 'DBO', @createdTime, 'DBO')

-- #############################################################
-- # INSERT Adressvariant
-- #############################################################

INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Folkbokföringsadress', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Adress Arbete', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'LeveransAdress', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'FaktureringsAdress', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Adressens Adress', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Tomte Adress', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2,'MailAdress Arbete', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2,'Mailadress Privat', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Mobil Arbete', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Mobil Privat', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Telefon Arbete', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'Telefon Privat', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4,'Facebook Privat', @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[AdressVariant]([AdressTypFKId], [Variant], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4,'Facebook Arbete', @updatedTime, 'DBO', @createdTime, 'DBO')


-- #############################################################
-- # INSERT Adress
-- #############################################################

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKId], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1,'Storvägen 11',84019,'Färila', 'Sverige', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Jobb*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKId], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2,'Drottningvägen 23',82240,'Järvsö', 'Sverige', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Mail Arbete*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(7, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[Mail]([AdressFKId], [MailAdress], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(3,'jarvsobacken@ptj.se', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Mail Privat*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(8, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[Mail]([AdressFKId], [MailAdress], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(4,'kalle.ove@gmail.com', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Tele Privat*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(9, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[Telefon]([AdressFKId], [TelefonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(5,'065112345', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Tele Arbete*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(10, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[Telefon]([AdressFKId], [TelefonNummer], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(6,'070123456', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(1, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKId], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(7,'Strandvägen 13',76534,'Alingsås', 'Sverige', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKId], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(8,'Bruksvägen 55',59732,'Uppsala', 'Sverige', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKId], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(9,'Glimmervägen 7',78563,'Uppsala', 'Sverige', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKId], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(10,'Falsterbovägen 2',78543,'Falsterbo', 'Sverige', @updatedTime, 'DBO', @createdTime, 'DBO')

/*Hem*/
INSERT INTO [Adress].[Adress]([AdressVariantFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(2, @updatedTime, 'DBO', @createdTime, 'DBO')
INSERT INTO [Adress].[GatuAdress]([AdressFKId], [AdressRad1], [Postnummer], [Stad], [Land], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(11,'Lundavägen 12A',96745,'Malmö', 'Sverige', @updatedTime, 'DBO', @createdTime, 'DBO')

-- #############################################################
-- # INSERT Personadress
-- #############################################################

INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(1,1)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(1,2)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(1,3)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(1,4)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(1,5)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(1,6)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(2,7)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(2,8)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(3,9)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(4,10)
INSERT INTO [Adress].[PersonAdress]([PersonFKId], [AdressFKId])
VALUES(5,11)


-- #############################################################
-- # INSERT Avtal
-- #############################################################

INSERT INTO [Person].[Avtal]([KallsystemId], [Avtalskod], [Avtalstext], [ArbetstidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('349587934875', 'E03', 'Vård och omsorg',20, 1, 'Underläkare', 1, 0, 0, '2011-06-15', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([PersonFKId], [AvtalFKId])
VALUES(1,1)

INSERT INTO [Person].[Avtal]([KallsystemId], [AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('949549874574', 'T01', 'Unionen, CF, tjänstemän. Månadslön', 40, 1, 'Läkare', 1, 0, 0, '2007-06-30', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([PersonFKId], [AvtalFKId])
VALUES(2,2)

INSERT INTO [Person].[Avtal]([KallsystemId], [AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('795803876395', 'T01', 'Unionen, CF, tjänstemän. Månadslön', 40, 1, 'Undersköterska', 1, 0, 0, '2010-01-01', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([PersonFKId], [AvtalFKId])
VALUES(3,3)

INSERT INTO [Person].[Avtal]([KallsystemId], [AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('245794587202', 'K01', 'Konsultavtal 1', 20, 1, 'Ortopedkonsult', 1, 0, 0, '2012-01-01', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[KonsultAvtal]([PersonFKId], [AvtalFKId])
VALUES(1,4)

-----
INSERT INTO [Person].[Avtal]([AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('K01', 'Anställningsavtal X', 40, 1, 'Tandläkare', 1, 1, 1, '2012-01-01', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([PersonFKId], [AvtalFKId])
VALUES(6,5)

INSERT INTO [Person].[Avtal]([AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('K01', 'Anställningsavtal Y', 40, 1, 'Tandläkare', 1, 1, 0, '2012-01-01', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([PersonFKId], [AvtalFKId])
VALUES(7,6)

INSERT INTO [Person].[Avtal]([AvtalsKod], [AvtalsText], [ArbetsTidVecka], [Befkod], [BefText], [Aktiv], [Ansvarig], [Chef], [AnstallningsDatum], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('K01', 'Anställningsavtal Z', 40, 6, 'Receptionist', 1, 0, 0, '2012-01-01', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Person].[AnstalldAvtal]([PersonFKId], [AvtalFKId])
VALUES(8,7)
-----

-- #############################################################
-- # INSERT Organisation, Resultatenhet tables
-- #############################################################


-- Organisation
INSERT INTO [Organisation].[Organisation]([OrganisationsId], [Namn], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('556038-0793', 'Södra ortopedmottagningen', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Organisation]([OrganisationsId], [Namn], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('557800-7753', 'Norra ortopedmottagningen', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Organisation]([OrganisationsId], [Namn], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('512500-7751', 'Tandläkarna i Väst, Gemensamma', @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Organisation]([OrganisationsId], [Namn], [IngarIOrganisationFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('523500-7862', 'Tandläkarna i Väst, Hk 1', 3, @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Organisation]([OrganisationsId], [Namn], [IngarIOrganisationFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES('534500-7973', 'Tandläkarna i Väst, Hk 2', 3, @updatedTime, 'DBO', @createdTime, 'DBO')

-- Resultatenhet
INSERT INTO [Organisation].[Resultatenhet]([KstNr], [Typ], [OrganisationFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(15, 'H', 1, @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Resultatenhet]([KstNr], [Typ], [OrganisationFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(22, 'H', 2, @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Resultatenhet]([KstNr], [Typ], [OrganisationFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(60, 'G', 3, @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Resultatenhet]([KstNr], [Typ], [OrganisationFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(61, 'H', 4, @updatedTime, 'DBO', @createdTime, 'DBO')

INSERT INTO [Organisation].[Resultatenhet]([KstNr], [Typ], [OrganisationFKId], [UppdateradDatum], [UppdateradAv], [SkapadDatum], [SkapadAv])
VALUES(62, 'H', 5, @updatedTime, 'DBO', @createdTime, 'DBO')

-- OrganisationAvtal
INSERT INTO [Person].[OrganisationAvtal]([AvtalFKId], [OrganisationFKId])
VALUES(1,1)

INSERT INTO [Person].[OrganisationAvtal]([AvtalFKId], [OrganisationFKId])
VALUES(4,2)
----------
INSERT INTO [Person].[OrganisationAvtal]([AvtalFKId], [OrganisationFKId])
VALUES(7,3)

INSERT INTO [Person].[OrganisationAvtal]([AvtalFKId], [OrganisationFKId])
VALUES(5,4)

INSERT INTO [Person].[OrganisationAvtal]([AvtalFKId], [OrganisationFKId])
VALUES(6,5)
