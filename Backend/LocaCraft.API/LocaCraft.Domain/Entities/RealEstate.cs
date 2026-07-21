using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace LocaCraft.API.Entities
{
    public class RealEstate
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public int PostalCode { get; set; }
    }
}
