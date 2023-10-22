using EBill.Models.Domain;
using EBill.Repositories.Abstract;

namespace EBill.Repositories.Implementation
{
    public class ModelService : IModelService
    {
        private readonly DatabaseContext context;
        public ModelService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(pcModel model)
        {
            try
            {
                context.pcModel.Add(model);
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
                context.pcModel.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public pcModel FindById(int id)
        {
            if(context != null)
            return context.pcModel.Find(id);

            return null;
        }

        public IEnumerable<pcModel> GetAll()
        {
            if(context != null && context.pcModel != null)
            return context.pcModel.ToList();

            return Enumerable.Empty<pcModel>();
        }

        public bool Update(pcModel model)
        {
            try
            {
                context.pcModel.Update(model);
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
