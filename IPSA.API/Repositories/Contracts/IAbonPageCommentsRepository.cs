using IPSA.Models;

namespace IPSA.API.Repositories.Contracts
{
    public interface IAbonPageCommentsRepository
    {
        List<AbonPageComment> GetAbonentPageComments(int abonId);
        AbonPageComment GetSingleAbonPageComment(int commentId);
        Task AddNewAbonentPageComment(AbonPageComment comment);
        Task UpdateAbonentPageComment(AbonPageComment comment);
        Task DeleteAbonentPageComment(int commentId);
    }
}
