using System.ComponentModel.DataAnnotations;

namespace LocaCraft.Application.Dtos.RealEstates
{
    public sealed class CreateRealEstateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;


        public int PostalCode { get; set; }
    }
}
