using AutodocConnector.Application.Features.AutodocRestApi.GetStock.DTOs;
using AutodocConnector.Application.Interfaces.ForPersistence.Repositories;
using AutodocConnector.Domain.Products.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutodocConnector.Application.Features.AutodocRestApi.GetStock
{
    public class GetStockCommandHandler : IRequestHandler<GetStockRequest, GetStockResponse>
    {
        private readonly GetStockRequestValidator _validator;
        private readonly IGetStockRepository _repository;

        public GetStockCommandHandler(GetStockRequestValidator validator, IGetStockRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<GetStockResponse> Handle(GetStockRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _validator.Validate(request);
                Product? product = null;
                if (request.ProductId != null)
                {
                    product = await _repository.GetProductByArticleNumberAsync(request.ProductId);
                }
                else
                {
                    if (request.EAN != null)
                    {
                        product = await _repository.GetProductByEANAsync(request.EAN);
                    }
                }
                if (request.Country != null)
                {
                    product!.ActivePrice = await _repository.GetCountryPrice(product!.Id!, request.Country);
                }
                product!.Stocks = await _repository.GetStockAsync(product!.Id!);
                return new GetStockResponse
                {
                    Amount = product.Stocks,
                    Price = product!.ActivePrice!.Price,
                    ProductId = product!.Id,
                };
            }
            catch (Exception ex)
            {
                var response = new GetStockResponse();
                response.SetError(ex.Message);
                return response;
            }
        }
    }
}
