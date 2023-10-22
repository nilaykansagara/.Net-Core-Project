using EBill.Models.Domain;
using EBill.Repositories.Abstract;

namespace EBill.Repositories.Implementation
{
    public class BillService : IBillService
    {
        private readonly DatabaseContext context;
        public BillService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Bill model)
        {
            try
            {
                context.Bill.Add(model);
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
                context.Bill.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Bill FindById(int id)
        {
            return context.Bill.Find(id);
        }

        public IEnumerable<Bill> GetAll()
        {
            var data = (from bill in context.Bill
                        join warranty in context.Warranty
                        on bill.WarrantyId equals warranty.Id
                        join storage in context.Storage on bill.StorageId equals storage.Id
                        join model in context.pcModel on bill.ModelId equals model.Id
                        select new Bill
                        {
                            Id = bill.Id,
                            WarrantyId = bill.WarrantyId,
                            ModelId = bill.ModelId,
                            Price = bill.Price,
                            StorageId = bill.StorageId,
                            customerName = bill.customerName,
                            EmailId = bill.EmailId,
                            ModelName = model.Name,
                            WarrantyName = warranty.WarrantyName,
                            StorageName = storage.StorageName,
                            Address = bill.Address,
                            Date = bill.Date,
                            Phone = bill.Phone
                        }
                        ).ToList();
            return data;
        }

        public bool Update(Bill model)
        {
            try
            {
                context.Bill.Update(model);
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
