using Business.Helpers;

namespace MyContactList_Test.Helpers;
public class IdGenerator_Test
{
    [Fact]
    public void Generate_ShouldReturnGuidAsString()
    {
        // act
        var result = IdGenerator.GenerateID();

        // assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
