using Core.Messages;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T _event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
