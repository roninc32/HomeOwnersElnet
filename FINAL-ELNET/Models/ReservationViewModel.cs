using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FINAL_ELNET.Models
{
    public class ReservationViewModel : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a facility type")]
        [Display(Name = "Facility Type")]
        public required string FacilityType { get; set; }

        [Required(ErrorMessage = "Please select a reservation date")]
        [Display(Name = "Reservation Date")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Please select a start time")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "Please select an end time")]
        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Number of Guests")]
        [Range(1, 100, ErrorMessage = "Number of guests must be between 1 and 100")]
        public int NumberOfGuests { get; set; }

        [Display(Name = "Special Requests")]
        public string? SpecialRequests { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndTime <= StartTime)
            {
                yield return new ValidationResult(
                    "End time must be after start time",
                    new[] { nameof(EndTime) });
            }

            if (ReservationDate.Date < DateTime.Now.Date)
            {
                yield return new ValidationResult(
                    "Reservation date cannot be in the past",
                    new[] { nameof(ReservationDate) });
            }
        }
    }
}