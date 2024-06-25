using Microsoft.AspNetCore.Mvc;
using Moq;
using SocialSkillsApi.Controllers;
using SocialSkillsApi.Models;
using SocialSkillsApi.Repositories;
using System.Collections.Generic;
using Xunit;

namespace SocialSkillsApi.Tests
{
    public class UserProfileControllerTests
    {
        [Fact]
        public void Post_ReturnsCorrectResponse()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var controller = new UserProfileController(mockRepo.Object);
            var userProfile = new UserProfile
            {
                FirstName = "John",
                LastName = "Doe",
                SocialSkills = new List<string> { "social", "fun", "coach" },
                SocialAccounts = new List<SocialAccount>
                {
                    new SocialAccount { Type = "Twitter", Address = "@JohnDoe" },
                    new SocialAccount { Type = "LinkedIn", Address = "LinkedIn.com/johndoe" }
                }
            };

            // Act
            var result = controller.Post(userProfile) as OkObjectResult;
            Assert.NotNull(result);

            var response = result.Value as dynamic;

            // Assert
            Assert.NotNull(response);
            Assert.Equal(3, (int)response.vowels);
            Assert.Equal(4, (int)response.consonants);
            Assert.Equal("John Doe", (string)response.fullName);
            Assert.Equal("eoD nhoJ", (string)response.reversedFullName);
        }

        [Fact]
        public void Post_NullUserProfile_ReturnsBadRequest()
        {
            // Arrange
            var mockRepo = new Mock<IUserProfileRepository>();
            var controller = new UserProfileController(mockRepo.Object);

            // Act
            var result = controller.Post(null) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("User profile cannot be null", result.Value);
        }
    }
}
