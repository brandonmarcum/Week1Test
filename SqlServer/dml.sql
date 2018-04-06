USE AdventureWorks;
GO

-- SELECT
select 'hello sql';

select *
from Person.Person;

select FirstName, MiddleName, LastName
from Person.Person;

select FirstName, MiddleName as 'Name Middle', LastName as [Family Name]
from Person.Person;

select FirstName, MiddleName, LastName
from Person.Person
where FirstName = 'john' or MiddleName = 'john' or LastName = 'john'
-- COLLATE Latin1_General_CS_AS_KS_WS

select FirstName, MiddleName, LastName
from Person.Person
where FirstName like '%john';

select FirstName, MiddleName, LastName
from Person.Person
where FirstName like 'j___';

select FirstName, MiddleName, LastName
from Person.Person
where FirstName like 'j[a-k][a-k][a-k]';

select count(*), FirstName, MiddleName
from Person.Person
where LastName = 'smith'
group by MiddleName, FirstName
having count(*) = 1;

select count(*), FirstName, MiddleName as MN
from Person.Person pp
where LastName = 'smith'
group by MiddleName, FirstName
having count(*) = 1
order by pp.MiddleName asc, FirstName desc;

--execution order
--from > where > group by > having > select > order by

-- INSERT
select * from Person.Address where City = 'tampa';
insert into Person.Address
values ('123 main st', null, 'tampa', 79, 98011, 0xE6100000010C2E5A039B50B84740F73F30C840805EC0, '4d1b4626-e935-49dd-8a9c-a73a8d06101b', '2018-03-21');

insert into Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, rowguid, SpatialLocation)
values ('tampa', null, 'fowler ave', 15, 33602, '2018-03-20', '4d1b4626-e935-49dd-8a9c-a73a8d06101c', 0xE6100000010C2E5A039B50B84740F73F30C840805EC0);

insert into Person.Address(City, AddressLine2, AddressLine1, StateProvinceID, PostalCode, ModifiedDate, SpatialLocation)
select City, Addressline2, Addressline1, StateProvinceid,Postalcode,modifieddate, spatiallocation
from Person.Address
where Addressid < 10;

bulk insert Person.Address from 'https://s3.us-east-2.amazonaws.com/1803-mar12-net/data.csv' with (rowterminator = '\n', fieldterminator = ',');

-- UPDATE
update Person.Address
set AddressLine1 = '983 fowler ave'
where City = 'tampa' and modifieddate = '2018-03-21';

update pa
set addressline1 = '981 fowler ave'
from Person.Address as pa, Person.Person as pp
--join
where city = 'tampa' and pp.ModifiedDate = '2018-03-21';

-- DELETE
delete from Person.Address
where AddressLine1 = '983 fowler ave';

delete pa
from Person.Address as pa, Person.Person as pp
--join
where AddressLine1 = '983 fowler ave';

--JOIN
select FirstName, LastName, AddressLine1, City, StateProvinceCode
from Person.Person as pp
left join Person.BusinessEntityAddress as pb on pb.BusinessEntityID = pp.BusinessEntityID
left join Person.Address as pa on pa.AddressID = pb.AddressID
left join Person.StateProvince as ps on ps.StateProvinceId = pa.StateProvinceId
where StateProvinceCode = 'WA' and (AddressLine1 like '%street%') and FirstName > 'j' and FirstName < 'k';

--subquery
select FirstName, LastName, AddressLine1, City, StateProvinceCode
from Person.Person as pp
inner join Person.BusinessEntityAddress as pb on pb.BusinessEntityID = pp.BusinessEntityID
inner join
(
  select AddressLine1, AddressID, StateProvinceID, City
  from Person.Address
  where AddressLine1 like '%street%'
) as pa on pa.AddressID = pb.AddressID
inner join
(
  select StateProvinceID, StateProvinceCode
  from Person.StateProvince
  where StateProvinceCode = 'WA'
) as ps on ps.StateProvinceId = pa.StateProvinceId
where FirstName > 'j' and FirstName < 'k';

--common table expression - CTE
with addr(al1, ai, spi, c) as
(
  select AddressLine1, AddressID, StateProvinceID, City
  from Person.Address
  where AddressLine1 like '%street%'
),
prov(spi, spc) as 
(
  select StateProvinceID, StateProvinceCode
  from Person.StateProvince
  where StateProvinceCode = 'WA'
)
select FirstName, LastName, al1, c, spc
from Person.Person as pp
inner join Person.BusinessEntityAddress as pb on pb.BusinessEntityID = pp.BusinessEntityID
inner join addr on addr.ai = pb.Addressid
inner join prov on prov.spi = addr.spi
where FirstName > 'j' and FirstName < 'k';

select p.Name
from Sales.SalesOrderHeader as soh
inner join
(
  select *
  from Sales.SalesOrderDetail
) as sod on sod.SalesOrderID = soh.SalesOrderID
left join
(
  select *
  from Production.Product
) as p on p.ProductID = sod.ProductID
--where year(OrderDate) = 2013;
--where OrderDate >= '2013-01-01' and OrderDate < '2014-01-01';
where OrderDate between '2013-01-01' and '2013-12-31';

select firstname
from Person.Person

union all

select name
from Production.Product

select firstname
from Person.Person

intersect

select lastname
from Person.Person

select firstname
from Person.Person

except

select lastname
from Person.Person

select firstname
from Person.Person

union

select firstname
from Person.Person

select distinct firstname
from Person.Person;

select firstname + ' ' + middlename + ' ' + lastname
from Person.Person;

select firstname + ' ' + isnull(middlename + ' ', '') + lastname
from Person.Person;

select firstname + ' ' + coalesce(null, null, middlename + ' ') + lastname
from Person.Person;

select firstname + ' ' + isnull(middlename + ' ', '') + lastname
from Person.Person
where MiddleName is not null;

select firstname + ' ' + isnull(middlename + ' ', '') + lastname
from Person.Person
where MiddleName in ('A', 'b', 'c');

select firstname + ' ' + isnull(middlename + ' ', '') + lastname
from Person.Person
where middlename in
(
  select MiddleName
  from Person.Person
  where MiddleName < 't'
);

select firstname + ' ' + isnull(middlename + ' ', '') + lastname
from Person.Person
where exists
(
  select firstname
  from Person.Person

  intersect

  select lastname
  from Person.Person
);

-->, >=, =, <, <=, !=, <>, is, is not, in, not in, exists, not exists
