using MediatR;
using Store.Domain.Abstractions;
using Store.Domain.Repositories;
using Store.Domain.Specifications;

namespace Store.Application.UseCases.Products.GetById;

public sealed class Handler(IProductRepository repository) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var spec = new GetProductByIdSpecification(request.Id);
        var product = await repository.GetByIdAsync(spec, cancellationToken);
        return product is null
            ? Result.Failure<Response>(new Error("404", "Product Not Found"))
            : Result.Success(new Response(product.Id, product.Title));
    }
}