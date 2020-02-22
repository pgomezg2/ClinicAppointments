create table dbo.Specialties
(
  Id int identity(1,1) not null,
  SpecialtyName varchar(20) not null,
  constraint PK_Specialties primary key clustered (Id)
)

