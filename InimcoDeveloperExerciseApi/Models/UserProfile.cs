using System.Collections.Generic;

namespace SocialSkillsApi.Models
{
    public class UserProfile
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<string>? SocialSkills { get; set; } = new List<string>();
        public List<SocialAccount>? SocialAccounts { get; set; } = new List<SocialAccount>();
    }
}
