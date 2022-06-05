namespace EF_Demo.DB;

public record User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
}

// public record User(int Id, string? FirstName, string? LastName, int Age);