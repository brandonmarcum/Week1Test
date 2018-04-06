use AdventureWorks;
GO

--VIEW
create view Person.vw_FullName with SCHEMABINDING
as
select firstname, middlename, lastname
from Person.Person;
go

select *
from Person.vw_FullName;
go

--FUNCTION
create function Person.fn_FullName(@name varchar(max))
returns table
as
  return
  select firstname, middlename, lastname
  from Person.Person
  where FirstName = @name or LastName = @name;
go

select *
from Person.fn_FullName('charles');
go

create function Person.fn_PrintFullName(@first varchar(max), @middle varchar(max), @last varchar(max))
returns varchar(max)
as
begin
  return @first + ' ' + coalesce(@middle + ' ', '') + @last
end
go

select Person.fn_PrintFullName(firstname, middlename, lastname) as Name
from Person.Person;
go

--STORED PROCEDURE
create procedure Person.sp_UpdateName(@id int, @name varchar(max))
as
begin
  update Person.Person
  set FirstName = @name
  where BusinessEntityID = @id
end
go

execute Person.sp_UpdateName 30, 'fred';
go

create procedure Person.sp_AddAddress(@street1 varchar(max), @street2 varchar(max), @city varchar(max))
as
begin
  declare @id int;

  select @id = AddressID
  from Person.Address
  where AddressLine1 = @street1;

  begin transaction
    begin try
      if (@id is null)
      begin
        --RAISERROR('error at line 67 for if statement', 16, 50000)
        insert into Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, rowguid, SpatialLocation)
        values (@city, @street2, @street1, 15, 33602, GETDATE(), '4d1b4626-e935-49dd-8a9c-a73a8d06101f', 0xE6100000010C2E5A039B50B84740F73F30C840805EC0);

        --insert into Person.BusinessEntityAddress
        commit transaction;
      end

      else
      begin
        --throw 50001, 'error at line 77 for else statement', 16;
        update Person.Address
        set AddressLine2 = @street2, City = @city
        where AddressID = @id

        --update Person.BusinessEntityAddress
        commit transaction;
      end
    end try

    begin catch
      print error_message();
      print error_severity();
      print error_number();
      print error_state();
      print @@trancount;
      print @@rowcount;
      rollback transaction
    end catch
end
go

exec Person.sp_AddAddress '983 fowler ave', 'nec building', 'orlando';

select *
from Person.Address
where AddressLine1 = '983 fowler ave'
