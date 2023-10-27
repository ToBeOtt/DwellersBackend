using Dwellers.Household.Contracts.Responses.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dwellers.Household.Tests.Contracts.Responses.Authentication
{
    public class LoginResponseTest
    {
        [Fact]
        public void LoginResponse_Serialization_Deserialization()
        {
            // Arrange
            var originalResponse = new LoginResponse("123", "testuser", "test@example.com", "token123");

            // Act
            var serializedJson = JsonSerializer.Serialize(originalResponse);
            var deserializedResponse = JsonSerializer.Deserialize<LoginResponse>(serializedJson);

            // Assert
            Assert.NotNull(deserializedResponse);
            Assert.Equal(originalResponse.Id, deserializedResponse.Id);
            Assert.Equal(originalResponse.Username, deserializedResponse.Username);
            Assert.Equal(originalResponse.Email, deserializedResponse.Email);
            Assert.Equal(originalResponse.Token, deserializedResponse.Token);
        }
    }
}
