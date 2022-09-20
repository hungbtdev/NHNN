namespace Vinorsoft.Core.Domain.Comands
{
    public class DeleteComand<T> : CUDComand<T> where T : class
    {
        public DeleteComand(T data) : base(data)
        {
        }
    }
}
