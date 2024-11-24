using System.Text.Json;

var person = new Person
{
    FirstName = "John",
    LastName = "Park",
    YearOfBirth = 1976
};

var asJson = JsonSerializer.Serialize(person);
Console.WriteLine("As Json: ");
Console.WriteLine(asJson);

var personJson = "{\"FirstName\":\"John\",\"LastName\":\"Park\",\"YearOfBirth\":1976}";

var personFromJson = JsonSerializer.Deserialize<Person>(personJson);

public class Person
{
    public string FirstName { get; set; } = "No";
    public string LastName { get; set; } = "Body";
    public int YearOfBirth { get; set; } 
}