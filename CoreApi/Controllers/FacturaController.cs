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
    public class FacturaController : ApiController
    {
        private readonly UnitOfWork unitOfWork;
        private readonly GenericRepository<Factura> repositorio;

        public FacturaController()
        {
            unitOfWork = new UnitOfWork();
            repositorio = unitOfWork.FacturaRepository;
        }

        public IEnumerable<Factura> Get()
        {
            return repositorio.GetAll();
        }

        public Factura Get(int id)
        {
            return repositorio.GetById(id);
        }

        public IHttpActionResult Post([FromBody]Factura factura)
        {
            repositorio.Add(factura);
            unitOfWork.SaveChanges();
            return Ok(factura);
        }

        public IHttpActionResult Put(int id, [FromBody]Factura factura)
        {
            repositorio.Update(factura);
            unitOfWork.SaveChanges();
            return Ok(factura);
        }

        public void Delete(int id)
        {
            var factura = repositorio.GetById(id);

            if (factura != null)
                repositorio.Delete(factura);
        }
    }
}
