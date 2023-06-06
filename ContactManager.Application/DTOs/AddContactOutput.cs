using ContactManager.Application.Contracts;

namespace ContactManager.Application.DTOs
{
    public class AddContactOutput : ResponseMessage
    {
        public List<string> Errors { get; private set; }
        public AddContactOutput(bool success, List<string> errors, string? message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
