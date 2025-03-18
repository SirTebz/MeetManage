using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace MeetManage.Models
{
    public class Users : IdentityUser   
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

      
    }
}
