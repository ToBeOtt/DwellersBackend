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
    public class RegisterHouseResponseTest
    {
        [Fact]
        public void RegisterHouseResponse_Serialization_Deserialization()
        {
            // Arrange
            var originalResponse = new RegisterHouseResponse("123", "testuser", "testalias", new Guid("00000000-0000-0000-0000-000000000000"));

            // Act

            var serializedJson = JsonSerializer.Serialize(originalResponse);
            var deserializedResponse = JsonSerializer.Deserialize<RegisterHouseResponse>(serializedJson);

            // Assert
            Assert.NotNull(deserializedResponse);
            Assert.Equal(originalResponse.Id, deserializedResponse.Id);
            Assert.Equal(originalResponse.Email, deserializedResponse.Email);
            Assert.Equal(originalResponse.Name, deserializedResponse.Name);
            Assert.Equal(originalResponse.InvitationToHousehold, deserializedResponse.InvitationToHousehold);
        }
    }
}
