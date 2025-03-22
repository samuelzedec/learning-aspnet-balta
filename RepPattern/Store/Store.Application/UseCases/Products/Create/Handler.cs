using Store.Domain.Abstractions;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using MediatR;

namespace Store.Application.UseCases.Products.Create;

public class Handler(IProductRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
        };
        
        var result = await repository.CreateAsync(product, cancellationToken);
        await unitOfWork.CommitAsync();
        
        return Result.Success(new Response(result.Id, result.Title));
    }
}