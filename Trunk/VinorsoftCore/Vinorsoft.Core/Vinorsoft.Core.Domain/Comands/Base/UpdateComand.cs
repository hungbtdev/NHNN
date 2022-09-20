namespace Vinorsoft.Core.Domain.Comands
{
    public class UpdateComand<T> : CUDComand<T> where T : class
    {
        public UpdateComand(T data) : base(data)
        {
        }
    }
}
