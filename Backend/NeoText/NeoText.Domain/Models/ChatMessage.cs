namespace NeoText.Domain.Models;
public class ChatMessage
{
    public int SenderId { get; set; }
    public string SenderUserName { get; set; } = string.Empty;
    public string ReceiverUserName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
