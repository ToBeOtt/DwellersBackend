using Dwellers.Household.Contracts.Responses.Authentication;
using System.Text.Json;

namespace Dwellers.Household.Tests.Contracts.Responses.Authentication
{
    public class RegisterResponseTest
    {
        [Fact]
        public void RegisterResponse_Serialization_Deserialization()
        {
            // Arrange
            var originalResponse = new RegisterResponse("123", "testuser", "testalias", "test@example.com");
          
            // Act
            var serializedJson = JsonSerializer.Serialize(originalResponse);
            var deserializedResponse = JsonSerializer.Deserialize<RegisterResponse>(serializedJson);

            // Assert
            Assert.NotNull(deserializedResponse);
            Assert.Equal(originalResponse.Id, deserializedResponse.Id);
            Assert.Equal(originalResponse.Username, deserializedResponse.Username);
            Assert.Equal(originalResponse.Alias, deserializedResponse.Alias);
            Assert.Equal(originalResponse.Email, deserializedResponse.Email);
        }
    }
}

