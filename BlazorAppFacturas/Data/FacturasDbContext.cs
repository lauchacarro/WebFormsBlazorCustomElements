using BlazorAppFacturas.Entities;

using Microsoft.EntityFrameworkCore;

namespace BlazorAppFacturas.Data
{
    public class FacturasDbContext : DbContext
    {
        public FacturasDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Factura> Facturas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>()
                .InsertUsingStoredProcedure(
                    "usp_FacturasInsert",
                    storedProcedureBuilder =>
                    {
                        storedProcedureBuilder.HasParameter(x => x.Codigo);
                        storedProcedureBuilder.HasParameter(x => x.Descripcion);
                        storedProcedureBuilder.HasParameter(x => x.Total);
                        storedProcedureBuilder.HasParameter(x => x.SubTotal);
                        storedProcedureBuilder.HasParameter(x => x.Vendedor);
                        storedProcedureBuilder.HasParameter(x => x.MetodoPago);
                        storedProcedureBuilder.HasParameter(x => x.Pagado);
                        storedProcedureBuilder.HasResultColumn(a => a.Id);
                    })
                .UpdateUsingStoredProcedure(
                    "usp_FacturasUpdate",
                    storedProcedureBuilder =>
                    {
                        storedProcedureBuilder.HasOriginalValueParameter(x => x.Id);
                        storedProcedureBuilder.HasParameter(x => x.Codigo);
                        storedProcedureBuilder.HasParameter(x => x.Descripcion);
                        storedProcedureBuilder.HasParameter(x => x.Total);
                        storedProcedureBuilder.HasParameter(x => x.SubTotal);
                        storedProcedureBuilder.HasParameter(x => x.Vendedor);
                        storedProcedureBuilder.HasParameter(x => x.MetodoPago);
                        storedProcedureBuilder.HasParameter(x => x.Pagado);
                    })
                .DeleteUsingStoredProcedure(
                    "usp_FacturasDelete",
                    storedProcedureBuilder =>
                    {
                        storedProcedureBuilder.HasOriginalValueParameter(x => x.Id);
                    });
        }
    }
}
