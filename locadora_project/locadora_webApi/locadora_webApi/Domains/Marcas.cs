using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Marcas")]
    public class Marcas
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idMarca { get; set; }

        [Column(TypeName = "Varchar(200)")]
        [Required(ErrorMessage = "Obrigatório o preenchimento do nome da marca!")]
        public string? Nome { get; set; }

        public List<Modelos>? Modelos { get; set; }
    }
}
