using FluentAssertions;

namespace TrueCode.Reader.UnitTests;

public class ReaderTest
{
    [Fact]
    public void MessageShouldNotBeEmpty()
    {
        //Arrange
        byte[] data = { 70, 71, 72, 73, 74, 75 };
        byte delimiter = 255;
        var inputStream = new MemoryStream(data);
        var reader = new MessageReader(inputStream, delimiter);

        //Act
        var result = reader.ReadMessage();

        //Assert
        result.Should().NotBeEmpty();
    }
}