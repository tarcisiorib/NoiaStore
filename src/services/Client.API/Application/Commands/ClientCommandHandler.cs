using Clients.API.Models;
using Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clients.API.Application.Commands
{
    public class ClientCommandHandler : CommandHandler,
        IRequestHandler<RegisterClientCommand, ValidationResult>
    {
        private readonly IClientRepository _clientRepository;

        public ClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(RegisterClientCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var client = new Client(message.Id, message.Name, message.Email, message.Cpf);

            var clientExists = await _clientRepository.GetByCpf(client.Cpf.Number);

            if (clientExists != null)
            {
                AddError("CPF already taken");
                return ValidationResult;
            }

            return await PersistData(_clientRepository.UnitOfWork);
        }
    }
}
