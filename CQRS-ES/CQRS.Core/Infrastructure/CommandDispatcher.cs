using CQRS.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Dictionary<Type, Func<BaseCommand, Task>> _handlers = new();

        public void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand
        {
            if (!_handlers.TryAdd(typeof(T), x => handler((T)x)))
            {
                throw new IndexOutOfRangeException("You cannot register the same command handler twice");
            }
        }

        public async Task SendAsync(BaseCommand command)
        {
            if(_handlers.TryGetValue(command.GetType(), out Func<BaseCommand, Task> handler))
            {
                await handler(command);
            } else
            {
                throw new ArgumentNullException(nameof(handler), "No command handler was registered");
            }
        }
    }
}
