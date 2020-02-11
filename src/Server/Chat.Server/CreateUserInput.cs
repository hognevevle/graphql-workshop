namespace Chat.Server
{
    public class CreateUserInput
    {
        public CreateUserInput(
            string name,
            string email,
            string password,
            byte[] image,
            string? clientMutationId)
        {
            Name = name;
            Email = email;
            Password = password;
            Image = image;
            ClientMutationId = clientMutationId;
        }

        public string Name { get; }

        public string Email { get; }

        public string Password { get; }

        public byte[] Image { get; }

        public string? ClientMutationId { get; }
    }
}
