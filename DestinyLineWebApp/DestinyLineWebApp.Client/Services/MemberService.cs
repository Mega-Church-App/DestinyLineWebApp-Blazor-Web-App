using DestinyLineWebApp.Client.Models;
using DestinyLineWebApp.Client.Pages;
using Firebase.Database;
using Firebase.Database.Query;
using static DestinyLineWebApp.Client.Models.MemberRecord;
using static DestinyLineWebApp.Client.Pages.Attandance;

namespace DestinyLineWebApp.Client.Services
{
    public class MemberService : IMemberService
    {
        private readonly FirebaseClient _firebaseClient;

        public MemberService()
        {
            _firebaseClient = new FirebaseClient("https://lead-tracker-app-10ad9-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<int> AddMember(Member newMember)
        {
            try
            {
                await _firebaseClient.Child("Members").PostAsync(newMember);

                return 1;
            }
            catch (Exception ex)
            {
                // If the internet is down or Firebase blocks it, it returns 0 (failure)
                Console.WriteLine($"Firebase Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<List<Member>> GetMembersList()
        {
            // Downloads the whole Members folder and turns it into a List your app can read
            var members = await _firebaseClient
                .Child("Members")
                .OnceAsync<Member>();

            return members.Select(x => x.Object).ToList();
        }

        public async Task<int> UpdateMembersList(Member member)
        {
            try
            {
                // STEP 1: Find the person's exact Firebase Key
                var personToUpdate = (await _firebaseClient
                    .Child("Members")
                    .OnceAsync<Member>())
                    .FirstOrDefault(a => a.Object.Id == member.Id);

                if (personToUpdate == null) return 0; // Not found

                // STEP 2: Update ONLY that specific person's folder, not the whole database!
                await _firebaseClient
                    .Child("Members")
                    .Child(personToUpdate.Key)
                    .PutAsync(member);

                return 1;
            }
            catch (Exception) { return 0; }
        }

        public async Task<int> DeleteMembers(Member member)
        {
            try
            {
                // STEP 1: Find the person's exact Firebase Key
                var personToDelete = (await _firebaseClient
                    .Child("Members")
                    .OnceAsync<Member>())
                    .FirstOrDefault(a => a.Object.Id == member.Id);

                if (personToDelete == null) return 0;

                // STEP 2: Delete ONLY that specific person
                await _firebaseClient
                    .Child("Members")
                    .Child(personToDelete.Key)
                    .DeleteAsync();

                return 1;
            }
            catch (Exception) { return 0; }
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


        public async Task<bool> CheckIfMemberExists(string phone)
        {
            // Searches the "Members" node for any member with a matching phone number
            var members = await _firebaseClient
                .Child("Members")
                .OnceAsync<Member>();

            return members.Any(x => x.Object.contactInfo.Phone == phone);
        }

        public async Task MarkAsMember(string phone)
        {
            await _firebaseClient
                .Child("members")
                .Child(phone)
                .PutAsync(new { Status = "RegisteredViaRollcall", Date = DateTime.Now });
        }
    }
}