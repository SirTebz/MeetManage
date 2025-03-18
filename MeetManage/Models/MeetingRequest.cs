using System.ComponentModel.DataAnnotations;

namespace MeetManage.Models
{
    public class MeetingRequest
    {
        public int Id { get; set; }

        [Display(Name = "Date Received")]
        public DateTime DateReceived { get; set; }
        public string From { get; set; }

        [Required]
        public string Item { get; set; }

        [Display(Name = "Meeting Date")]
        public DateTime? MeetingDate { get; set; }

        [Display(Name = "Meeting Place")]
        [Required]
        public string MeetingPlace { get; set; }

        [Display(Name = "Meeting Time")]
        [Required]
        public DateTime MeetingTime { get; set; }

        [Required]
        public string Comments { get; set; }

        [Display(Name = "Days Since Received")]
        public int DaysSinceReceived { get; set; }


        public string? Decision { get; set; }


        public string? Action { get; set; }

        public string? UserId { get; set; }
        public Users User { get; set; }
    }
}
