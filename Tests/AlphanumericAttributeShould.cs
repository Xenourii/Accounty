using Accounty.Api.ValidationAttributes;
using Xunit;

namespace Tests
{
    public class AlphanumericAttributeShould
    {
        [Theory]
        [InlineData("abcdef", true)]
        [InlineData("0123", true)]
        [InlineData("&", false)]
        public void Validate_Alphanumeric_string(string str, bool expected)
        {
            var attribute = new AlphanumericAttribute();
            var result = attribute.IsValid(str);
            Assert.Equal(result, expected);
        }
    }
}