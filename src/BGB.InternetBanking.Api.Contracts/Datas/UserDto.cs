using BGB.InternetBanking.Api.Contracts.Enums;

namespace BGB.InternetBanking.Api.Contracts.Datas
{
    public class UserDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public CredentialDto Credential { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ProfileEnumDto Profile { get; set; }
        public bool Active { get; set; }
    }
}