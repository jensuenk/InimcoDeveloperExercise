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
                    new SocialAccount { Type = "Linkedin", Address = "Linkedin.com/johndoe" }
                }
            };

            // Setup mock repository method
            mockRepo.Setup(repo => repo.Save(It.IsAny<UserProfile>()));

            // Act
            var result = controller.Post(userProfile) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            // Check if response is not null and is of the expected type
            var response = result.Value as IDictionary<string, object>;
            Assert.NotNull(response);

            // Assert individual properties
            Assert.True(response.TryGetValue("vowels", out var vowels));
            Assert.True(response.TryGetValue("consonants", out var consonants));
            Assert.True(response.TryGetValue("fullName", out var fullName));
            Assert.True(response.TryGetValue("reversedFullName", out var reversedFullName));

            Assert.Equal(3, (int)vowels);
            Assert.Equal(4, (int)consonants);
            Assert.Equal("John Doe", (string)fullName);
            Assert.Equal("eoD nhoJ", (string)reversedFullName);

            // Verify mock repository method was called
            mockRepo.Verify(repo => repo.Save(It.IsAny<UserProfile>()), Times.Once);
        }
    }
}
