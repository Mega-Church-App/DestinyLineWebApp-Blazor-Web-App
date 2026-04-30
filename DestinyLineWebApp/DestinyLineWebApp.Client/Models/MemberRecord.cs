using System;
using System.Collections.Generic;
using System.Text;

namespace DestinyLineWebApp.Client.Models
{
    public class MemberRecord
    {
        public record PersonalDetails
        {
            public DateTime DateJoined { get; set; } = DateTime.UtcNow;
            public string FirstName { get; set; } = string.Empty;
            public string MiddleName {  get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string Gender { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; }
            public string Nationality { get; set; } = string.Empty;
            public string MaritalStatus { get; set; } = string.Empty;
            public int? NoOfChildren { get; set; }
            public string? Occupation {  get; set; }
            public string StudentStatus { get; set;  } = string.Empty;
            public string? SchoolStatus { get; set;  }
            public string HouseNumber { get; set; } = string.Empty;
        }

        public record ContactInfo {
            public string Phone { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string PostalAddress { get; set; } = string.Empty;
            public string Location {  get; set; } = string.Empty;
            public string StreetName { get; set; } = string.Empty;
        }

        public record EmergencyContactInfo {
            public string EmergencyContactName { get; set; } = String.Empty;
            public string EmergencyContactRelationship { get; set; } = String.Empty; 
            public string EmergencyContactPhone {  get; set; } = String.Empty;
        }


        public record ChurchBackground{
            public string PreviousChurchName { get; set; } = string.Empty;
            public string PreviousChurchLocation { get; set; } = string.Empty;
            public string PreviousChurchHeadPastor { get; set; } = string.Empty;
            public string? PreviousRole {  get; set; }
            public string? ReasonForLeaving { get; set; }
        }

        public record BaptismInfo
        {
            public string IsBaptized { get; set; } = string.Empty;
            public string Church { get; set; } = string.Empty;
            public string Year { get; set; } = string.Empty;
            public string Baptize { get; set; } = string.Empty;
        }

        public record DepartmentInfo
        {
            public string IsDepartmentMember { get; set; } = string.Empty;
            public string DepartmentName { get; set; } = string.Empty;
            public string InterestedDepartments { get; set; } = string.Empty;
        }
    }
}
