using CleanStore.Application.SharedContext.Results;
using MediatR;

namespace CleanStore.Application.SharedContext.UseCases.Abstractions;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : ICommandResponse
{
}

/*
 * Use in T quando:
   
   ✅ Interface só recebe T (handlers, consumers, validators)
   ✅ Quer que handlers genéricos funcionem para tipos específicos
   ✅ Pattern Command/Event Handler
   
   Use out T quando:
   
   ✅ Interface só retorna T (factories, repositories de consulta)
   ✅ Quer que collections de tipos específicos funcionem como genéricas
   ✅ Pattern Factory/Repository
 */