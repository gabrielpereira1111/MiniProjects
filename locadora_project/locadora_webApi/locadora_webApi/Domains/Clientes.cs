using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Clientes")]
    public class Clientes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCliente { get; set; }

        [Column(TypeName = "Varchar(200)")]
        [Required(ErrorMessage = "O nome do cliente deve ser preenchido!")]
        public string? Nome { get; set; }

        public List<Alugueis> Alugueis { get; set; } = null!;
    }
}
