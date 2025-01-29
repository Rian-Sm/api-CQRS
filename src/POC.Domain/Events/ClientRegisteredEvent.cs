using NetDevPack.Messaging;


namespace POC.Domain.Events
{
    public class ClientRegisteredEvent : Event
    {
        public ClientRegisteredEvent(Guid id, string email, string password, string accessToken)
        {
            Id = id;
            Email = email;
            Password = password;
            AccessToken = accessToken;
        }
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string AccessToken { get; private set; }
    }
}

