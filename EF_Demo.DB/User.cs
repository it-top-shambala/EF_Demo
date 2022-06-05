namespace EF_Demo.DB;

public record User
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }

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