using Dwellers.Household.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dwellers.Household.Tests.Contracts.Requests.Authentication
{
    public class GetUserDetailsRequestTest
    {
        [Fact]
        public void GetUserDetailsRequestTest_Serialization_Deserialization()
        {
            var originalRequest = new GetUserDetailsRequest("userid123", new Guid("2edaf9f4-8d45-4b97-b7c8-9abf1d7755b7"));

            // Act
            var serializedJson = JsonSerializer.Serialize(originalRequest);
            var deserializedRequest = JsonSerializer.Deserialize<GetUserDetailsRequest>(serializedJson);

            // Assert
            Assert.NotNull(deserializedRequest);
            Assert.Equal(originalRequest.UserId, deserializedRequest.UserId);
            Assert.Equal(originalRequest.HouseId, deserializedRequest.HouseId);
        }
    }
}
