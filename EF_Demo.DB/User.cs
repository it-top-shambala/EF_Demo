using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EF_Demo.DB;

[Table("tab_users")]
public record User
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("first_name")]
    public string? FirstName { get; set; }
    
    [Column("last_name")]
    public string? LastName { get; set; }
    
    [Column("age")]
    public int Age { get; set; }

    public List<Contact>? Contacts { get; set; }

    public User() { }
    public User(string? firstName, string? lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public User(int id, string? firstName, string? lastName, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}

// public record User(int Id, string? FirstName, string? LastName, int Age);