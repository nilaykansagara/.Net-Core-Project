using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace EBill.Models.Domain
{
    [Authorize]
    public class Bill
    {
        public int Id { get; set; }
        [Required]
        public string customerName { get; set; }

        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        public int WarrantyId { get; set; }
        [Required]
        public int StorageId { get; set; }
        [Required]
        public int ModelId { get; set; }

        [NotMapped]
        public string ? WarrantyName { get; set; }
        [NotMapped]
        public string ? StorageName { get; set; }
        [NotMapped]
        public string ? ModelName { get; set; }

        [NotMapped]
        public List<SelectListItem> ? WarrantyList { get; set; }
        [NotMapped]
        public List<SelectListItem>? StorageList { get; set; }
        [NotMapped]
        public List<SelectListItem> ? ModelList { get; set; }

        public DateTime Date { get; set; }
        public int Price { get; set; }

    }
}
