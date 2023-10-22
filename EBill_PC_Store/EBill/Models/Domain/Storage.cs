using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace EBill.Models.Domain
{
    [Authorize]
    public class Storage
    {
        public int Id { get; set; }
        [Required]
        public string StorageName { get; set; }
    }
}
