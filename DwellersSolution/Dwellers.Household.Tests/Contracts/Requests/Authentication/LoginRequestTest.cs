using Dwellers.Household.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dwellers.Household.Tests.Contracts.Requests.Authentication
{
    public class LoginRequestTest
    {
        [Fact]
        public void LoginRequestTest_Serialization_Deserialization()
        {
            var originalRequest = new LoginRequest("test@mail.com", "testPassword");

            // Act
            var serializedJson = JsonSerializer.Serialize(originalRequest);
            var deserializedRequest = JsonSerializer.Deserialize<LoginRequest>(serializedJson);

            // Assert
            Assert.NotNull(deserializedRequest);
            Assert.Equal(originalRequest.Email, deserializedRequest.Email);
            Assert.Equal(originalRequest.Password, deserializedRequest.Password);
        }
    }
}
