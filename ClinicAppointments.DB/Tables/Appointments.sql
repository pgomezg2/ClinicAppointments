create table dbo.Appointments
(
  Id int identity(1,1) not null,
  PatientId int not null,
  SpecialtyId int not null,
  AppointmentDateTime Datetime not null,
  constraint PK_Appointments primary key clustered (Id)
)
go

alter table dbo.Appointments add constraint FK_Appointments_Patients foreign key(PatientId)
references dbo.Patients (Id)
go

alter table dbo.Appointments add constraint FK_Appointments_Specialties foreign key(SpecialtyId)
references dbo.Specialties (Id)
go
