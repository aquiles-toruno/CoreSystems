using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Clientes")]
    public class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        [Column(TypeName = "varchar")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Codigo { get; set; }//Podría ser la cédula

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
