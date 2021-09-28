/*
Procedimiento para buscar una persona por su ID
*/
create proc BuscarPersonaCodigo 
	@PersonID int
as
select * from Person where PersonID = @PersonID;
go

/*
Procedimiento para buscar una persona por su nombre
*/
create proc BuscarPersonaNombre
	@FirstName nvarchar(50)
as
select * from Person where FirstName like '%'+@FirstName+'%';
go

/*
Procedimiento para buscar una persona por su apellido
*/
create proc BuscarPersonaApellido
	@LastName nvarchar(50)
as
select * from Person where LastName like '%'+@LastName+'%';
go