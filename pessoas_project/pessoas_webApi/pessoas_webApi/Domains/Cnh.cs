using System;
using System.Collections.Generic;

namespace pessoas_webApi.Domains
{
    public partial class Cnh
    {
        public int IdCnh { get; set; }
        public string? Descricao { get; set; }
        public int? IdPessoa { get; set; }

        public virtual Pessoa? IdPessoaNavigation { get; set; }
    }
}
