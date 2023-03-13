namespace RegisterPeople.Application.Dtos.Address
{
    public class AddressDto
    {
        public int? Id { get; set; }
        public int IdPerson { get; set; }
        public string Logadouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
    }
}
