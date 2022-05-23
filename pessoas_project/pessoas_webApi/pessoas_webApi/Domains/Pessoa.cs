using System;
using System.Collections.Generic;

namespace pessoas_webApi.Domains
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Cnhs = new HashSet<Cnh>();
            Emails = new HashSet<Email>();
            Telefones = new HashSet<Telefone>();
        }

        public int IdPessoa { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Cnh> Cnhs { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
