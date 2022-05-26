using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Preenchimento do e-mail obrigatório!")]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "Varchar(200)")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Preenchimento de senha obrigatório!")]
        [DataType(DataType.Password)]
        [Column(TypeName = "Varchar(200)")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "A senha precisa ter no mínimo 10 e no máximo 30 caracteres")]
        public string Senha { get; set; } = null!;

        public int IdTiposUsuario { get; set; }

        [ForeignKey("IdTiposUsuario")]
        public TiposUsuario TiposUsuario { get; set; } = null!;

        public Clientes Cliente { get; set; } = null!;
    }
}
