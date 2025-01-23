using NetDevPack.Messaging;

namespace POC.Domain.Commands
{
    public abstract class ClientCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string AccessToken { get; protected set; }
    }
}