﻿using JwtStore.Core.Contexts.AccountContext.UseCases.Create;
using MediatR;

namespace JwtStore.API.Extensions
{
    public static class AccountContextExtensions
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region Create

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IRepository,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Repository>();

            builder.Services.AddTransient<
                JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts.IService,
                JwtStore.Infra.Contexts.AccountContext.UseCases.Create.Service>();

            #endregion
        }
        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region Create
            app.MapPost("api/v1/users", async (Request request,
                IRequestHandler<Request,Response> handler) =>
                {
                    var result = await handler.Handle(request, new CancellationToken());

                    return result.IsSuccess
                        ? Results.Created($"api/v1/users/{result.Data?.Id}", result)
                        : Results.Json(result, statusCode: result.Status);
                });
            #endregion
        }
    }
}
