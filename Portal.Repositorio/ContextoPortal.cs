using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using Portal.Dominio;

namespace Portal.Repositorio
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ContextoPortal : DbContext
    {
        public ContextoPortal() : base("PortalConexao")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextoPortal>());
        }

        static ContextoPortal()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Palestra> Palestras { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.AddFromAssembly(typeof(Pessoa).Assembly);
            base.OnModelCreating(modelBuilder);


        }
        
    }
}
