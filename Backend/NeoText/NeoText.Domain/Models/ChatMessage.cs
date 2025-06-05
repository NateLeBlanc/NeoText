namespace NeoText.Domain.Models;
public class ChatMessage
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
