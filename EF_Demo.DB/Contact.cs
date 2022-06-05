using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Demo.DB;

[Table("tab_contacts")]
public record Contact
{
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    public string? Type { get; set; }
    
    [Column("content")]
    public string? Content { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    public User? User { get; set; }

    public Contact() {}
    public Contact(string type, string content, User user)
    {
        Type = type;
        Content = content;
        User = user;
    }
}