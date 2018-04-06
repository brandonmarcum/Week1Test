use AdventureWorks;
go

--CREATE DATABASE
--create database FredDB;

--CREATE SCHEMA
create schema Contact;
go

--CREATE TABLES
create table Contact.Person
(
  PersonId int primary key identity(1,1)
  ,PhoneId int foreign key references Contact.Phone(PhoneId)
  ,FirstName nvarchar(150) not null
  ,LastName nvarchar(150) not null
  ,ModifiedDate as sysutcdatetime()
  ,Active bit not null default(1)
);

create table Contact.Email
(
  EmailId int not null
  ,PersonId int null
  ,[Address] nvarchar(100) not null
  ,ModifiedDate datetime2(0) not null
  ,Active bit not null
  ,primary key (EmailId)
  ,foreign key (PersonId) references Contact.Person(PersonId)
);

create table Contact.Phone
(
  PhoneId int not null
  ,[Number] nchar(10) not null
  ,ModifiedDate datetime2(0) not null
  ,Active bit not null 
);

--ALTER TABLES
alter table Contact.Phone
  add constraint PK_Phone_PhoneId primary key (PhoneId);

alter table Contact.Email
  add constraint CK_Email_Address check([Address] like '%@%.%');

alter table Contact.Email
  add constraint FK_Email_PersonId foreign key (PersonId) references Contact.Person(PersonId) on update cascade;

alter table Contact.Person
  add FullName as FirstName + ' ' + LastName persisted;

alter table Contact.Person
  alter column LastName varchar(100) not null;

--DROP TABLES
drop table Contact.Phone;

--TRUNCATE TABLES
truncate table Contact.Phone;

select * from Contact.Person;
go

--TRIGGERS
create trigger Contact.tr_Person on Contact.Person
instead of delete
as
begin
  update Contact.Person
  set Active = 0
  where PersonId in 
  (
    select PersonId
    from deleted
  );
end
go

create trigger Contact.tr_PersonHistory on Contact.Person
after update
as
begin
  insert into Contact.NewHistory
  select *
  from inserted;

  insert into Contact.OldHistory
  select *
  from deleted;
end
go
