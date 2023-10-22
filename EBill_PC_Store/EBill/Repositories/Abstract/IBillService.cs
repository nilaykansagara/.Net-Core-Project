using EBill.Models.Domain;

namespace EBill.Repositories.Abstract
{
    public interface IBillService
    {
        bool Add(Bill model);
        bool Update(Bill model);
        bool Delete(int id);
        Bill FindById(int id);
        IEnumerable<Bill> GetAll();
    }
}
