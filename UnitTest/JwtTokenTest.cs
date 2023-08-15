using JWTAuthenticationManager;
using TokenHandlerModels;

namespace UnitTest
{
    [TestClass]
    public class JwtTokenTest
    {
        [TestMethod]
        public void GenerateJwtTokenTest()
        {
            var handler = new JwtTokenHandler();

            var user = new UserAccount() { Name = "test", Password = "12345", Role = new UserRole() { RoleName = "User"}, RoleId = 2};
            var token = handler.GenerateJwtToken(user);

            var expected = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
            var actual = token?.Token.Remove(token.Token.IndexOf('.'));

            Assert.AreEqual(expected, actual);
        }
    }
}