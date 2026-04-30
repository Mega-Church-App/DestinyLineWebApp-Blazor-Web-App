using static DestinyLineWebApp.Client.Pages.Attandance;
using DestinyLineWebApp.Client.Models;

namespace DestinyLineWebApp.Client.Services
{
    public interface IAttendeeService
    {
        Task<List<Attendee>> GetAttendanceList();
        Task SaveAttendance(Attendee attendee);

    }
}
