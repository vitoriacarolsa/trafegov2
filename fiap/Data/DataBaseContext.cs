using fiap.Models;
using Microsoft.EntityFrameworkCore;

namespace fiap.Data
{
    public class DataBaseContext : DbContext
    {

        public virtual DbSet<SemaforoModel> Semaforos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SemaforoModel>(entity =>
            {
                entity.ToTable("tb_semaforo");
                entity.HasKey(e => e.SemaforoId);
            });

        }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DataBaseContext()
        {
        }
    }
}
