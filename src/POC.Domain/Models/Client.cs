using NetDevPack.Domain;

namespace POC.Domain.Models
{
    public class Client : Entity, IAggregateRoot
    {
        private Guid guid;
        private object value;

        public Client(Guid id, string email, string password, string accessToken){
            Id = id;
            Email = email;
            Password = password;
            AccessToken = accessToken;
        }
        public Guid Id { get; set; }
        public  string Email { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
    }
}