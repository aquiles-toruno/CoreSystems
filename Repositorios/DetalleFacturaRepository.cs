using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class DetalleFacturaRepository : GenericRepository<DetalleFactura>
    {
        public DetalleFacturaRepository(PruebaCoreContext _dbContext) : base(_dbContext)
        {
            dbContext = _dbContext;
        }

        private readonly PruebaCoreContext dbContext;

        public IEnumerable<DetalleFactura> GetDetalleFacturaByFactura(int facturaId)
        {
            return dbContext.DetalleFacturas.Where(x => x.FacturaId == facturaId).AsEnumerable();
        }
    }
}
