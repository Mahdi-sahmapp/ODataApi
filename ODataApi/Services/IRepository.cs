using ODataApi.Models;

namespace ODataApi.Services
{
    public interface IRepository<T>
    {       

        Task<T> Add(T Entity , CancellationToken cancellationToken);
        Task<T> Update(T Entity, int Id, CancellationToken cancellationToken);
        IQueryable<T> GetAll();

        Task<T?>GetById(int Id,CancellationToken cancellationToken);
        Task<bool> Delete(T Entity, CancellationToken cancellationToken);
    }
}
