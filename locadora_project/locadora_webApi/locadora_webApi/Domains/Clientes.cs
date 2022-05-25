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
        
        [Required(ErrorMessage = "Preenchimento do CPF obrigatório!")]
        [Column(TypeName = "Char(11)")]
        public string Cpf { get; set; } = null!;

        public List<Alugueis> Alugueis { get; set; } = null!;

        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Usuario do cliente obrigatório!")]
        [ForeignKey("idUsuario")]
        public Usuarios Usuario { get; set; } = null!;
    }
}
