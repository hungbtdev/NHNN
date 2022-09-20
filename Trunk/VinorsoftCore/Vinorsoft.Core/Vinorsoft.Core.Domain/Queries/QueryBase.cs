﻿using MediatR;

namespace Vinorsoft.Core.Domain.Queries
{
    public abstract class QueryBase<TResult> : IRequest<TResult> where TResult : class
    {

    }
}
