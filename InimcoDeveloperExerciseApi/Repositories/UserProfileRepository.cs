using SocialSkillsApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SocialSkillsApi.Repositories
{
    public interface IUserProfileRepository
    {
        void Save(UserProfile userProfile);
    }

    public class UserProfileRepository : IUserProfileRepository
    {
        private const string FilePath = "userProfiles.json";

        public void Save(UserProfile userProfile)
        {
            var userProfiles = new List<UserProfile>();
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                userProfiles = JsonSerializer.Deserialize<List<UserProfile>>(json);
            }
            userProfiles.Add(userProfile);
            File.WriteAllText(FilePath, JsonSerializer.Serialize(userProfiles));
        }
    }
}
