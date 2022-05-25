using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTiposUsuario { get; set; }

        [Required(ErrorMessage = "Nome do tipo de usuário obrigatório")]
        [Column(TypeName = "Varchar(200)")]
        public string Nome { get; set; } = null!;
        public List<Usuarios> Usuarios { get; set; } = null!;

    }
}
