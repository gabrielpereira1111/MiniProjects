using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Alugueis")]
    public class Alugueis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAluguel { get; set; }

        public int IdVeiculo { get; set; }

        [Required(ErrorMessage = "Preenchimento do veículo alugado obrigatório!")]
        [ForeignKey("IdVeiculo")]
        public Veiculos Veiculo { get; set; } = null!;
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Preenchimento do cliente que alugou obrigatório!")]
        [ForeignKey("IdCliente")]
        public Clientes Cliente { get; set; } = null!;
    }
}
