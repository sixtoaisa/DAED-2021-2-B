﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab15.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SchoolEntities : DbContext
    {
        public SchoolEntities()
            : base("name=SchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseGrade> CourseGrade { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<OfficeAssignment> OfficeAssignment { get; set; }
        public virtual DbSet<OnlineCourse> OnlineCourse { get; set; }
        public virtual DbSet<OnsiteCourse> OnsiteCourse { get; set; }
        public virtual DbSet<Person> Person { get; set; }
    
        public virtual ObjectResult<BuscarCursoTitulo_Result> BuscarCursoTitulo(string title)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarCursoTitulo_Result>("BuscarCursoTitulo", titleParameter);
        }
    
        public virtual ObjectResult<BuscarPersonaApellido_Result> BuscarPersonaApellido(string lastName)
        {
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarPersonaApellido_Result>("BuscarPersonaApellido", lastNameParameter);
        }
    
        public virtual ObjectResult<BuscarPersonaCodigo_Result> BuscarPersonaCodigo(Nullable<int> personID)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarPersonaCodigo_Result>("BuscarPersonaCodigo", personIDParameter);
        }
    
        public virtual ObjectResult<BuscarPersonaNombre_Result> BuscarPersonaNombre(string firstName)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<BuscarPersonaNombre_Result>("BuscarPersonaNombre", firstNameParameter);
        }
    
        public virtual int DeleteOfficeAssignment(Nullable<int> instructorID)
        {
            var instructorIDParameter = instructorID.HasValue ?
                new ObjectParameter("InstructorID", instructorID) :
                new ObjectParameter("InstructorID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteOfficeAssignment", instructorIDParameter);
        }
    
        public virtual int DeletePerson(Nullable<int> personID)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeletePerson", personIDParameter);
        }
    
        public virtual ObjectResult<FindPersonByData_Result> FindPersonByData(string busqueda)
        {
            var busquedaParameter = busqueda != null ?
                new ObjectParameter("Busqueda", busqueda) :
                new ObjectParameter("Busqueda", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FindPersonByData_Result>("FindPersonByData", busquedaParameter);
        }
    
        public virtual ObjectResult<GetStudentGrades_Result> GetStudentGrades(Nullable<int> studentID)
        {
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("StudentID", studentID) :
                new ObjectParameter("StudentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetStudentGrades_Result>("GetStudentGrades", studentIDParameter);
        }
    
        public virtual ObjectResult<byte[]> InsertOfficeAssignment(Nullable<int> instructorID, string location)
        {
            var instructorIDParameter = instructorID.HasValue ?
                new ObjectParameter("InstructorID", instructorID) :
                new ObjectParameter("InstructorID", typeof(int));
    
            var locationParameter = location != null ?
                new ObjectParameter("Location", location) :
                new ObjectParameter("Location", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<byte[]>("InsertOfficeAssignment", instructorIDParameter, locationParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> InsertPerson(string lastName, string firstName, Nullable<System.DateTime> hireDate, Nullable<System.DateTime> enrollmentDate)
        {
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var hireDateParameter = hireDate.HasValue ?
                new ObjectParameter("HireDate", hireDate) :
                new ObjectParameter("HireDate", typeof(System.DateTime));
    
            var enrollmentDateParameter = enrollmentDate.HasValue ?
                new ObjectParameter("EnrollmentDate", enrollmentDate) :
                new ObjectParameter("EnrollmentDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("InsertPerson", lastNameParameter, firstNameParameter, hireDateParameter, enrollmentDateParameter);
        }
    
        public virtual ObjectResult<byte[]> UpdateOfficeAssignment(Nullable<int> instructorID, string location, byte[] origTimestamp)
        {
            var instructorIDParameter = instructorID.HasValue ?
                new ObjectParameter("InstructorID", instructorID) :
                new ObjectParameter("InstructorID", typeof(int));
    
            var locationParameter = location != null ?
                new ObjectParameter("Location", location) :
                new ObjectParameter("Location", typeof(string));
    
            var origTimestampParameter = origTimestamp != null ?
                new ObjectParameter("OrigTimestamp", origTimestamp) :
                new ObjectParameter("OrigTimestamp", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<byte[]>("UpdateOfficeAssignment", instructorIDParameter, locationParameter, origTimestampParameter);
        }
    
        public virtual int UpdatePerson(Nullable<int> personID, string lastName, string firstName, Nullable<System.DateTime> hireDate, Nullable<System.DateTime> enrollmentDate)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var hireDateParameter = hireDate.HasValue ?
                new ObjectParameter("HireDate", hireDate) :
                new ObjectParameter("HireDate", typeof(System.DateTime));
    
            var enrollmentDateParameter = enrollmentDate.HasValue ?
                new ObjectParameter("EnrollmentDate", enrollmentDate) :
                new ObjectParameter("EnrollmentDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePerson", personIDParameter, lastNameParameter, firstNameParameter, hireDateParameter, enrollmentDateParameter);
        }
    }
}
