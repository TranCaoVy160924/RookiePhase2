using System.ComponentModel.DataAnnotations;
#nullable disable
namespace AssetManagement.Contracts.User.Request
{
    public class UpdateUserRequest
    {
        [Required(ErrorMessage = "Please select Date of Birth")]
        public DateTime Dob { get; set; }

        [Required]
        public string StaffCode { get; set; }

        [MaxLength(50)]
        public Domain.Enums.AppUser.UserGender Gender { get; set; }

        [Required]
        public DateTime JoinedDate { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
