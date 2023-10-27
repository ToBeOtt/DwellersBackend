using Dwellers.Household.Contracts;
using Dwellers.Household.Contracts.Responses.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dwellers.Household.Tests.Contracts.Responses.Authentication
{
    public class RegisterMemberToHouseResponseTest
    {
        [Fact]
        public void RegisterMemberToHouseReponse_Serialization_Deserialization()
        {
            // Arrange
            var originalResponse = new RegisterMemberToHouseResponse("123", "test@example.com", "testuser");

            // Act
            var serializedJson = JsonSerializer.Serialize(originalResponse);
            var deserializedResponse = JsonSerializer.Deserialize<RegisterMemberToHouseResponse>(serializedJson);

            // Assert
            Assert.NotNull(deserializedResponse);
            Assert.Equal(originalResponse.Id, deserializedResponse.Id);
            Assert.Equal(originalResponse.Email, deserializedResponse.Email);
            Assert.Equal(originalResponse.Name, deserializedResponse.Name);
            
        }
    }
}
