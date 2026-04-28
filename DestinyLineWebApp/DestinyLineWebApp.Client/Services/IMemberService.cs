using DestinyLineWebApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static DestinyLineWebApp.Client.Pages.Attandance;

namespace DestinyLineWebApp.Client.Services
{
    public interface IMemberService
    {
        //Attendees
        Task SaveAttendance(Attendee attendee);
        Task<List<Attendee>> GetAttendanceList();

        //Attendees Duplicate Verification
        Task<bool> CheckIfMemberExists(string phone);
        Task MarkAsMember(string phone);

        //Members
        Task<List<Member>> GetMembersList();
        Task<int> AddMember(Member member);
        Task<int> DeleteMembers(Member member);
        Task<int> UpdateMembersList(Member member);
    }
}
