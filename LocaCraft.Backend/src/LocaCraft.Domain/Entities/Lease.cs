using LocaCraft.API.Entities;
using LocaCraft.Domain.Bases;
using System.ComponentModel.DataAnnotations;

namespace LocaCraft.Domain.Entities
{
    public class Lease : BaseEntity
    {
        [Required]
        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public decimal MonthlyRent { get; set; }
        [Required]
        public decimal MonthlyCharges { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
