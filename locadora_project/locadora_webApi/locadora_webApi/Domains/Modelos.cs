using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Modelos")]
    public class Modelos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idModelo { get; set; }

        [Required(ErrorMessage = "O nome do modelo deve ser preenchido")]
        [Column(TypeName = "Varchar(300)")]
        public string? Descricao { get; set; }

        public int idMarca { get; set; }

        [ForeignKey("idMarca")]
        public Marcas? Marca { get; set; }

        public List<Veiculos>? Veiculos { get; set; }
    }
}
