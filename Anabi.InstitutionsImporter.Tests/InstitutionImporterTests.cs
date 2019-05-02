using Xunit;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;

namespace Anabi.InstitutionsImporter.Tests
{
    public class InstitutionImporterTest
    {
        [Fact]
        public void ShouldBeNotNull()
        {
            var result = InstitutionImporter.Deserialize();
            Assert.NotNull(result);
        }

        [Fact]
        public void ListOfInstitutionsShouldBeNotEmpty()
        {
            var result = InstitutionImporter.Deserialize(); ;

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void ShouldFind_A_Court()
        {
            var result = InstitutionImporter.Deserialize(); ;

            var expected = new List<Institution>
            {
                new Institution(){ Id = 107, Name = "Tribunalul ALBA" }
            };

            var actual = result.Where(i => i.Id == 107);

            actual.FirstOrDefault()
                .Should()
                .BeEquivalentTo(expected.FirstOrDefault());               
        }
    }
}
