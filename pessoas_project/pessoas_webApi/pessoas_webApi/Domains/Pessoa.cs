using System;
using System.Collections.Generic;

namespace pessoas_webApi.Domains
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Emails = new HashSet<Email>();
            Telefones = new HashSet<Telefone>();
        }

        public int IdPessoa { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;

        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
