using API.Test.Api;
using API.Test.Helpers;
using API.Test.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;

namespace API.Test
{
    [TestClass]
    public class ApiTests : UsersApi
    {
        [TestMethod]
        public void TestCase_001_GetAllUsersUnauthorized()
        {
            var response = GetAllUsers(Guid.NewGuid().ToString(), 1);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [TestMethod]
        public void TestCase_002_AddRemoveUserFlow()
        {
            // Register new user
            var email = StringHelpers.GenerateRandomEmail();
            var body = JsonHelper.ChangeJsonValue(JsonHelper.JsonUserRegister, "email", email);
            var response = UserRegister(body);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Login with new user
            body = JsonHelper.ChangeJsonValue(JsonHelper.JsonUserLogin, "email", email);
            response = UserLogin(body);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Get user token
            var token = JsonHelper.GetTokenFromRestResponse(response);

            // Add a new user
            body = JsonHelper.ChangeJsonValue(JsonHelper.JsonUser, "email", StringHelpers.GenerateRandomEmail());
            response = AddUser(body, token);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var id = JsonHelper.GetUserIdFromRestResponse(response);

            // Get newly created user
            response = GetUserById(token, id);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Delete newly created user
            response = DeleteUserById(token, id);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Try to get user again and validate NotFound Error
            response = GetUserById(token, id);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

        }
    }
}