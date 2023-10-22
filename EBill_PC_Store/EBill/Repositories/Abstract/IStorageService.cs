using EBill.Models.Domain;

namespace EBill.Repositories.Abstract
{
    public interface IStorageService
    {
        bool Add(Storage model);
        bool Update(Storage model);
        bool Delete(int id);
        Storage FindById(int id);
        IEnumerable<Storage> GetAll();
    }
}
