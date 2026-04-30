using DestinyLineWebApp.Client.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace DestinyLineWebApp.Client.Services
{
    public class AttendeeService : IAttendeeService
    {
        private readonly FirebaseClient _firebaseClient;

        public AttendeeService()
        {
            _firebaseClient = new FirebaseClient("https://lead-tracker-app-10ad9-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        public async Task SaveAttendance(Attendee attendee)
        {
            await _firebaseClient
                .Child("attendees")
                .PostAsync(attendee);
        }

        public async Task<List<Attendee>> GetAttendanceList()
        {
            var data = await _firebaseClient
                .Child("attendees")
                .OnceAsync<Attendee>();

            return data.Select(item => new Attendee
            {
                FullName = item.Object.FullName,
                Phone = item.Object.Phone,
                Location = item.Object.Location,
                Timestamp = item.Object.Timestamp,
                IsFirstTimer = item.Object.IsFirstTimer
            }).ToList();
        }
    }
}
