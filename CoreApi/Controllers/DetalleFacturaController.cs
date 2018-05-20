using Entidades;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreApi.Controllers
{
    public class DetalleFacturaController : ApiController
    {
        private readonly UnitOfWork unitOfWork;
        private readonly DetalleFacturaRepository repositorio;

        public DetalleFacturaController()
        {
            unitOfWork = new UnitOfWork();
            repositorio = unitOfWork.DetalleFacturaRepository;
        }

        public IEnumerable<DetalleFactura> Get()
        {
            return repositorio.GetAll();
        }

        public DetalleFactura Get(int id)
        {
            return repositorio.GetById(id);
        }

        public IEnumerable<DetalleFactura> GetByFactura(int facturaId)
        {
            return repositorio.GetDetalleFacturaByFactura(facturaId);
        }

        public IHttpActionResult Post([FromBody]DetalleFactura detalleFactura)
        {
            repositorio.Add(detalleFactura);
            unitOfWork.SaveChanges();
            return Ok(detalleFactura);
        }

        public IHttpActionResult Put(int id, [FromBody]DetalleFactura detalleFactura)
        {
            repositorio.Update(detalleFactura);
            unitOfWork.SaveChanges();
            return Ok(detalleFactura);
        }

        public void Delete(int id)
        {
            var factura = repositorio.GetById(id);

            if (factura != null)
                repositorio.Delete(factura);
        }
    }
}
