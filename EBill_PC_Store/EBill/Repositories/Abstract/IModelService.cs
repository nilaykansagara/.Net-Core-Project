using EBill.Models.Domain;

namespace EBill.Repositories.Abstract
{
    public interface IModelService
    {
        bool Add(pcModel model);
        bool Update(pcModel model);
        bool Delete(int id);
        pcModel FindById(int id);
        IEnumerable<pcModel> GetAll();
    }
}
