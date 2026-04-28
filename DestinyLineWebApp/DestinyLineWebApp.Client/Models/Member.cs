using System.ComponentModel.DataAnnotations;
using static DestinyLineWebApp.Client.Models.MemberRecord;

namespace DestinyLineWebApp.Client.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public PersonalDetails? personalDetails { get; set; }
        [Required]
        public ContactInfo? contactInfo { get; set; }

        public ChurchBackground? churchBackground { get; set; }

        [Required]
        public EmergencyContactInfo? emergencyContactInfo { get; set; }
        [Required]
        public BaptismInfo? baptismInfo { get; set; }

        public DepartmentInfo? departmentInfo { get; set; }
    }
}
