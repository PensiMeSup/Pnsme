namespace Pnsme.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ValueObjects.DateOfBirth DateOfBirth { get; private set; }

        public User(string email, string firstName, string lastName, ValueObjects.DateOfBirth dateOfBirth)
        {
            Id = Guid.NewGuid();
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}