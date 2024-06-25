using Microsoft.AspNetCore.Mvc;
using SocialSkillsApi.Models;
using SocialSkillsApi.Repositories;
using System.Linq;

namespace SocialSkillsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            _userProfileRepository.Save(userProfile);

            var fullName = $"{userProfile.FirstName} {userProfile.LastName}";
            var reversedFullName = new string(fullName.Reverse().ToArray());
            var vowelsCount = fullName.Count(c => "aeiouAEIOU".Contains(c));
            var consonantsCount = fullName.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));

            var response = new
            {
                vowels = vowelsCount,
                consonants = consonantsCount,
                fullName = fullName,
                reversedFullName = reversedFullName
            };

            return Ok(response);
        }
    }
}
