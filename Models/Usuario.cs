using System.ComponentModel.DataAnnotations;

namespace Stefanini_Project01.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Ruc { get; set; }
        public int edad {  get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaRegistro { get; set; }
    }
}
