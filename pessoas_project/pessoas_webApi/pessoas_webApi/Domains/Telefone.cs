using System;
using System.Collections.Generic;

namespace pessoas_webApi.Domains
{
    public partial class Telefone
    {
        public int IdTelefone { get; set; }
        public string? NumTelefone { get; set; }
        public int? IdPessoa { get; set; }

        public virtual Pessoa? IdPessoaNavigation { get; set; }
    }
}
