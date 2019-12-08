﻿using Microsoft.Azure.Cosmos;

namespace CosmosDBStudio.Services
{
    public interface IRequestOptionsBuilder<TBuilder, TOptions>
        where TBuilder : IRequestOptionsBuilder<TBuilder, TOptions>
        where TOptions : RequestOptions
    {
        TOptions Build();
    }

    public interface IQueryRequestOptionsBuilder : IRequestOptionsBuilder<IQueryRequestOptionsBuilder, QueryRequestOptions>
    {
        IQueryRequestOptionsBuilder WithPartitionKey(object? partitionKey);
        IQueryRequestOptionsBuilder WithMaxItemCount(int? maxItemCount);
    }

    public interface IItemRequestOptionsBuilder : IRequestOptionsBuilder<IItemRequestOptionsBuilder, ItemRequestOptions>
    {
        IItemRequestOptionsBuilder IfMatch(string? eTag);
    }
}
