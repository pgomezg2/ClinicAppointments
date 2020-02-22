/*
Post-Deployment Script Template              
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.    
 Use SQLCMD syntax to include a file in the post-deployment script.      
 Example:      :r .\myfile.sql                
 Use SQLCMD syntax to reference a variable in the post-deployment script.    
 Example:      :setvar TableName MyTable              
               SELECT * FROM [$(TableName)]          
--------------------------------------------------------------------------------------
*/

------------------------------------------------------- Specialties -------------------------------------------------------
-- Erase data to ensure non duplicates
delete from dbo.Specialties

-- Reset IDENTITY
dbcc checkident ('dbo.Specialties', reseed, 0);

-- set identity_insert to on.
set identity_insert dbo.Specialties on

insert into dbo.Specialties (Id,SpecialtyName) values (1,'Medicina General')
insert into dbo.Specialties (Id,SpecialtyName) values (2,'Odontología')
insert into dbo.Specialties (Id,SpecialtyName) values (3,'Pediatría')
insert into dbo.Specialties (Id,SpecialtyName) values (4,'Neurología')

set identity_insert dbo.Specialties off
