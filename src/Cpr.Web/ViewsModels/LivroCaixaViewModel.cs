using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Cpr.Web.ViewsModels
{
    public class LivroCaixaViewModel
    {
        public int Id { get; set; }  
        [Required]     
        public bool Tipo {get; set;}
        public int CategoriaId {get; set;}
        public string CategoriaName { get; set; }
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required] 
        public DateTime Data { get; set; }
        [Required] 
        public string Descricao {get; set;}
        [Required] 
        [Column(TypeName = "decimal(8,2)")]
        public decimal Valor {get; set;}
    }
}