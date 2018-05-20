using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork()
        {
            dbContext = new PruebaCoreContext();
        }

        private readonly PruebaCoreContext dbContext;

        private GenericRepository<Factura> _FacturaRepository;
        public GenericRepository<Factura> FacturaRepository
        {
            get
            {
                if (_FacturaRepository == null)
                {
                    _FacturaRepository = new GenericRepository<Factura>(dbContext);
                }

                return _FacturaRepository;
            }
        }

        private DetalleFacturaRepository _DetalleFacturaRepository;
        public DetalleFacturaRepository DetalleFacturaRepository
        {
            get
            {
                if (_DetalleFacturaRepository == null)
                {
                    _DetalleFacturaRepository = new DetalleFacturaRepository(dbContext);
                }

                return _DetalleFacturaRepository;
            }
        }

        public int SaveChanges()
        {
            try
            {
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
