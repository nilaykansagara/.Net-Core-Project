using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace EBill.Models.Domain
{
    [Authorize]
    public class pcModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
