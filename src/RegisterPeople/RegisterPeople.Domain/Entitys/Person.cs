using System;
using System.Collections.Generic;

namespace RegisterPeople.Domain.Entitys
{
    public class Person : Base
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CPF { get; set; }
        public bool IsAtivo { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
