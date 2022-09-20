using System;

namespace Vinorsoft.Core.Domain.Comands
{
    public class CUDComand<T> : CommandBase<T> where T : class
    {
        public CUDComand(T data)
        {
            Data = data ?? throw new ArgumentNullException();
        }

        public T Data { set; get; }
    }
}
