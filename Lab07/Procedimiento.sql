create proc FindPersonByData
@Busqueda nvarchar(50)
as
select * from Person
where 
PersonID like  '%' +@Busqueda +'%' or
FirstName like  '%' +@Busqueda +'%' or
LastName like  '%' +@Busqueda +'%' 