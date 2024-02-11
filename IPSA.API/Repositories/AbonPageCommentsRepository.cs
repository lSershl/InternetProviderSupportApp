using IPSA.API.Data;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;

namespace IPSA.API.Repositories
{
    public class AbonPageCommentsRepository(AppDbContext appDbContext) : IAbonPageCommentsRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public List<AbonPageComment> GetAbonentPageComments(int abonId)
        {
            var abonPageComments = _appDbContext.AbonPageComments.Where(x => x.AbonentId == abonId).ToList();
            return abonPageComments;
        }

        public AbonPageComment GetSingleAbonPageComment(int commentId)
        {
            var comment = _appDbContext.AbonPageComments.Where(x => x.Id == commentId).FirstOrDefault();
            return comment!;
        }

        public Task AddNewAbonentPageComment(AbonPageComment comment)
        {
            _appDbContext.AbonPageComments.Add(comment);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAbonentPageComment(AbonPageComment comment)
        {
            _appDbContext.AbonPageComments.Update(comment);
            _appDbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteAbonentPageComment(int commentId)
        {
            var commentToDelete = _appDbContext.AbonPageComments.FirstOrDefault(p => p.Id == commentId);
            if (commentToDelete is not null)
            {
                _appDbContext.AbonPageComments.Remove(commentToDelete);
                _appDbContext.SaveChanges();
                return Task.CompletedTask;
            }
            else
            {
                throw new NullReferenceException("Платёж не существует");
            }
        }
    }
}
