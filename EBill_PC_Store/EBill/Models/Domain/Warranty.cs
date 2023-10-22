using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace EBill.Models.Domain
{
    [Authorize]
    public class Warranty
    {
        public int Id { get; set; }
        [Required]
        public string WarrantyName { get; set; }
    }
}
