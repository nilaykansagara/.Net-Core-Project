using EBill.Models.Domain;

namespace EBill.Repositories.Abstract
{
    public interface IWarrantyService
    {
        bool Add(Warranty model);
        bool Update(Warranty model);
        bool Delete(int id);
        Warranty FindById(int id);
        IEnumerable<Warranty> GetAll();
    }
}
