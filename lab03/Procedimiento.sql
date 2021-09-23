create proc BuscarPersonaNombre
	@FirstName nvarchar(50)
as
select * from Person where FirstName like '%'+@FirstName+'%';

/*
Ejemplo de ejecución
exec dbo.BuscarPersonaNombre ia;
*/

create proc BuscarCursoTitulo
	@Title nvarchar(50)
as
select * from Course where Title like '%'+@Title+'%';

/*
Ejemplo de ejecución
exec dbo.BuscarCursoTitulo lite;
*/