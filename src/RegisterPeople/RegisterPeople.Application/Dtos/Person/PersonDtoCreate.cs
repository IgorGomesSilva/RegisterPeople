using System.ComponentModel.DataAnnotations;

namespace RegisterPeople.Application.Dtos.Person
{
    public class PersonDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Nome precisa ser menor que 50 carácteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é um campo obrigatório.")]
        [StringLength(100, ErrorMessage = "Sobrenome precisa ser menor que 100 carácteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        [StringLength(100, ErrorMessage = "Email precisa ser menor que 100 carácteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigatório.")]
        [StringLength(11, ErrorMessage = "CPF precisa ser menor que 11 carácteres.")]
        public string CPF { get; set; }
    }
}
