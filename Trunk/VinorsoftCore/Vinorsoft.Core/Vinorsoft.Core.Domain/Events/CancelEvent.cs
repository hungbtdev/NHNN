using MediatR;
using System;

namespace Vinorsoft.Core.Domain.Events
{
    public class CancelEvent<T> : CUDEvent<T> where T : class
    {
        public CancelEvent(T data) : base(data)
        {
        }
    }
}
