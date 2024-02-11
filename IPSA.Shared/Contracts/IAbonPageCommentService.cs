using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;

namespace IPSA.Shared.Contracts
{
    public interface IAbonPageCommentService
    {
        Task<List<AbonPageCommentDto>> GetAbonentPageComments(int abonId);
        Task<ServiceResponse> AddNewAbonentPageComment(AbonPageCommentDto commentDto);
        Task<ServiceResponse> UpdateAbonPageComment(AbonPageCommentDto commentDto);
        Task<ServiceResponse> DeleteAbonPageComment(int commentId);
        
    }
}
