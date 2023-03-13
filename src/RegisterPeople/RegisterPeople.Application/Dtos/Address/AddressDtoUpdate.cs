using System.ComponentModel.DataAnnotations;

namespace RegisterPeople.Application.Dtos.Address
{
    public class AddressDtoUpdate
    {
        [Required(ErrorMessage = "ID é um campo obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "IdPerson é um campo obrigatório.")]
        public int IdPerson { get; set; }

        [Required(ErrorMessage = "Logadouro é um campo obrigatório.")]
        [StringLength(150, ErrorMessage = "Logadouro precisa ser menor que 150 carácteres.")]
        public string Logadouro { get; set; }

        [Required(ErrorMessage = "Bairro é um campo obrigatório.")]
        [StringLength(100, ErrorMessage = "Bairro precisa ser menor que 100 carácteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Numero é um campo obrigatório.")]
        [StringLength(15, ErrorMessage = "Numero precisa ser menor que 15 carácteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Complemento é um campo obrigatório.")]
        [StringLength(255, ErrorMessage = "Complemento precisa ser menor que 255 carácteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Cidade é um campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Cidade precisa ser menor que 50 carácteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado é um campo obrigatório.")]
        [StringLength(30, ErrorMessage = "Estado precisa ser menor que 30 carácteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Pais é um campo obrigatório.")]
        [StringLength(30, ErrorMessage = "Pais precisa ser menor que 30 carácteres.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "CEP é um campo obrigatório.")]
        [StringLength(8, ErrorMessage = "CEP precisa ser menor que 8 carácteres.")]
        public string CEP { get; set; }
    }
}
