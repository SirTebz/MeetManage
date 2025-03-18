using System.ComponentModel.DataAnnotations;

namespace MeetManage.Models
{
    public class Invitation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Received")]
        public DateTime DateReceived { get; set; }

        [Required]
        [Display(Name = "From")]
        public string From { get; set; }

        [Required]
        [Display(Name = "Item")]
        public string Item { get; set; }

        [Required]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Event Place")]
        public string EventPlace { get; set; }

        [Required]
        [Display(Name = "Event Time")]
        public TimeSpan EventTime { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Decision")]
        public string Decision { get; set; }

        [Display(Name = "Days Before Apology")]
        public int? DaysBeforeApology { get; set; }

        [Display(Name = "Action")]
        public string Action { get; set; }
    }
}
