using Dwellers.Bulletins.Domain.Bulletins;
using Dwellers.Bulletins.Domain.Bulletins.Rules;
using static Dwellers.Bulletins.Domain.Bulletins.Bulletin;

namespace Dwellers.Bulletins.Domain.Test
{

    public class BulletinTagTests
    {

        [Fact]
        public void DwellerValidation_BrokenRule_ShouldReturnFalseWithErrorMessage()
        {
            // Arrange
            var bulletin = new Bulletin();
            List<string> strTags = new List<string>
            {
                "tag1",
                "tag2"
            };

            var currentTags = BulletinTag.BulletinTagFactory.CreateNewCollectionOfTags
                                            (strTags, new BulletinId(Guid.NewGuid()));

            var brokenRule = new DomainIsBroken(currentTags, "tag1");

            // Act
            var result = BulletinTag.DwellerValidation(brokenRule);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("There can not be two identical tags", result.ErrorMessage);
        }

        [Fact]
        public void DwellerValidation_NoBrokenRule_ShouldReturnTrue()
        {

            // Arrange
            var bulletin = new Bulletin();
            List<string> strTags = new List<string>
            {
                "tag1",
                "tag2"
            };

            var currentTags = BulletinTag.BulletinTagFactory.CreateNewCollectionOfTags
                                            (strTags, new BulletinId(Guid.NewGuid()));

            var noBrokenRule = new DomainIsBroken(currentTags, null);

            // Act
            var result = BulletinTag.DwellerValidation(noBrokenRule);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Null(result.ErrorMessage);
        }
    }
}
