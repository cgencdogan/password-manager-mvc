namespace Common.DataTransferObjects;

public class SavedPasswordDto {
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public string UserId { get; set; }
    public Guid? CategoryId { get; set; }
}
