using Microsoft.AspNetCore.SignalR;

namespace MeetManage.Hubs
{
    public class MeetingRequstHub : Hub
    {
        // Method to send notifications to a specific user (in this case, John)
        public async Task SendMeetingRequestNotification(string userId)
        {
            await Clients.User(userId).SendAsync("SendMeetingRequestNotification");
        }

        // Method to send the Decision and Action updates to the user who created the request (Nick)
        public async Task SendDecisionUpdate(string userId, string decision, string action)
        {
            await Clients.User(userId).SendAsync("ReceiveDecisionUpdate", decision, action);
        }
    }
}
