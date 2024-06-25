using Microsoft.AspNetCore.Mvc;
using SocialSkillsApi.Models;
using SocialSkillsApi.Repositories;
using System.Linq;
using System.Text.Json;

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
            if (userProfile == null)
            {
                return BadRequest("User profile cannot be null");
            }

            _userProfileRepository.Save(userProfile);

            var fullName = $"{userProfile.FirstName} {userProfile.LastName}";
            var reversedFullName = new string(fullName.Reverse().ToArray());
            var vowelsCount = fullName.Count(c => "aeiouAEIOU".Contains(c));
            var consonantsCount = fullName.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));

            // Log the data
            Console.WriteLine($"The number of VOWELS: {vowelsCount}");
            Console.WriteLine($"The number of CONSONANTS: {consonantsCount}");
            Console.WriteLine($"The firstname + last name entered: {fullName}");
            Console.WriteLine($"The reverse version of the firstname and lastname: {reversedFullName}");
            Console.WriteLine("The JSON format of the entire object:");
            Console.WriteLine(JsonSerializer.Serialize(userProfile, new JsonSerializerOptions { WriteIndented = true }));

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
