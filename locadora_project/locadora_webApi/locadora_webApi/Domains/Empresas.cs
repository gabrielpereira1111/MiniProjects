using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Empresas")]
    public class Empresas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEmpresa { get; set; }

        [Column(TypeName = "Varchar(150)")]
        [Required(ErrorMessage = "Preenchimento do nome da empresa obrigatório!")]
        public string? Nome { get; set; }
        public List<Veiculos>? Veiculos { get; set; }
    }
}
