using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace locadora_webApi.Domains
{
    [Table("Alugueis")]
    public class Alugueis
    {
        public Alugueis()
        {
            DateTime data1 = DataInicio;
            DateTime data2 = DataFim;

            if (data2 < data1)
            {
                DataFim = data1;
                DataInicio = data2;
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAluguel { get; set; }

        public int IdVeiculo { get; set; }

        [ForeignKey("IdVeiculo")]
        public Veiculos? Veiculo { get; set; }
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Preenchimento do cliente que alugou obrigatório!")]
        [ForeignKey("IdCliente")]
        public Clientes Cliente { get; set; } = null!;

        [Required(ErrorMessage = "A data do início do aluguél é obrigatória!")]
        [Column(TypeName = "Date")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data do fim do aluguél é obrigatória!")]
        [Column(TypeName = "Date")]
        public DateTime DataFim { get; set; }

    }
}
