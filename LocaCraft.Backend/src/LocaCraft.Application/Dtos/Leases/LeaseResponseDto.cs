using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LocaCraft.Application.Dtos.Leases
{
    public sealed class LeaseResponseDto
    {
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
