namespace TrueCode.Reader;

public class MessageReader(Stream stream, byte delimiter)
{
    public string ReadMessage()
    {
        using var memoryStream = new MemoryStream();

        int byteRead;
        while ((byteRead = stream.ReadByte()) != -1)
        {
            if (byteRead == delimiter)
                break;

            memoryStream.WriteByte((byte)byteRead);
        }

        var message = BitConverter.ToString(memoryStream.ToArray());
        return message;
    }
}
