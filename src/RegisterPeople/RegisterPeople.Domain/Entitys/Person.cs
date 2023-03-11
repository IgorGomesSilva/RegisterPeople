using System;

namespace RegisterPeople.Domain.Entitys
{
    public class Person
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
