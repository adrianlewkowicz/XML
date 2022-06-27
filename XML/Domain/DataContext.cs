using Microsoft.EntityFrameworkCore;

namespace XML.Domain
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

      public DbSet<Reference> References { get; set; }
    }
}
