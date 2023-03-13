using RegisterPeople.Application.Dtos.Address;
using System;
using System.Collections.Generic;

namespace RegisterPeople.Application.Dtos.Person
{
    public class PersonDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool? IsAtivo { get; set; }

        public List<AddressDto> Address { get; set; }
    }
}
