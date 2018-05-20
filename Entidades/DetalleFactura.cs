using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("DetalleFacturas")]
    public class DetalleFactura
    {
        public int Id { get; set; }
        [Required]
        public int FacturaId { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public short Cantidad { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public decimal Total { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
