using Microsoft.EntityFrameworkCore;
using System;
using WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApp
{
    public class DBContext : DbContext
    {
        
        public DbSet<KanbanCard> KanbanCards { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlServer(@"Server=tcp:jhe.database.windows.net,1433;Initial Catalog=KanbanBoard;Persist Security Info=False;User ID=asapjules;Password=Atomicbomb1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
    protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            //It will auto generate the ID column for both tables
            p_modelBuilder.Entity<KanbanCard>()
                .Property(store => store.ID)
                .ValueGeneratedOnAdd();
        }
    }
}