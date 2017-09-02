using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ClassLibrary1_ef_tools.Models.Mapping;

namespace ClassLibrary1_ef_tools.Models
{
    public partial class SUTContext : DbContext
    {
        static SUTContext()
        {
            Database.SetInitializer<SUTContext>(null);
        }

        public SUTContext()
            : base("Name=SUTContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
