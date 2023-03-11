namespace RegisterPeople.Application.Dtos
{
    public class PersonDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public bool? IsAtivo { get; set; }
    }
}
