create table dbo.Patients
(
  Id int identity(1,1) not null,
  Identification varchar(20) not null,
  FirstName varchar(50) not null,
  LastName varchar(50) not null,
  Age int,
  PhoneNumber varchar(50),
  Email varchar(100),
  constraint PK_Patients primary key clustered (Id)
)
