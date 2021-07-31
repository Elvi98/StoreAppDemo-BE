using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Web.Models
{
    public class CreateCategoryModel
    {
        [Required(ErrorMessage = "Todo producto debe tener un nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombre del producto debe tener entre 3 a 50 caracteres")]
        public string Name { get; set; }
        [StringLength(250, ErrorMessage = "La descripción debe tener un máximo de 250 caracteres")]
        public string Description { get; set; }
    }
}
