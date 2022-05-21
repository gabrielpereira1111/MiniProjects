using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmes_webApi.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "Informe o seu e-mail!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a sua senha!")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Senha com no mínimo 6 e no máximo 100 caracteres")]
        public string Senha { get; set; }
        public Boolean Permissao { get; set; }
    }
}
