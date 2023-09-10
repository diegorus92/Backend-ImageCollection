using ImageCollectionAPI_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCollectionAPI_DAL.Data
{
    public partial class CollectionContext: DbContext 
    {
        public CollectionContext() { }
        public CollectionContext(DbContextOptions<CollectionContext> options): base(options) 
        {
        
        }

        public virtual DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(options => options.EnableRetryOnFailure());
        }
    }
}
