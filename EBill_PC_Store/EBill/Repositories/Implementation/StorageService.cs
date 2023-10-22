using EBill.Models.Domain;
using EBill.Repositories.Abstract;

namespace EBill.Repositories.Implementation
{
    public class StorageService : IStorageService
    {
        private readonly DatabaseContext context;
        public StorageService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Storage model)
        {
            try
            {
                context.Storage.Add(model);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Storage.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Storage FindById(int id)
        {
            return context.Storage.Find(id);
        }

        public IEnumerable<Storage> GetAll()
        {
            return context.Storage.ToList();
        }

        public bool Update(Storage model)
        {
            try
            {
                context.Storage.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
