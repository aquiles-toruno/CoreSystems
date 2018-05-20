using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Facturas")]
    public class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int Id { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Codigo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public decimal Total { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
