using System.ComponentModel.DataAnnotations;

namespace CleanArchProject.WebUI.Models
{
    public class TesteClasse
    {
        [Key]
        public int Id{ get; set; }
        public string Nome { get; set; }
    }
}
