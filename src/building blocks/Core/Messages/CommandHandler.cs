using Core.Data;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        public CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> PersistData(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork.Commit()) AddError("An error occured while saving");

            return ValidationResult;
        }
    }
}
