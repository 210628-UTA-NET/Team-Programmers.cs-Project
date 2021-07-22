using Microsoft.EntityFrameworkCore;
using StorefrontModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KanbanRepoDL
{
    public class StorefrontDBContext : DbContext
    {
        public DbSet<KanbanCard> KanbanCards { get; set; }
    protected override void OnModelCreating(ModelBuilder p_modelBuilder)
        {
            //It will auto generate the ID column for both tables
            p_modelBuilder.Entity<KanbanCard>()
                .Property(store => store.ID)
                .ValueGeneratedOnAdd();
        }
    }
}