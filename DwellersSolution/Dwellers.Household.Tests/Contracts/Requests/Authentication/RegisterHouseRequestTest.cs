using Dwellers.Household.Contracts.Requests;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dwellers.Household.Tests.Contracts.Requests.Authentication
{
    public class RegisterHouseRequestTest
    {
        //[Fact]
        //public void RegisterHouseRequest_Serialization_Deserialization()
        //{
        //    var originalRequest = new RegisterHouseRequest(
        //        "testname", 
        //        "testDescription", 
        //        "test@mail.com", 
        //        IFormFile HousePhoto);

        //    // Act
        //    var serializedJson = JsonSerializer.Serialize(originalRequest);
        //    var deserializedRequest = JsonSerializer.Deserialize<RegisterHouseRequest>(serializedJson);

        //    // Assert
        //    Assert.NotNull(deserializedRequest);
        //    Assert.Equal(originalRequest.Name, deserializedRequest.Name);
        //    Assert.Equal(originalRequest.Description, deserializedRequest.Description);
        //    Assert.Equal(originalRequest.Email, deserializedRequest.Email);
        //}
    }
}
