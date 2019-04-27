using Xunit;
using System.Linq;
using System.Collections.Generic;
using FluentAssertions;

namespace Anabi.InstitutionsImporter.Tests
{
    public class InstitutionImporterTest
    {
        private readonly InstitutionImporter _institutionImporter;

        public InstitutionImporterTest()
        {
            _institutionImporter = new InstitutionImporter();
        }

        [Fact]
        public void ShouldBeNotNull()
        {
            var result = _institutionImporter.RunImporter();
            Assert.NotNull(result);
        }

        [Fact]
        public void ListOfInstitutionsShouldBeNotEmpty()
        {
            var result = _institutionImporter.RunImporter();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void ShouldFind_A_Court()
        {
            var result = _institutionImporter.RunImporter();

            var expected = new List<Institutions>
            {
                new Institutions(){ Id = 107, Name = "Tribunalul ALBA" }
            };

            var actual = result.Where(i => i.Id == 107);

            actual.FirstOrDefault()
                .Should()
                .BeEquivalentTo(expected.FirstOrDefault());               
        }
    }
}
