using Microsoft.AspNet.Identity.EntityFramework;
using Common;
using System.Data.Entity;
using Model.Domain;
using System.Reflection;
using System.Linq;
using Model.Helper;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using EntityFramework.DynamicFilters;
using Common.CustomFilters;
using Model.Auth;
using Model.Domain.Estatico;
using Model.Domain.Examen;
using Model.Domain.Organizacion;
using Model.Domain.Suscripcion;

namespace Persistence.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }

        public virtual DbSet<Student> Student { get;set; }
        public virtual DbSet<StudentPerCourse> StudentPerCourse { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Miembro> Miembro { get; set; }
        public virtual DbSet<Territorio> Territorio { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Zona> Zona { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Examen> Examen { get; set; }
        public virtual DbSet<ExamenMiembro> ExamenMiembro { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoMiembro> TipoMiembro { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<DetalleSuscripcion> DetalleSuscripcion { get; set; }
        public virtual DbSet<Suscripcion> Suscripcion { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<TipoSuscripcion> TipoSuscripcion { get; set; }
       

        public ApplicationDbContext()
            : base($"name={Parameters.AppContext}")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AddMyFilters(ref modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)));
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                x => x.Entity is AuditEntity
                    && (
                    x.State == EntityState.Added
                    || x.State == EntityState.Modified
                    || x.State == EntityState.Deleted
                )
            );

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;
                if (entity != null)
                {
                    var date = DateTime.Now;
                    var userId = CurrentUserHelper.Get != null ? CurrentUserHelper.Get.UserId : null;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedAt = date;
                        entity.CreatedBy = userId;
                    }
                    else if (entity is ISoftDeleted && ((ISoftDeleted)entity).Deleted)
                    {
                        entity.DeletedAt = date;
                        entity.DeletedBy = userId;
                    }

                    Entry(entity).Property(x => x.CreatedAt).IsModified = false;
                    Entry(entity).Property(x => x.CreatedBy).IsModified = false;

                    entity.UpdatedAt = date;
                    entity.UpdatedBy = userId;
                }
            }
        }

        private void AddMyFilters(ref DbModelBuilder modelBuilder)
        {
            modelBuilder.Filter(Enums.MyFilters.IsDeleted.ToString(), (ISoftDeleted ea) => ea.Deleted, false);
        }
    }
}
