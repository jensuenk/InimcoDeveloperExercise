using System.Collections.Generic;

namespace SocialSkillsApi.Models
{
    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> SocialSkills { get; set; }
        public List<SocialAccount> SocialAccounts { get; set; }
    }
}
