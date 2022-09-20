using MediatR;
using System;

namespace Vinorsoft.Core.Domain.Events
{
    public abstract class CUDEvent<T> : Event, INotification where T : class
    {
        public T Data { get; }

        public CUDEvent(T data)
        {
            Data = data ?? throw new ArgumentException();
        }
    }
}
