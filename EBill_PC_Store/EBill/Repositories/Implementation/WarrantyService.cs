using EBill.Models.Domain;
using EBill.Repositories.Abstract;

namespace EBill.Repositories.Implementation
{
    public class WarrantyService : IWarrantyService
    {
        private readonly DatabaseContext context;
        public WarrantyService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Warranty model)
        {
            try
            {
                context.Warranty.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
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
                context.Warranty.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Warranty FindById(int id)
        {
            if(context!=null)
                return context.Warranty.Find(id);
            return null;
        }

        public IEnumerable<Warranty> GetAll()
        {
            if(context != null)
                return context.Warranty.ToList();

            return Enumerable.Empty<Warranty>();
        }

        public bool Update(Warranty model)
        {
            try
            {
                context.Warranty.Update(model);
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
