using System.ComponentModel.DataAnnotations;

namespace RegisterPeople.Application.Dtos.Person
{
    public class PersonDtoUpdate
    {
        [Required(ErrorMessage = "ID é um campo obrigatório.")]
        public int Id { get; set; }
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

        public bool? IsAtivo { get; set; }
    }
}
