using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Debe asignar una categoría al producto")]
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage ="Debe incluir el código del producto")]
        [StringLength(5,MinimumLength =3,ErrorMessage ="El código del producto debe tener de 3 a 5 caracteres")]
        public string Code { get; set; }
        
        [Required(ErrorMessage ="Debe incluir el nombre del producto")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="El nombre del producto debe tener entre 3 a 50 caracteres")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Debe incluir el precio unitario del producto")]
        public decimal UnitPrice { get; set; }
        
        [Required(ErrorMessage = "Debe incluir el stock del producto")]
        public int Stock { get; set; }

        [StringLength(250, ErrorMessage = "La descripción del producto debe tener un máximo de 250 caracteres")]
        public string Description { get; set; }
        public bool? Condition { get; set; }
        public virtual Category Category { get; set; }
    }
}
