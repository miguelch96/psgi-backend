using LightInject;
using Model.Auth;
using Model.Domain;
using Model.Domain.Estatico;
using Model.Domain.Organizacion;
using Persistence.DbContextScope;
using Persistence.Repository;
using Service.OrganizacionServices;

namespace Service.Config
{
    public class ServiceRegister : ICompositionRoot
    {               
        public void Compose(IServiceRegistry container)
        {
            var ambientDbContextLocator = new AmbientDbContextLocator();

            container.Register<IDbContextScopeFactory>((x) => new DbContextScopeFactory(null));
            container.Register<IAmbientDbContextLocator, AmbientDbContextLocator>(new PerScopeLifetime());

            container.Register<IRepository<ApplicationUser>>((x) => new Repository<ApplicationUser>(ambientDbContextLocator));
            container.Register<IRepository<ApplicationRole>>((x) => new Repository<ApplicationRole>(ambientDbContextLocator));
            container.Register<IRepository<Course>>((x) => new Repository<Course>(ambientDbContextLocator));
            container.Register<IRepository<Student>>((x) => new Repository<Student>(ambientDbContextLocator));
            container.Register<IRepository<StudentPerCourse>>((x) => new Repository<StudentPerCourse>(ambientDbContextLocator));
            container.Register<IRepository<Miembro>>((x) => new Repository<Miembro>(ambientDbContextLocator));
            container.Register<IRepository<TipoDocumento>>((x) => new Repository<TipoDocumento>(ambientDbContextLocator));
            container.Register<IRepository<Division>>((x) => new Repository<Division>(ambientDbContextLocator));
            container.Register<IRepository<TipoMiembro>>((x) => new Repository<TipoMiembro>(ambientDbContextLocator));
            container.Register<IRepository<Estado>>((x) => new Repository<Estado>(ambientDbContextLocator));
            container.Register<IRepository<Territorio>>((x) => new Repository<Territorio>(ambientDbContextLocator));
            container.Register<IRepository<Area>>((x) => new Repository<Area>(ambientDbContextLocator));
            container.Register<IRepository<Zona>>((x) => new Repository<Zona>(ambientDbContextLocator));
            container.Register<IRepository<Sector>>((x) => new Repository<Sector>(ambientDbContextLocator));
            container.Register<IRepository<Grupo>>((x) => new Repository<Grupo>(ambientDbContextLocator));

            container.Register<IStudentService, StudentService>();
            container.Register<IStudentPerCourseService, StudentPerCourseService>();
            container.Register<ICourseService, CourseService>();
            container.Register<IUserService, UserService>();
            container.Register<IMiembroService, MiembroService>();
            container.Register<ITipoDocumentoService, TipoDocumentoService>();
            container.Register<IDivisionService, DivisionService>();
            container.Register<ITipoMiembroService, TipoMiembroService>();
            container.Register<IEstadoService, EstadoService>();
            container.Register<ITerritorioService, TerritorioService>();
            container.Register<IAreaService, AreaService>();
            container.Register<IZonaService, ZonaService>();
            container.Register<ISectorService, SectorService>();
            container.Register<IGrupoService, GrupoService>();
        }
    }
}
