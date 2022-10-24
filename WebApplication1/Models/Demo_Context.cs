using Microsoft.EntityFrameworkCore;

namespace S_c_first.Models
{
    public class Demo_Context : DbContext
    {
        public DbSet<User_M> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\temp\First.db");
    }
}
