using Core.Messages;
using FluentValidation;
using System;

namespace Clients.API.Application.Commands
{
    public class RegisterClientCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public RegisterClientCommand(Guid id, string name, string email, string cpf)
        {
            AggregateId = id;
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterClientValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegisterClientValidation : AbstractValidator<RegisterClientCommand>
        {
            public RegisterClientValidation()
            {
                RuleFor(c => c.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Client Id not valid");

                RuleFor(c => c.Name)
                    .NotEmpty()
                    .WithMessage("Client Name is required");

                RuleFor(c => c.Cpf)
                    .Must(MustHaveValidCpf)
                    .WithMessage("Invalid CPF");

                RuleFor(c => c.Email)
                    .Must(MustHaveValidEmail)
                    .WithMessage("Invalid E-mail");
            }

            protected static bool MustHaveValidCpf(string cpf)
            {
                return Core.DomainObjects.Cpf.Validate(cpf);
            }

            protected static bool MustHaveValidEmail(string email)
            {
                return Core.DomainObjects.Email.Validate(email);
            }
        }
    }
}
