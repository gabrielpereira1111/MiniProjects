using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Veiculos")]
    public class Veiculos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idVeiculo { get; set; }

        public int idEmpresa { get; set; }

        [Required(ErrorMessage = "Preenchimento da empresa que possui o carro obrigatório!")]
        [ForeignKey("idEmpresa")]
        public Empresas? Empresa { get; set; }
        public int idModelo { get; set; }

        [Required(ErrorMessage = "Preenchimento do modelo do carro obrigatório!")]
        [ForeignKey("idModelo")]
        public Modelos? Modelo { get; set; }

        [Required(ErrorMessage = "Preenchimento da placa do veículo obrigatória!")]
        [Column(TypeName = "Char(7)")]
        public string? Placa { get; set; }

        public Alugueis Aluguel { get; set; } = null!;
    }
}
